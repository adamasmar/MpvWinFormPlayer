namespace MpvWinFormPlayer
{
    partial class VideoPlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPlayerForm));
            this.videoPlayerPanel = new System.Windows.Forms.Panel();
            this.volumeTrackBarControl = new System.Windows.Forms.TrackBar();
            this.videoRemainingProgressLabelControl = new System.Windows.Forms.Label();
            this.videoCurrentProgressLabelControl = new System.Windows.Forms.Label();
            this.videoProgressTrackBarControl = new System.Windows.Forms.TrackBar();
            this.videoEditorControlsPanel = new System.Windows.Forms.Panel();
            this.exitVideoPlayerFormSimpleButton = new System.Windows.Forms.Button();
            this.skipForwardSimpleButton = new System.Windows.Forms.Button();
            this.fullScreenSimpleButton = new System.Windows.Forms.Button();
            this.playPauseSimpleButton = new System.Windows.Forms.Button();
            this.volumeLouderFakeButton = new System.Windows.Forms.Button();
            this.skipBackSimpleButton = new System.Windows.Forms.Button();
            this.volumeQuieterFakeButton = new System.Windows.Forms.Button();
            this.videoPlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoProgressTrackBarControl)).BeginInit();
            this.videoEditorControlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoPlayerPanel
            // 
            this.videoPlayerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.videoPlayerPanel.Controls.Add(this.exitVideoPlayerFormSimpleButton);
            this.videoPlayerPanel.Controls.Add(this.videoEditorControlsPanel);
            this.videoPlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayerPanel.Location = new System.Drawing.Point(0, 0);
            this.videoPlayerPanel.Name = "videoPlayerPanel";
            this.videoPlayerPanel.Size = new System.Drawing.Size(890, 501);
            this.videoPlayerPanel.TabIndex = 0;
            this.videoPlayerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VideoPlayerPanel_MouseDown);
            this.videoPlayerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VideoPlayerPanel_MouseMove);
            // 
            // volumeTrackBarControl
            // 
            this.volumeTrackBarControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.volumeTrackBarControl.Location = new System.Drawing.Point(77, 20);
            this.volumeTrackBarControl.Name = "volumeTrackBarControl";
            this.volumeTrackBarControl.Size = new System.Drawing.Size(86, 45);
            this.volumeTrackBarControl.TabIndex = 9;
            this.volumeTrackBarControl.TickFrequency = 0;
            this.volumeTrackBarControl.ValueChanged += new System.EventHandler(this.VolumeTrackBarControl_eValueChanged);
            this.volumeTrackBarControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VolumeTrackBarControl_KeyDown);
            // 
            // videoRemainingProgressLabelControl
            // 
            this.videoRemainingProgressLabelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.videoRemainingProgressLabelControl.AutoSize = true;
            this.videoRemainingProgressLabelControl.BackColor = System.Drawing.Color.Transparent;
            this.videoRemainingProgressLabelControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.videoRemainingProgressLabelControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.videoRemainingProgressLabelControl.Location = new System.Drawing.Point(842, 23);
            this.videoRemainingProgressLabelControl.Name = "videoRemainingProgressLabelControl";
            this.videoRemainingProgressLabelControl.Size = new System.Drawing.Size(42, 13);
            this.videoRemainingProgressLabelControl.TabIndex = 6;
            this.videoRemainingProgressLabelControl.Text = "- 00:00";
            // 
            // videoCurrentProgressLabelControl
            // 
            this.videoCurrentProgressLabelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.videoCurrentProgressLabelControl.AutoSize = true;
            this.videoCurrentProgressLabelControl.BackColor = System.Drawing.Color.Transparent;
            this.videoCurrentProgressLabelControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.videoCurrentProgressLabelControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.videoCurrentProgressLabelControl.Location = new System.Drawing.Point(12, 23);
            this.videoCurrentProgressLabelControl.Name = "videoCurrentProgressLabelControl";
            this.videoCurrentProgressLabelControl.Size = new System.Drawing.Size(35, 13);
            this.videoCurrentProgressLabelControl.TabIndex = 5;
            this.videoCurrentProgressLabelControl.Text = "00:00";
            // 
            // videoProgressTrackBarControl
            // 
            this.videoProgressTrackBarControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoProgressTrackBarControl.Location = new System.Drawing.Point(3, 2);
            this.videoProgressTrackBarControl.Name = "videoProgressTrackBarControl";
            this.videoProgressTrackBarControl.Size = new System.Drawing.Size(884, 45);
            this.videoProgressTrackBarControl.TabIndex = 0;
            this.videoProgressTrackBarControl.TickFrequency = 0;
            this.videoProgressTrackBarControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.videoProgressTrackBarControl.ValueChanged += new System.EventHandler(this.VideoProgressTrackBarControl_ValueChanged);
            this.videoProgressTrackBarControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VideoProgressTrackBarControl_KeyDown);
            // 
            // videoEditorControlsPanel
            // 
            this.videoEditorControlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoEditorControlsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.videoEditorControlsPanel.Controls.Add(this.skipForwardSimpleButton);
            this.videoEditorControlsPanel.Controls.Add(this.videoRemainingProgressLabelControl);
            this.videoEditorControlsPanel.Controls.Add(this.videoCurrentProgressLabelControl);
            this.videoEditorControlsPanel.Controls.Add(this.fullScreenSimpleButton);
            this.videoEditorControlsPanel.Controls.Add(this.playPauseSimpleButton);
            this.videoEditorControlsPanel.Controls.Add(this.volumeLouderFakeButton);
            this.videoEditorControlsPanel.Controls.Add(this.skipBackSimpleButton);
            this.videoEditorControlsPanel.Controls.Add(this.volumeTrackBarControl);
            this.videoEditorControlsPanel.Controls.Add(this.volumeQuieterFakeButton);
            this.videoEditorControlsPanel.Controls.Add(this.videoProgressTrackBarControl);
            this.videoEditorControlsPanel.Location = new System.Drawing.Point(0, 452);
            this.videoEditorControlsPanel.Name = "videoEditorControlsPanel";
            this.videoEditorControlsPanel.Size = new System.Drawing.Size(890, 50);
            this.videoEditorControlsPanel.TabIndex = 11;
            // 
            // exitVideoPlayerFormSimpleButton
            // 
            this.exitVideoPlayerFormSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitVideoPlayerFormSimpleButton.BackColor = System.Drawing.Color.Transparent;
            this.exitVideoPlayerFormSimpleButton.FlatAppearance.BorderSize = 0;
            this.exitVideoPlayerFormSimpleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitVideoPlayerFormSimpleButton.Image = global::MpvWinFormPlayer.Properties.Resources.clearheaderandfooter;
            this.exitVideoPlayerFormSimpleButton.Location = new System.Drawing.Point(840, 20);
            this.exitVideoPlayerFormSimpleButton.Name = "exitVideoPlayerFormSimpleButton";
            this.exitVideoPlayerFormSimpleButton.Size = new System.Drawing.Size(20, 20);
            this.exitVideoPlayerFormSimpleButton.TabIndex = 10;
            this.exitVideoPlayerFormSimpleButton.UseVisualStyleBackColor = false;
            this.exitVideoPlayerFormSimpleButton.Click += new System.EventHandler(this.ExitVideoPlayerFormSimpleButton_Click);
            this.exitVideoPlayerFormSimpleButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExitVideoPlayerFormSimpleButton_KeyDown);
            // 
            // skipForwardSimpleButton
            // 
            this.skipForwardSimpleButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.skipForwardSimpleButton.BackColor = System.Drawing.Color.Transparent;
            this.skipForwardSimpleButton.FlatAppearance.BorderSize = 0;
            this.skipForwardSimpleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skipForwardSimpleButton.Image = global::MpvWinFormPlayer.Properties.Resources.redo_32x321;
            this.skipForwardSimpleButton.Location = new System.Drawing.Point(466, 17);
            this.skipForwardSimpleButton.Name = "skipForwardSimpleButton";
            this.skipForwardSimpleButton.Size = new System.Drawing.Size(37, 30);
            this.skipForwardSimpleButton.TabIndex = 3;
            this.skipForwardSimpleButton.UseVisualStyleBackColor = false;
            this.skipForwardSimpleButton.Click += new System.EventHandler(this.SkipForwardSimpleButton_Click);
            this.skipForwardSimpleButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SkipForwardSimpleButton_KeyDown);
            // 
            // fullScreenSimpleButton
            // 
            this.fullScreenSimpleButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fullScreenSimpleButton.BackColor = System.Drawing.Color.Transparent;
            this.fullScreenSimpleButton.FlatAppearance.BorderSize = 0;
            this.fullScreenSimpleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullScreenSimpleButton.Image = global::MpvWinFormPlayer.Properties.Resources.actions_fullscreen;
            this.fullScreenSimpleButton.Location = new System.Drawing.Point(805, 15);
            this.fullScreenSimpleButton.Name = "fullScreenSimpleButton";
            this.fullScreenSimpleButton.Size = new System.Drawing.Size(33, 30);
            this.fullScreenSimpleButton.TabIndex = 4;
            this.fullScreenSimpleButton.UseVisualStyleBackColor = false;
            this.fullScreenSimpleButton.Click += new System.EventHandler(this.FullScreenSimpleButton_Click);
            this.fullScreenSimpleButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullScreenSimpleButton_KeyDown);
            // 
            // playPauseSimpleButton
            // 
            this.playPauseSimpleButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playPauseSimpleButton.BackColor = System.Drawing.Color.Transparent;
            this.playPauseSimpleButton.FlatAppearance.BorderSize = 0;
            this.playPauseSimpleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playPauseSimpleButton.Image = ((System.Drawing.Image)(resources.GetObject("playPauseSimpleButton.Image")));
            this.playPauseSimpleButton.Location = new System.Drawing.Point(430, 17);
            this.playPauseSimpleButton.Name = "playPauseSimpleButton";
            this.playPauseSimpleButton.Size = new System.Drawing.Size(34, 30);
            this.playPauseSimpleButton.TabIndex = 2;
            this.playPauseSimpleButton.UseVisualStyleBackColor = false;
            this.playPauseSimpleButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlayPauseSimpleButton_KeyDown);
            // 
            // volumeLouderFakeButton
            // 
            this.volumeLouderFakeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.volumeLouderFakeButton.BackColor = System.Drawing.Color.Transparent;
            this.volumeLouderFakeButton.FlatAppearance.BorderSize = 0;
            this.volumeLouderFakeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.volumeLouderFakeButton.Image = global::MpvWinFormPlayer.Properties.Resources.electronics_volume;
            this.volumeLouderFakeButton.Location = new System.Drawing.Point(165, 15);
            this.volumeLouderFakeButton.Name = "volumeLouderFakeButton";
            this.volumeLouderFakeButton.Size = new System.Drawing.Size(33, 30);
            this.volumeLouderFakeButton.TabIndex = 8;
            this.volumeLouderFakeButton.UseVisualStyleBackColor = false;
            this.volumeLouderFakeButton.Click += new System.EventHandler(this.VolumeLouderFakeButton_Click);
            this.volumeLouderFakeButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VolumeLouderFakeButton_KeyDown);
            // 
            // skipBackSimpleButton
            // 
            this.skipBackSimpleButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.skipBackSimpleButton.BackColor = System.Drawing.Color.Transparent;
            this.skipBackSimpleButton.FlatAppearance.BorderSize = 0;
            this.skipBackSimpleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skipBackSimpleButton.Image = global::MpvWinFormPlayer.Properties.Resources.undo_32x32;
            this.skipBackSimpleButton.Location = new System.Drawing.Point(388, 17);
            this.skipBackSimpleButton.Name = "skipBackSimpleButton";
            this.skipBackSimpleButton.Size = new System.Drawing.Size(34, 30);
            this.skipBackSimpleButton.TabIndex = 1;
            this.skipBackSimpleButton.UseVisualStyleBackColor = false;
            this.skipBackSimpleButton.Click += new System.EventHandler(this.SkipBackSimpleButton_Click);
            this.skipBackSimpleButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SkipBackSimpleButton_KeyDown);
            // 
            // volumeQuieterFakeButton
            // 
            this.volumeQuieterFakeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.volumeQuieterFakeButton.BackColor = System.Drawing.Color.Transparent;
            this.volumeQuieterFakeButton.FlatAppearance.BorderSize = 0;
            this.volumeQuieterFakeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.volumeQuieterFakeButton.Image = global::MpvWinFormPlayer.Properties.Resources.electronics_volume;
            this.volumeQuieterFakeButton.Location = new System.Drawing.Point(57, 18);
            this.volumeQuieterFakeButton.Name = "volumeQuieterFakeButton";
            this.volumeQuieterFakeButton.Size = new System.Drawing.Size(33, 25);
            this.volumeQuieterFakeButton.TabIndex = 7;
            this.volumeQuieterFakeButton.UseVisualStyleBackColor = false;
            this.volumeQuieterFakeButton.Click += new System.EventHandler(this.VolumeQuieterFakeButton_Click);
            this.volumeQuieterFakeButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VolumeQuieterFakeButton_KeyDown);
            // 
            // VideoPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(890, 501);
            this.Controls.Add(this.videoPlayerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VideoPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Video Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoPlayerForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VideoPlayerForm_KeyDown);
            this.videoPlayerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoProgressTrackBarControl)).EndInit();
            this.videoEditorControlsPanel.ResumeLayout(false);
            this.videoEditorControlsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel videoPlayerPanel;
        private System.Windows.Forms.TrackBar videoProgressTrackBarControl;
        private System.Windows.Forms.Button playPauseSimpleButton;
        private System.Windows.Forms.Button skipBackSimpleButton;
        private System.Windows.Forms.Button skipForwardSimpleButton;
        private System.Windows.Forms.Button fullScreenSimpleButton;
        private System.Windows.Forms.Button volumeQuieterFakeButton;
        private System.Windows.Forms.Label videoRemainingProgressLabelControl;
        private System.Windows.Forms.Label videoCurrentProgressLabelControl;
        private System.Windows.Forms.Button exitVideoPlayerFormSimpleButton;
        private System.Windows.Forms.TrackBar volumeTrackBarControl;
        private System.Windows.Forms.Button volumeLouderFakeButton;
        private System.Windows.Forms.Panel videoEditorControlsPanel;
    }
}

