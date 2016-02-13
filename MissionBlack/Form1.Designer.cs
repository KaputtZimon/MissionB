namespace MissionBlack
{
    partial class Mainframe
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
            this.components = new System.ComponentModel.Container();
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.TimerSeconds = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Enabled = true;
            this.GameLoop.Interval = 10;
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // TimerSeconds
            // 
            this.TimerSeconds.Enabled = true;
            this.TimerSeconds.Interval = 1000;
            this.TimerSeconds.Tick += new System.EventHandler(this.TimerSeconds_Tick);
            // 
            // Mainframe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::MissionBlack.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(502, 502);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(518, 541);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(518, 541);
            this.Name = "Mainframe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mission Black";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mainframe_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mainframe_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mainframe_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer GameLoop;
        private System.Windows.Forms.Timer TimerSeconds;
    }
}

