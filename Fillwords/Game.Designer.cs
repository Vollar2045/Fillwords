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
            listWords = new ListBox();
            hintButton = new Button();
            resetLevelButton = new Button();
            lblLevel = new Label();
            lblHints = new Label();
            lblWords = new Label();
            btnMenu = new Button();
            tableGrid = new TableLayoutPanel();
            SuspendLayout();
            // 
            // listWords
            // 
            listWords.BorderStyle = BorderStyle.FixedSingle;
            listWords.FormattingEnabled = true;
            listWords.ItemHeight = 15;
            listWords.Location = new Point(637, 119);
            listWords.Name = "listWords";
            listWords.SelectionMode = SelectionMode.None;
            listWords.Size = new Size(335, 347);
            listWords.TabIndex = 0;
            // 
            // hintButton
            // 
            hintButton.Location = new Point(106, 34);
            hintButton.Name = "hintButton";
            hintButton.Size = new Size(166, 23);
            hintButton.TabIndex = 1;
            hintButton.Text = "Подсказка";
            hintButton.UseVisualStyleBackColor = true;
            // 
            // resetLevelButton
            // 
            resetLevelButton.Location = new Point(106, 5);
            resetLevelButton.Name = "resetLevelButton";
            resetLevelButton.Size = new Size(166, 23);
            resetLevelButton.TabIndex = 2;
            resetLevelButton.Text = "Уровень заново";
            resetLevelButton.UseVisualStyleBackColor = true;
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(22, 9);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(65, 15);
            lblLevel.TabIndex = 5;
            lblLevel.Text = "Уровень: 1";
            // 
            // lblHints
            // 
            lblHints.AutoSize = true;
            lblHints.Location = new Point(12, 37);
            lblHints.Name = "lblHints";
            lblHints.Size = new Size(88, 15);
            lblHints.TabIndex = 6;
            lblHints.Text = "Подсказки: 3/3";
            // 
            // lblWords
            // 
            lblWords.AutoSize = true;
            lblWords.Location = new Point(637, 101);
            lblWords.Name = "lblWords";
            lblWords.Size = new Size(108, 15);
            lblWords.TabIndex = 7;
            lblWords.Text = "Слова для поиска:";
            // 
            // btnMenu
            // 
            btnMenu.Location = new Point(806, 12);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(166, 23);
            btnMenu.TabIndex = 8;
            btnMenu.Text = "В меню";
            btnMenu.UseVisualStyleBackColor = true;
            // 
            // tableGrid
            // 
            tableGrid.ColumnCount = 2;
            tableGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableGrid.Location = new Point(85, 101);
            tableGrid.Name = "tableGrid";
            tableGrid.RowCount = 2;
            tableGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableGrid.Size = new Size(525, 430);
            tableGrid.TabIndex = 9;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(tableGrid);
            Controls.Add(btnMenu);
            Controls.Add(lblWords);
            Controls.Add(lblHints);
            Controls.Add(lblLevel);
            Controls.Add(resetLevelButton);
            Controls.Add(hintButton);
            Controls.Add(listWords);
            DoubleBuffered = true;
            MinimumSize = new Size(1000, 600);
            Name = "Game";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Филворды";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listWords;
        private Button hintButton;
        private Button resetLevelButton;
        private Label lblLevel;
        private Label lblHints;
        private Label lblWords;
        private Button btnMenu;
        private TableLayoutPanel tableGrid;
    }
}
