
namespace Alfred
{
    partial class Form1
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
            this.TimerSpeaking = new System.Windows.Forms.Timer(this.components);
            this.cmdList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // TimerSpeaking
            // 
            this.TimerSpeaking.Enabled = true;
            this.TimerSpeaking.Interval = 1000;
            this.TimerSpeaking.Tick += new System.EventHandler(this.TimerSpeaking_Tick);
            // 
            // cmdList
            // 
            this.cmdList.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdList.FormattingEnabled = true;
            this.cmdList.Location = new System.Drawing.Point(0, 0);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(335, 621);
            this.cmdList.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 621);
            this.Controls.Add(this.cmdList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerSpeaking;
        private System.Windows.Forms.ListBox cmdList;
    }
}

