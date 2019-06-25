using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MpvWinFormPlayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "mp4 files (*.mp4)|*.mp4",
            };
            if(openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName is string)
            {
                Application.Run(new VideoPlayerForm(openFileDialog.FileName));
            }
        }
    }
}
