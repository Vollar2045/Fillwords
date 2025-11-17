namespace Fillwords
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            hintButton = new Button();
            resetLevelButton = new Button();
            lblLevel = new Label();
            lblHints = new Label();
            btnMenu = new Button();
            tableGrid = new TableLayoutPanel();
            SuspendLayout();
            // 
            // hintButton
            // 
            hintButton.Anchor = AnchorStyles.Top;
            hintButton.Font = new Font("Unispace", 18F, FontStyle.Bold | FontStyle.Italic);
            hintButton.Location = new Point(704, 55);
            hintButton.Name = "hintButton";
            hintButton.Size = new Size(243, 73);
            hintButton.TabIndex = 1;
            hintButton.TabStop = false;
            hintButton.Text = "Подсказка";
            hintButton.UseVisualStyleBackColor = true;
            // 
            // resetLevelButton
            // 
            resetLevelButton.Anchor = AnchorStyles.Top;
            resetLevelButton.Font = new Font("Unispace", 18F, FontStyle.Bold | FontStyle.Italic);
            resetLevelButton.Location = new Point(213, 55);
            resetLevelButton.Name = "resetLevelButton";
            resetLevelButton.Size = new Size(243, 73);
            resetLevelButton.TabIndex = 2;
            resetLevelButton.TabStop = false;
            resetLevelButton.Text = "Уровень заново";
            resetLevelButton.UseVisualStyleBackColor = true;
            // 
            // lblLevel
            // 
            lblLevel.Anchor = AnchorStyles.Top;
            lblLevel.AutoSize = true;
            lblLevel.Font = new Font("Unispace", 18F, FontStyle.Bold | FontStyle.Italic);
            lblLevel.Location = new Point(12, 77);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(165, 29);
            lblLevel.TabIndex = 5;
            lblLevel.Text = "Уровень: 1";
            // 
            // lblHints
            // 
            lblHints.Anchor = AnchorStyles.Top;
            lblHints.AutoSize = true;
            lblHints.Font = new Font("Unispace", 18F, FontStyle.Bold | FontStyle.Italic);
            lblHints.Location = new Point(953, 77);
            lblHints.Name = "lblHints";
            lblHints.Size = new Size(219, 29);
            lblHints.TabIndex = 6;
            lblHints.Text = "Подсказки: 3/3";
            // 
            // btnMenu
            // 
            btnMenu.Dock = DockStyle.Top;
            btnMenu.Font = new Font("Unispace", 18F, FontStyle.Bold | FontStyle.Italic);
            btnMenu.Location = new Point(0, 0);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(1184, 49);
            btnMenu.TabIndex = 8;
            btnMenu.TabStop = false;
            btnMenu.Text = "В меню";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // tableGrid
            // 
            tableGrid.Anchor = AnchorStyles.Top;
            tableGrid.BackColor = SystemColors.ActiveCaptionText;
            tableGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableGrid.ColumnCount = 1;
            tableGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableGrid.Location = new Point(120, 147);
            tableGrid.Name = "tableGrid";
            tableGrid.RowCount = 1;
            tableGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableGrid.Size = new Size(613, 618);
            tableGrid.TabIndex = 9;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 861);
            Controls.Add(tableGrid);
            Controls.Add(btnMenu);
            Controls.Add(lblHints);
            Controls.Add(lblLevel);
            Controls.Add(resetLevelButton);
            Controls.Add(hintButton);
            DoubleBuffered = true;
            MinimumSize = new Size(1200, 900);
            Name = "Game";
            StartPosition = FormStartPosition.Manual;
            Text = "Филворды";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button hintButton;
        private Button resetLevelButton;
        private Label lblLevel;
        private Label lblHints;
        private Button btnMenu;
        private TableLayoutPanel tableGrid;
    }
}
