using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Mpv.NET.API;
using Mpv.NET.Player;
using VisualEffects;
using VisualEffects.Animations.Effects;
using VisualEffects.Animators;
using VisualEffects.Easing;

//TODO: Fix a bunch of layout stuff. Mouse movements do not appear to be captured.//  
namespace MpvWinFormPlayer
{
    public partial class VideoPlayerForm : Form
    {
        private readonly bool _allowSkippingForward;
        private readonly MpvPlayer _player;
        private AnimationStatus _videoEditorControlsPanelAnimationStatus;
        private Point _previousMousePosition;
        private readonly System.Timers.Timer _hideTimer;
        private readonly System.Timers.Timer _exitButtonTimer;
        private int _mouseLastPositionOnControl;
        private int _mouseOnPanelCheckHeight;
        private bool _isVideoUserValueChanging;
        private bool _isVideoAutoValueChanging;
        private bool _allowShotFirstExitVideoButton;
        private bool _preventControlBarHiding;
        private readonly bool _requiresTest;
        private readonly string _testPath;
        private TimeSpan _maxVideoProgress;
        private const int WmNclbuttondown = 0xA1;
        private const int HtCaption = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public VideoPlayerForm(string videoPath, bool allowSkippingForward = true)
        {
            _allowSkippingForward = allowSkippingForward;

            InitializeComponent();

            if (!_allowSkippingForward)
            {
                skipForwardSimpleButton.Enabled = false;
            }

            if (videoPath is null || string.IsNullOrWhiteSpace(videoPath) || !File.Exists(videoPath))
            {
                MessageBox.Show("There was an error loading this video, the player will now close.",
                    "Error Loading Video", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            videoEditorControlsPanel.Location = new Point(0, Height);

            _hideTimer = new System.Timers.Timer { Interval = 4000 };
            _hideTimer.Elapsed += _hideTimer_Elapsed;
            _hideTimer.Enabled = true;

            _exitButtonTimer = new System.Timers.Timer { Interval = 4000 };
            _exitButtonTimer.Elapsed += _exitButtonTimer_Elapsed;
            _exitButtonTimer.Enabled = true;

            _exitButtonTimer.Start();

            var tempPathLocation = $@"{Path.GetTempPath()}{Guid.NewGuid()}mpv-1.dll";
            File.Copy($@"{Environment.CurrentDirectory}\mpv-1.txt", tempPathLocation);
            _player = new MpvPlayer(videoPlayerPanel.Handle, tempPathLocation)
            {
                Volume = 100
            };

            _player.Load(videoPath);
            _player.PositionChanged += _player_PositionChanged;
            _player.MediaLoaded += _player_MediaLoaded;
            _player.MediaFinished += _player_MediaFinished;
            _player.Resume();

            playPauseSimpleButton.Click += PlayPauseSimpleButton_ClickForPause;
        }

        private void VideoPlayerForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void VideoProgressTrackBarControl_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void VolumeTrackBarControl_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void FullScreenSimpleButton_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void SkipForwardSimpleButton_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void PlayPauseSimpleButton_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void SkipBackSimpleButton_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void VolumeLouderFakeButton_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void VolumeQuieterFakeButton_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void ExitVideoPlayerFormSimpleButton_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void VideoPlayerForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    playPauseSimpleButton.PerformClick();
                    ShowHideVideoControls(true);
                    break;
                case Keys.Escape:
                    if (WindowState == FormWindowState.Maximized)
                    {
                        fullScreenSimpleButton.PerformClick();
                        ShowHideVideoControls(true);
                    }
                    break;
                case Keys.Right:
                    if (_allowSkippingForward)
                    {
                        skipForwardSimpleButton.PerformClick();
                    }
                    ShowHideVideoControls(true);
                    break;
                case Keys.Left:
                    skipBackSimpleButton.PerformClick();
                    ShowHideVideoControls(true);
                    break;
                case Keys.Up:
                    if (volumeTrackBarControl.Value < 100)
                    {
                        ShowHideVideoControls(true);
                        volumeTrackBarControl.Value += 1;
                    }
                    break;
                case Keys.Down:
                    if (volumeTrackBarControl.Value > 0)
                    {
                        ShowHideVideoControls(true);
                        volumeTrackBarControl.Value -= 1;
                    }
                    break;
            }
        }

        private void PlayPauseSimpleButton_ClickForPause(object sender, EventArgs e)
        {
            _player.Pause();
            playPauseSimpleButton.Image = Properties.Resources.play;
            playPauseSimpleButton.Click -= PlayPauseSimpleButton_ClickForPause;
            playPauseSimpleButton.Click += PlayPauseSimpleButton_ClickForPlay;
        }

