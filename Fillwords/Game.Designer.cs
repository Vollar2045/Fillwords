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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            btnHint = new Button();
            lblLevel = new Label();
            lblHints = new Label();
            btnMenu = new Button();
            tableGrid = new TableLayoutPanel();
            SuspendLayout();
            // 
            // btnHint
            // 
            btnHint.Anchor = AnchorStyles.Top;
            btnHint.BackColor = Color.YellowGreen;
            btnHint.Cursor = Cursors.Hand;
            btnHint.FlatAppearance.BorderColor = Color.Purple;
            btnHint.FlatAppearance.BorderSize = 2;
            btnHint.FlatAppearance.MouseDownBackColor = Color.Purple;
            btnHint.FlatStyle = FlatStyle.Flat;
            btnHint.Font = new Font("Unispace", 18F, FontStyle.Bold | FontStyle.Italic);
            btnHint.Location = new Point(929, 55);
            btnHint.Name = "btnHint";
            btnHint.Size = new Size(243, 73);
            btnHint.TabIndex = 1;
            btnHint.TabStop = false;
            btnHint.Text = "Подсказка";
            btnHint.UseVisualStyleBackColor = true;
            btnHint.Click += btnHint_Click;
            // 
            // lblLevel
            // 
            lblLevel.Anchor = AnchorStyles.Top;
            lblLevel.AutoSize = true;
            lblLevel.BackColor = Color.Transparent;
            lblLevel.Font = new Font("Unispace", 18F, FontStyle.Bold | FontStyle.Italic);
            lblLevel.ForeColor = Color.Purple;
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
            lblHints.BackColor = Color.Transparent;
            lblHints.Font = new Font("Unispace", 18F, FontStyle.Bold | FontStyle.Italic);
            lblHints.ForeColor = Color.Purple;
            lblHints.Location = new Point(693, 77);
            lblHints.Name = "lblHints";
            lblHints.Size = new Size(219, 29);
            lblHints.TabIndex = 6;
            lblHints.Text = "Подсказки: 3/3";
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.YellowGreen;
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.Dock = DockStyle.Top;
            btnMenu.FlatAppearance.BorderColor = Color.Purple;
            btnMenu.FlatAppearance.BorderSize = 2;
            btnMenu.FlatAppearance.MouseDownBackColor = Color.Purple;
            btnMenu.FlatStyle = FlatStyle.Flat;
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
            BackgroundImage = Properties.Resources.cat_coffee_chill_pond_hd_wallpaper_uhdpaper_com_324_5_j;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1184, 861);
            Controls.Add(tableGrid);
            Controls.Add(btnMenu);
            Controls.Add(lblHints);
            Controls.Add(lblLevel);
            Controls.Add(btnHint);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1200, 900);
            Name = "Game";
            StartPosition = FormStartPosition.Manual;
            Text = "Филворды";
            KeyDown += Game_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnHint;
        private Label lblLevel;
        private Label lblHints;
        private Button btnMenu;
        private TableLayoutPanel tableGrid;
    }
}
