namespace StudentGradingProgram
{
    partial class Main
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            StudentButton = new Guna.UI2.WinForms.Guna2Button();
            ExamButton = new Guna.UI2.WinForms.Guna2Button();
            panelSideMenu = new Guna.UI2.WinForms.Guna2ShadowPanel();
            ClassButton = new Guna.UI2.WinForms.Guna2Button();
            SideBarHamburgerButton = new Guna.UI2.WinForms.Guna2ImageButton();
            MainPanel = new Guna.UI2.WinForms.Guna2Panel();
            sideBarTimer = new System.Windows.Forms.Timer(components);
            ExamContextMenu = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            sınavEkleToolStripMenuItem = new ToolStripMenuItem();
            sınavlarıListeleToolStripMenuItem = new ToolStripMenuItem();
            StudentContextMenu = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            öğrenciEkleToolStripMenuItem = new ToolStripMenuItem();
            öğrenciListeleToolStripMenuItem = new ToolStripMenuItem();
            ClassContextMenu = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            sınıfEkleToolStripMenuItem = new ToolStripMenuItem();
            sınıfListeleToolStripMenuItem = new ToolStripMenuItem();
            panelSideMenu.SuspendLayout();
            ExamContextMenu.SuspendLayout();
            StudentContextMenu.SuspendLayout();
            ClassContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // StudentButton
            // 
            StudentButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            StudentButton.BackColor = Color.Transparent;
            StudentButton.BorderColor = Color.FromArgb(73, 80, 87);
            StudentButton.BorderRadius = 8;
            StudentButton.BorderThickness = 1;
            StudentButton.Cursor = Cursors.Hand;
            StudentButton.CustomizableEdges = customizableEdges1;
            StudentButton.DisabledState.BorderColor = Color.DarkGray;
            StudentButton.DisabledState.CustomBorderColor = Color.DarkGray;
            StudentButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            StudentButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            StudentButton.FillColor = Color.FromArgb(52, 58, 64);
            StudentButton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            StudentButton.ForeColor = Color.FromArgb(248, 249, 250);
            StudentButton.Image = (Image)resources.GetObject("StudentButton.Image");
            StudentButton.ImageAlign = HorizontalAlignment.Right;
            StudentButton.ImageSize = new Size(30, 30);
            StudentButton.Location = new Point(12, 91);
            StudentButton.Margin = new Padding(0);
            StudentButton.Name = "StudentButton";
            StudentButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            StudentButton.Size = new Size(171, 45);
            StudentButton.TabIndex = 1;
            StudentButton.Text = "Öğrenci İşlemleri";
            StudentButton.TextAlign = HorizontalAlignment.Left;
            StudentButton.Click += StudentButton_Click;
            // 
            // ExamButton
            // 
            ExamButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ExamButton.BackColor = Color.Transparent;
            ExamButton.BorderColor = Color.FromArgb(73, 80, 87);
            ExamButton.BorderRadius = 8;
            ExamButton.BorderThickness = 1;
            ExamButton.Cursor = Cursors.Hand;
            ExamButton.CustomizableEdges = customizableEdges3;
            ExamButton.DisabledState.BorderColor = Color.DarkGray;
            ExamButton.DisabledState.CustomBorderColor = Color.DarkGray;
            ExamButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ExamButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ExamButton.FillColor = Color.FromArgb(52, 58, 64);
            ExamButton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            ExamButton.ForeColor = Color.FromArgb(248, 249, 250);
            ExamButton.Image = (Image)resources.GetObject("ExamButton.Image");
            ExamButton.ImageAlign = HorizontalAlignment.Right;
            ExamButton.ImageSize = new Size(30, 30);
            ExamButton.ImeMode = ImeMode.NoControl;
            ExamButton.Location = new Point(12, 40);
            ExamButton.Margin = new Padding(0);
            ExamButton.Name = "ExamButton";
            ExamButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            ExamButton.Size = new Size(171, 45);
            ExamButton.TabIndex = 0;
            ExamButton.Text = "Sınav İşlemleri";
            ExamButton.TextAlign = HorizontalAlignment.Left;
            ExamButton.Click += ExamButton_Click;
            // 
            // panelSideMenu
            // 
            panelSideMenu.BackColor = Color.Transparent;
            panelSideMenu.Controls.Add(ClassButton);
            panelSideMenu.Controls.Add(SideBarHamburgerButton);
            panelSideMenu.Controls.Add(StudentButton);
            panelSideMenu.Controls.Add(ExamButton);
            panelSideMenu.Dock = DockStyle.Left;
            panelSideMenu.FillColor = Color.FromArgb(33, 37, 41);
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.Margin = new Padding(0);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Radius = 5;
            panelSideMenu.ShadowColor = Color.Black;
            panelSideMenu.Size = new Size(196, 860);
            panelSideMenu.TabIndex = 1;
            // 
            // ClassButton
            // 
            ClassButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ClassButton.BackColor = Color.Transparent;
            ClassButton.BorderColor = Color.FromArgb(73, 80, 87);
            ClassButton.BorderRadius = 8;
            ClassButton.BorderThickness = 1;
            ClassButton.Cursor = Cursors.Hand;
            ClassButton.CustomizableEdges = customizableEdges5;
            ClassButton.DisabledState.BorderColor = Color.DarkGray;
            ClassButton.DisabledState.CustomBorderColor = Color.DarkGray;
            ClassButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ClassButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ClassButton.FillColor = Color.FromArgb(52, 58, 64);
            ClassButton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            ClassButton.ForeColor = Color.FromArgb(248, 249, 250);
            ClassButton.Image = (Image)resources.GetObject("ClassButton.Image");
            ClassButton.ImageAlign = HorizontalAlignment.Right;
            ClassButton.ImageSize = new Size(30, 30);
            ClassButton.Location = new Point(12, 142);
            ClassButton.Margin = new Padding(0);
            ClassButton.Name = "ClassButton";
            ClassButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            ClassButton.Size = new Size(171, 45);
            ClassButton.TabIndex = 3;
            ClassButton.Text = "Sınıf İşlemleri";
            ClassButton.TextAlign = HorizontalAlignment.Left;
            ClassButton.Click += ClassButton_Click;
            // 
            // SideBarHamburgerButton
            // 
            SideBarHamburgerButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SideBarHamburgerButton.CheckedState.ImageSize = new Size(64, 64);
            SideBarHamburgerButton.Cursor = Cursors.Hand;
            SideBarHamburgerButton.HoverState.ImageSize = new Size(27, 27);
            SideBarHamburgerButton.Image = (Image)resources.GetObject("SideBarHamburgerButton.Image");
            SideBarHamburgerButton.ImageOffset = new Point(0, 0);
            SideBarHamburgerButton.ImageRotate = 0F;
            SideBarHamburgerButton.ImageSize = new Size(25, 25);
            SideBarHamburgerButton.Location = new Point(155, 10);
            SideBarHamburgerButton.Name = "SideBarHamburgerButton";
            SideBarHamburgerButton.PressedState.ImageSize = new Size(29, 29);
            SideBarHamburgerButton.ShadowDecoration.CustomizableEdges = customizableEdges7;
            SideBarHamburgerButton.Size = new Size(27, 27);
            SideBarHamburgerButton.TabIndex = 2;
            SideBarHamburgerButton.Click += SideBarHamburgerButton_Click;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = SystemColors.ButtonFace;
            MainPanel.CustomizableEdges = customizableEdges8;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(196, 0);
            MainPanel.Margin = new Padding(0);
            MainPanel.Name = "MainPanel";
            MainPanel.ShadowDecoration.CustomizableEdges = customizableEdges9;
            MainPanel.Size = new Size(1183, 860);
            MainPanel.TabIndex = 2;
            // 
            // sideBarTimer
            // 
            sideBarTimer.Interval = 5;
            sideBarTimer.Tick += sideBarTimer_Tick;
            // 
            // ExamContextMenu
            // 
            ExamContextMenu.Items.AddRange(new ToolStripItem[] { sınavEkleToolStripMenuItem, sınavlarıListeleToolStripMenuItem });
            ExamContextMenu.Name = "ExamContextMenu";
            ExamContextMenu.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            ExamContextMenu.RenderStyle.BorderColor = Color.Gainsboro;
            ExamContextMenu.RenderStyle.ColorTable = null;
            ExamContextMenu.RenderStyle.RoundedEdges = true;
            ExamContextMenu.RenderStyle.SelectionArrowColor = Color.White;
            ExamContextMenu.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            ExamContextMenu.RenderStyle.SelectionForeColor = Color.White;
            ExamContextMenu.RenderStyle.SeparatorColor = Color.Gainsboro;
            ExamContextMenu.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            ExamContextMenu.Size = new Size(181, 70);
            // 
            // sınavEkleToolStripMenuItem
            // 
            sınavEkleToolStripMenuItem.Name = "sınavEkleToolStripMenuItem";
            sınavEkleToolStripMenuItem.Size = new Size(180, 22);
            sınavEkleToolStripMenuItem.Text = "Sınav Ekle";
            sınavEkleToolStripMenuItem.Click += sınavEkleToolStripMenuItem_Click;
            // 
            // sınavlarıListeleToolStripMenuItem
            // 
            sınavlarıListeleToolStripMenuItem.Name = "sınavlarıListeleToolStripMenuItem";
            sınavlarıListeleToolStripMenuItem.Size = new Size(180, 22);
            sınavlarıListeleToolStripMenuItem.Text = "Sınavları Listele";
            // 
            // StudentContextMenu
            // 
            StudentContextMenu.Items.AddRange(new ToolStripItem[] { öğrenciEkleToolStripMenuItem, öğrenciListeleToolStripMenuItem });
            StudentContextMenu.Name = "StudentContextMenu";
            StudentContextMenu.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            StudentContextMenu.RenderStyle.BorderColor = Color.Gainsboro;
            StudentContextMenu.RenderStyle.ColorTable = null;
            StudentContextMenu.RenderStyle.RoundedEdges = true;
            StudentContextMenu.RenderStyle.SelectionArrowColor = Color.White;
            StudentContextMenu.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            StudentContextMenu.RenderStyle.SelectionForeColor = Color.White;
            StudentContextMenu.RenderStyle.SeparatorColor = Color.Gainsboro;
            StudentContextMenu.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            StudentContextMenu.Size = new Size(153, 48);
            // 
            // öğrenciEkleToolStripMenuItem
            // 
            öğrenciEkleToolStripMenuItem.Name = "öğrenciEkleToolStripMenuItem";
            öğrenciEkleToolStripMenuItem.Size = new Size(152, 22);
            öğrenciEkleToolStripMenuItem.Text = "Öğrenci Ekle";
            öğrenciEkleToolStripMenuItem.Click += öğrenciEkleToolStripMenuItem_Click;
            // 
            // öğrenciListeleToolStripMenuItem
            // 
            öğrenciListeleToolStripMenuItem.Name = "öğrenciListeleToolStripMenuItem";
            öğrenciListeleToolStripMenuItem.Size = new Size(152, 22);
            öğrenciListeleToolStripMenuItem.Text = "Öğrenci Listele";
            öğrenciListeleToolStripMenuItem.Click += öğrenciListeleToolStripMenuItem_Click;
            // 
            // ClassContextMenu
            // 
            ClassContextMenu.Items.AddRange(new ToolStripItem[] { sınıfEkleToolStripMenuItem, sınıfListeleToolStripMenuItem });
            ClassContextMenu.Name = "ClassContextMenu";
            ClassContextMenu.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            ClassContextMenu.RenderStyle.BorderColor = Color.Gainsboro;
            ClassContextMenu.RenderStyle.ColorTable = null;
            ClassContextMenu.RenderStyle.RoundedEdges = true;
            ClassContextMenu.RenderStyle.SelectionArrowColor = Color.White;
            ClassContextMenu.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            ClassContextMenu.RenderStyle.SelectionForeColor = Color.White;
            ClassContextMenu.RenderStyle.SeparatorColor = Color.Gainsboro;
            ClassContextMenu.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            ClassContextMenu.Size = new Size(134, 48);
            // 
            // sınıfEkleToolStripMenuItem
            // 
            sınıfEkleToolStripMenuItem.Name = "sınıfEkleToolStripMenuItem";
            sınıfEkleToolStripMenuItem.Size = new Size(133, 22);
            sınıfEkleToolStripMenuItem.Text = "Sınıf Ekle";
            sınıfEkleToolStripMenuItem.Click += sınıfEkleToolStripMenuItem_Click;
            // 
            // sınıfListeleToolStripMenuItem
            // 
            sınıfListeleToolStripMenuItem.Name = "sınıfListeleToolStripMenuItem";
            sınıfListeleToolStripMenuItem.Size = new Size(133, 22);
            sınıfListeleToolStripMenuItem.Text = "Sınıf Listele";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1379, 860);
            Controls.Add(MainPanel);
            Controls.Add(panelSideMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Main";
            Text = "Main";
            panelSideMenu.ResumeLayout(false);
            ExamContextMenu.ResumeLayout(false);
            StudentContextMenu.ResumeLayout(false);
            ClassContextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button StudentButton;
        private Guna.UI2.WinForms.Guna2Button ExamButton;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelSideMenu;
        private Guna.UI2.WinForms.Guna2Panel MainPanel;
        private System.Windows.Forms.Timer sideBarTimer;
        private Guna.UI2.WinForms.Guna2ImageButton SideBarHamburgerButton;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip ExamContextMenu;
        private ToolStripMenuItem sınavEkleToolStripMenuItem;
        private ToolStripMenuItem sınavlarıListeleToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip StudentContextMenu;
        private ToolStripMenuItem öğrenciEkleToolStripMenuItem;
        private ToolStripMenuItem öğrenciListeleToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button ClassButton;
        private ToolStripMenuItem toolStripMenuItem1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip ClassContextMenu;
        private ToolStripMenuItem sınıfEkleToolStripMenuItem;
        private ToolStripMenuItem sınıfListeleToolStripMenuItem;
    }
}