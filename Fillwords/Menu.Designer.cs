namespace Fillwords
{
    partial class Menu
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
            btnPlay = new Button();
            btnExit = new Button();
            panelMain = new Panel();
            panelLevels = new Panel();
            flowLevels = new FlowLayoutPanel();
            btnBack = new Button();
            lblSelectLevel = new Label();
            panelMain.SuspendLayout();
            panelLevels.SuspendLayout();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(134, 80);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(300, 50);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Играть";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(134, 136);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(300, 50);
            btnExit.TabIndex = 1;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // panelMain
            // 
            panelMain.Anchor = AnchorStyles.Top;
            panelMain.Controls.Add(btnPlay);
            panelMain.Controls.Add(btnExit);
            panelMain.Location = new Point(237, 12);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(565, 264);
            panelMain.TabIndex = 2;
            // 
            // panelLevels
            // 
            panelLevels.Anchor = AnchorStyles.Top;
            panelLevels.Controls.Add(flowLevels);
            panelLevels.Controls.Add(btnBack);
            panelLevels.Controls.Add(lblSelectLevel);
            panelLevels.Location = new Point(237, 282);
            panelLevels.Name = "panelLevels";
            panelLevels.Size = new Size(536, 348);
            panelLevels.TabIndex = 3;
            panelLevels.Visible = false;
            // 
            // flowLevels
            // 
            flowLevels.Location = new Point(215, 71);
            flowLevels.Name = "flowLevels";
            flowLevels.Size = new Size(271, 199);
            flowLevels.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(32, 71);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 1;
            btnBack.Text = "button1";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // lblSelectLevel
            // 
            lblSelectLevel.AutoSize = true;
            lblSelectLevel.Location = new Point(69, 22);
            lblSelectLevel.Name = "lblSelectLevel";
            lblSelectLevel.Size = new Size(38, 15);
            lblSelectLevel.TabIndex = 0;
            lblSelectLevel.Text = "label1";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(panelLevels);
            Controls.Add(panelMain);
            MinimumSize = new Size(1000, 600);
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Филворды";
            panelMain.ResumeLayout(false);
            panelLevels.ResumeLayout(false);
            panelLevels.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPlay;
        private Button btnExit;
        private Panel panelMain;
        private Panel panelLevels;
        private FlowLayoutPanel flowLevels;
        private Button btnBack;
        private Label lblSelectLevel;
    }
}