        private void PlayPauseSimpleButton_ClickForPlay(object sender, EventArgs e)
        {
            _player.Resume();
            playPauseSimpleButton.Image = Properties.Resources.pause;
            playPauseSimpleButton.Click -= PlayPauseSimpleButton_ClickForPlay;
            playPauseSimpleButton.Click += PlayPauseSimpleButton_ClickForPause;
        }

        private void SkipBackSimpleButton_Click(object sender, EventArgs e)
        {
            if (_player.IsMediaLoaded)
            {
                _player.SeekAsync(_player.Position.TotalSeconds - 15 < 0 ? 0 : _player.Position.TotalSeconds - 15);
            }
        }

        private void SkipForwardSimpleButton_Click(object sender, EventArgs e)
        {
            if (_player.IsMediaLoaded)
            {
                _player.SeekAsync(_player.Position.TotalSeconds + 15 > _player.Duration.TotalSeconds
                    ? _player.Duration.TotalSeconds
                    : _player.Position.TotalSeconds + 15);
            }
        }

        private void _player_MediaLoaded(object sender, EventArgs e)
        {
            if (!(sender is MpvPlayer mpvPlayer)) return;
            videoProgressTrackBarControl.BeginInvoke((MethodInvoker)delegate
            {
                videoRemainingProgressLabelControl.Text = $@"-{mpvPlayer.Duration.Minutes:#0}:{mpvPlayer.Duration.Seconds:#0}";
                videoProgressTrackBarControl.Maximum = Convert.ToInt32(mpvPlayer.Duration.TotalSeconds);
                ShowHideVideoControls(true);
            });
        }

        private void _player_MediaFinished(object sender, EventArgs e)
        {
            if (_requiresTest && Uri.IsWellFormedUriString(_testPath, UriKind.RelativeOrAbsolute))
            {
                Process.Start(_testPath);
            }

            BeginInvoke((MethodInvoker)delegate
            {
                DialogResult = DialogResult.OK;
            });
        }

        private void _player_PositionChanged(object sender, MpvPlayerPositionChangedEventArgs e)
        {
            _maxVideoProgress = e.NewPosition >= _maxVideoProgress ? e.NewPosition : _maxVideoProgress;

            if (!(sender is MpvPlayer mpvPlayer)) return;
            videoProgressTrackBarControl.BeginInvoke((MethodInvoker)delegate
            {

                try
                {
                    if (mpvPlayer.Remaining == new TimeSpan(0, 0, 0)) return;
                    videoCurrentProgressLabelControl.Text = $@"{e.NewPosition.Minutes:D2}:{e.NewPosition.Seconds:D2}";
                    videoRemainingProgressLabelControl.Text =
                        $@"-{mpvPlayer.Remaining.Minutes:D2}:{mpvPlayer.Remaining.Seconds:D2}";
                    if (_isVideoUserValueChanging) return;
                    _isVideoAutoValueChanging = true;
                    videoProgressTrackBarControl.Value = Convert.ToInt32(e.NewPosition.TotalSeconds);
                    _isVideoAutoValueChanging = false;
                }
                catch (MpvAPIException ex)
                {
                    if (ex.Message == "Error occured: \"property unavailable\".")
                    {
                        //Do nothing as this an error from the user changing the player index faster than MPI Player can keep up
                    }
                    else
                    {
                        throw;
                    }
                }
            });
        }

        private void VideoProgressTrackBarControl_ValueChanged(object sender, EventArgs e)
        {
            if (_isVideoAutoValueChanging) return;
            _preventControlBarHiding = true;
            _isVideoUserValueChanging = true;
            videoProgressTrackBarControl.ValueChanged += VideoProgressTrackBarControl_UserValueChanged;
        }

