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
            lblSelectLevel = new Label();
            btnBack = new Button();
            flowLevels = new FlowLayoutPanel();
            panelMain.SuspendLayout();
            panelLevels.SuspendLayout();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Anchor = AnchorStyles.Top;
            btnPlay.Font = new Font("Unispace", 36F, FontStyle.Bold | FontStyle.Italic);
            btnPlay.Location = new Point(69, 25);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(400, 100);
            btnPlay.TabIndex = 0;
            btnPlay.TabStop = false;
            btnPlay.Text = "Играть";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top;
            btnExit.Font = new Font("Unispace", 36F, FontStyle.Bold | FontStyle.Italic);
            btnExit.Location = new Point(69, 131);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(400, 100);
            btnExit.TabIndex = 1;
            btnExit.TabStop = false;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // panelMain
            // 
            panelMain.Anchor = AnchorStyles.Top;
            panelMain.Controls.Add(btnPlay);
            panelMain.Controls.Add(btnExit);
            panelMain.Location = new Point(325, 240);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(565, 264);
            panelMain.TabIndex = 2;
            // 
            // panelLevels
            // 
            panelLevels.Anchor = AnchorStyles.Top;
            panelLevels.Controls.Add(lblSelectLevel);
            panelLevels.Controls.Add(btnBack);
            panelLevels.Controls.Add(flowLevels);
            panelLevels.Location = new Point(140, 13);
            panelLevels.Name = "panelLevels";
            panelLevels.Size = new Size(941, 599);
            panelLevels.TabIndex = 3;
            panelLevels.Visible = false;
            // 
            // lblSelectLevel
            // 
            lblSelectLevel.AutoSize = true;
            lblSelectLevel.Font = new Font("Unispace", 15.7499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSelectLevel.Location = new Point(330, 8);
            lblSelectLevel.Name = "lblSelectLevel";
            lblSelectLevel.Size = new Size(220, 25);
            lblSelectLevel.TabIndex = 0;
            lblSelectLevel.Text = "Выберите уровень";
            // 
            // btnBack
            // 
            btnBack.Dock = DockStyle.Bottom;
            btnBack.Font = new Font("Unispace", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(0, 523);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(941, 76);
            btnBack.TabIndex = 1;
            btnBack.TabStop = false;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // flowLevels
            // 
            flowLevels.Location = new Point(12, 39);
            flowLevels.Name = "flowLevels";
            flowLevels.Size = new Size(920, 436);
            flowLevels.TabIndex = 2;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 861);
            Controls.Add(panelLevels);
            Controls.Add(panelMain);
            DoubleBuffered = true;
            MinimumSize = new Size(1200, 900);
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