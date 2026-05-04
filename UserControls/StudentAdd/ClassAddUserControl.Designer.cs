namespace StudentGradingProgram
{
    partial class ClassUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassUserControl));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ClassDataGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            ClassAddRadioButton = new Guna.UI2.WinForms.Guna2RadioButton();
            ClassDeleteRadioButton = new Guna.UI2.WinForms.Guna2RadioButton();
            ApproveButton = new Guna.UI2.WinForms.Guna2CircleButton();
            ClassShadowPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            ClassTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)ClassDataGrid).BeginInit();
            ClassShadowPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ClassDataGrid
            // 
            ClassDataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            ClassDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ClassDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ClassDataGrid.ColumnHeadersHeight = 20;
            ClassDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            ClassDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            ClassDataGrid.GridColor = Color.FromArgb(231, 229, 255);
            ClassDataGrid.Location = new Point(8, 15);
            ClassDataGrid.Name = "ClassDataGrid";
            ClassDataGrid.ReadOnly = true;
            ClassDataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            ClassDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            ClassDataGrid.RowHeadersVisible = false;
            ClassDataGrid.Size = new Size(332, 207);
            ClassDataGrid.TabIndex = 0;
            ClassDataGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            ClassDataGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            ClassDataGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            ClassDataGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            ClassDataGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            ClassDataGrid.ThemeStyle.BackColor = Color.White;
            ClassDataGrid.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            ClassDataGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            ClassDataGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            ClassDataGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            ClassDataGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            ClassDataGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ClassDataGrid.ThemeStyle.HeaderStyle.Height = 20;
            ClassDataGrid.ThemeStyle.ReadOnly = true;
            ClassDataGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            ClassDataGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ClassDataGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            ClassDataGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            ClassDataGrid.ThemeStyle.RowsStyle.Height = 25;
            ClassDataGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            ClassDataGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // ClassAddRadioButton
            // 
            ClassAddRadioButton.AutoSize = true;
            ClassAddRadioButton.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            ClassAddRadioButton.CheckedState.BorderThickness = 0;
            ClassAddRadioButton.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            ClassAddRadioButton.CheckedState.InnerColor = Color.White;
            ClassAddRadioButton.CheckedState.InnerOffset = -4;
            ClassAddRadioButton.Font = new Font("Segoe UI", 12F);
            ClassAddRadioButton.Location = new Point(8, 228);
            ClassAddRadioButton.Name = "ClassAddRadioButton";
            ClassAddRadioButton.Size = new Size(91, 25);
            ClassAddRadioButton.TabIndex = 1;
            ClassAddRadioButton.Text = "Sınıf Ekle";
            ClassAddRadioButton.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ClassAddRadioButton.UncheckedState.BorderThickness = 2;
            ClassAddRadioButton.UncheckedState.FillColor = Color.Transparent;
            ClassAddRadioButton.UncheckedState.InnerColor = Color.Transparent;
            ClassAddRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // ClassDeleteRadioButton
            // 
            ClassDeleteRadioButton.AutoSize = true;
            ClassDeleteRadioButton.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            ClassDeleteRadioButton.CheckedState.BorderThickness = 0;
            ClassDeleteRadioButton.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            ClassDeleteRadioButton.CheckedState.InnerColor = Color.White;
            ClassDeleteRadioButton.CheckedState.InnerOffset = -4;
            ClassDeleteRadioButton.Font = new Font("Segoe UI", 12F);
            ClassDeleteRadioButton.Location = new Point(8, 259);
            ClassDeleteRadioButton.Name = "ClassDeleteRadioButton";
            ClassDeleteRadioButton.Size = new Size(80, 25);
            ClassDeleteRadioButton.TabIndex = 2;
            ClassDeleteRadioButton.Text = "Sınıf Sil";
            ClassDeleteRadioButton.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ClassDeleteRadioButton.UncheckedState.BorderThickness = 2;
            ClassDeleteRadioButton.UncheckedState.FillColor = Color.Transparent;
            ClassDeleteRadioButton.UncheckedState.InnerColor = Color.Transparent;
            ClassDeleteRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // ApproveButton
            // 
            ApproveButton.DisabledState.BorderColor = Color.DarkGray;
            ApproveButton.DisabledState.CustomBorderColor = Color.DarkGray;
            ApproveButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ApproveButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ApproveButton.FillColor = Color.Transparent;
            ApproveButton.Font = new Font("Segoe UI", 9F);
            ApproveButton.ForeColor = Color.White;
            ApproveButton.Image = (Image)resources.GetObject("ApproveButton.Image");
            ApproveButton.ImageSize = new Size(30, 30);
            ApproveButton.Location = new Point(305, 249);
            ApproveButton.Name = "ApproveButton";
            ApproveButton.ShadowDecoration.CustomizableEdges = customizableEdges1;
            ApproveButton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            ApproveButton.Size = new Size(35, 35);
            ApproveButton.TabIndex = 4;
            ApproveButton.Click += ApproveButton_Click;
            // 
            // ClassShadowPanel
            // 
            ClassShadowPanel.BackColor = Color.Transparent;
            ClassShadowPanel.Controls.Add(ClassTextBox);
            ClassShadowPanel.Controls.Add(ApproveButton);
            ClassShadowPanel.Controls.Add(ClassDataGrid);
            ClassShadowPanel.Controls.Add(ClassAddRadioButton);
            ClassShadowPanel.Controls.Add(ClassDeleteRadioButton);
            ClassShadowPanel.FillColor = Color.White;
            ClassShadowPanel.Location = new Point(0, 0);
            ClassShadowPanel.Margin = new Padding(0);
            ClassShadowPanel.Name = "ClassShadowPanel";
            ClassShadowPanel.Radius = 5;
            ClassShadowPanel.ShadowColor = Color.Black;
            ClassShadowPanel.Size = new Size(348, 316);
            ClassShadowPanel.TabIndex = 5;
            // 
            // ClassTextBox
            // 
            ClassTextBox.BorderRadius = 5;
            ClassTextBox.CustomizableEdges = customizableEdges2;
            ClassTextBox.DefaultText = "";
            ClassTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            ClassTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            ClassTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            ClassTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            ClassTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            ClassTextBox.Font = new Font("Segoe UI", 9F);
            ClassTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            ClassTextBox.Location = new Point(112, 246);
            ClassTextBox.Margin = new Padding(10);
            ClassTextBox.Name = "ClassTextBox";
            ClassTextBox.PlaceholderText = "";
            ClassTextBox.SelectedText = "";
            ClassTextBox.ShadowDecoration.CustomizableEdges = customizableEdges3;
            ClassTextBox.Size = new Size(166, 36);
            ClassTextBox.TabIndex = 6;
            // 
            // ClassUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(ClassShadowPanel);
            Name = "ClassUserControl";
            Size = new Size(348, 316);
            Load += ClassUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)ClassDataGrid).EndInit();
            ClassShadowPanel.ResumeLayout(false);
            ClassShadowPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2RadioButton ClassDeleteRadioButton;
        private Guna.UI2.WinForms.Guna2RadioButton ClassAddRadioButton;
        private Guna.UI2.WinForms.Guna2DataGridView ClassDataGrid;
        private Guna.UI2.WinForms.Guna2CircleButton ApproveButton;
        private Guna.UI2.WinForms.Guna2ShadowPanel ClassShadowPanel;
        private Guna.UI2.WinForms.Guna2TextBox ClassTextBox;
    }
}