        private void VideoProgressTrackBarControl_UserValueChanged(object sender, EventArgs e)
        {
            _isVideoUserValueChanging = false;

            if (sender is TrackBar trackBarControl && _player.IsMediaLoaded)
            {
                try
                {
                    if (_player.Duration == new TimeSpan(0, 0, 0)) return;
                    var newPosition = new TimeSpan(0, 0, trackBarControl.Value);
                    var isNewPositionBehind = _player.Position > newPosition;
                    if (_allowSkippingForward || newPosition < _maxVideoProgress ||
                        !_allowSkippingForward && isNewPositionBehind)
                    {
                        if (_player.Duration == new TimeSpan(0, 0, 0)) return;
                        if (newPosition > _player.Duration)
                        {
                            if (_player.Duration == new TimeSpan(0, 0, 0)) return;
                            _player.Position = _player.Duration;
                        }
                        else
                        {
                            var videoSetTimeSpan = new TimeSpan(0, 0, trackBarControl.Value);
                            if (_player.Duration == new TimeSpan(0, 0, 0)) return;
                            _player.Position = videoSetTimeSpan;
                        }
                    }
                }
                catch (MpvAPIException ex)
                {
                    if (ex.Message == "Error occured: \"property unavailable\".")
                    {
                        //Do nothing as this an error from the user changing the player index faster than MPI Player can keep up
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            _preventControlBarHiding = false;
            videoProgressTrackBarControl.ValueChanged -= VideoProgressTrackBarControl_UserValueChanged;
        }

        //private void VolumeTrackBarControl_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        //{
        //    _preventControlBarHiding = true;
        //}

        private void VolumeTrackBarControl_ValueChanged(object sender, EventArgs e)
        {
            _preventControlBarHiding = false;
        }

        private void _hideTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ShowHideVideoControls(false);
        }

        private void _exitButtonTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (exitVideoPlayerFormSimpleButton.Created)
            {
                exitVideoPlayerFormSimpleButton.BeginInvoke((MethodInvoker)delegate
                {
                    if (exitVideoPlayerFormSimpleButton.Created)
                    {
                        exitVideoPlayerFormSimpleButton.Visible = false;
                    }
                });
            }
        }

        private void VideoPlayerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_previousMousePosition != e.Location && _allowShotFirstExitVideoButton)
            {
                exitVideoPlayerFormSimpleButton.Visible = true;
                _exitButtonTimer.Stop();
                _exitButtonTimer.Start();
            }

            _previousMousePosition = e.Location;

            _mouseLastPositionOnControl = e.Y;
            _mouseOnPanelCheckHeight = Height - videoEditorControlsPanel.Height;

            if (_videoEditorControlsPanelAnimationStatus != null &&
                _mouseLastPositionOnControl >= _mouseOnPanelCheckHeight &&
                _videoEditorControlsPanelAnimationStatus.IsCompleted)
            {
                ShowHideVideoControls(true);
            }
        }

        private void FullScreenSimpleButton_Click(object sender, EventArgs e)
        {
            _videoEditorControlsPanelAnimationStatus.CancellationToken.Cancel(false);
            ToggleFullScreen();
        }

        private void VideoPlayerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            switch (e.Clicks)
            {
                case 1:
                    ReleaseCapture();
                    SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
                    break;
                case 2:
                    ToggleFullScreen();
                    break;
            }
        }

        private void ToggleFullScreen()
        {
            if (WindowState != FormWindowState.Maximized)
            {
                TopMost = true;
                WindowState = FormWindowState.Maximized;
                fullScreenSimpleButton.Image = Properties.Resources.actions_fullscreenexit;
            }
            else
            {
                TopMost = false;
                WindowState = FormWindowState.Normal;
                fullScreenSimpleButton.Image = Properties.Resources.actions_fullscreen;
            }
        }

        private void VolumeTrackBarControl_eValueChanged(object sender, EventArgs e)
        {
            if (sender is TrackBar trackBarControl) _player.Volume = trackBarControl.Value;
        }

        private void VolumeQuieterFakeButton_Click(object sender, EventArgs e)
        {
            _player.Volume = 0;
            volumeTrackBarControl.Value = _player.Volume;
        }

        private void VolumeLouderFakeButton_Click(object sender, EventArgs e)
        {
            _player.Volume = 100;
            volumeTrackBarControl.Value = _player.Volume;
        }

        private void ExitVideoPlayerFormSimpleButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VideoPlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _player?.Dispose();
        }

        /// <summary>
        /// Shows or Hides the videoEditorControlsPanel
        /// </summary>
        /// <param name="isShow">True shows the panel, False hides the panel</param>
        private void ShowHideVideoControls(bool isShow)
        {
            var hideHeight = 0;

            if (isShow)
            {
                _hideTimer.Stop();
                _hideTimer.Start();
                hideHeight = videoEditorControlsPanel.Height - 3;
            }
            else
            {
                if (_preventControlBarHiding)
                {
                    _hideTimer.Stop();
                    _hideTimer.Start();
                    return;
                }

                if (_mouseLastPositionOnControl >= _mouseOnPanelCheckHeight)
                {
                    _hideTimer.Stop();
                    _hideTimer.Start();
                    return;
                }
            }

            _allowShotFirstExitVideoButton = true;

            _videoEditorControlsPanelAnimationStatus = videoEditorControlsPanel.Animate(
            new YLocationEffect(),
            EasingFunctions.Linear,
            Height - hideHeight,
            500,
            0);
        }
    }
}
