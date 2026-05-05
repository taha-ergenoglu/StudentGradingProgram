using Guna.UI2.WinForms;
using StudentGradingProgram.UserControls;
using StudentGradingProgram.UserControls.Exam;
using StudentGradingProgram.UserControls.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentGradingProgram
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            //Butonların tag larına açmaları gereken menüler atanır
            ExamButton.Tag = ExamContextMenu;
            StudentButton.Tag = StudentContextMenu;
            ClassButton.Tag = ClassContextMenu;
        }


        bool sideBarExpand = true;//Panelin açık kapalılık durumu
        int sideBarMaxWidth = 196;
        int sideBarMinWidth = 85;
        string examButtonText = "Sınav İşlemleri";
        string studentButtonText = "Öğrenci İşlemleri";
        string classButtonText = "Sınıf İşlemleri";
        private void sideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand)
            {
                ExamButton.Text = "";
                StudentButton.Text = "";
                ClassButton.Text = "";
                panelSideMenu.Width -= 10;
                if (panelSideMenu.Width <= sideBarMinWidth)
                {

                    sideBarExpand = false;
                    sideBarTimer.Stop();
                }
            }
            else
            {
                panelSideMenu.Width += 10;
                if (panelSideMenu.Width >= sideBarMaxWidth)
                {
                    ExamButton.Text = examButtonText;
                    StudentButton.Text = studentButtonText;
                    ClassButton.Text = classButtonText;
                    sideBarExpand = true;
                    sideBarTimer.Stop();
                }
            }

        }

        private void SideBarHamburgerButton_Click(object sender, EventArgs e)
        {
            sideBarTimer.Start();
        }

        public void ShowContextMenu(Guna2ContextMenuStrip contextMenu, Guna2Button button)
        {
            contextMenu.Show(button, button.Width + 10, 2);
        }


        private void CommonContextMenu_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            Guna2ContextMenuStrip contextMenu = clickedButton?.Tag as Guna2ContextMenuStrip;
            if (contextMenu != null && clickedButton != null)
            {
                ShowContextMenu(contextMenu, clickedButton);
            }
        }


        public void PanelControl(UserControl control, DockStyle style, int x, int y)
        {
            control.Dock = style;

            if (control.Name == "StudentEditUserControl")
                control.Location = new Point(x, y);
            else
                MainPanel.Controls.Clear();
            MainPanel.Controls.Add(control);
            control.BringToFront();

        }


        private void sınıfEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelControl(new ClassAddUserControl(), DockStyle.Left, 0, 0);
        }


        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelControl(new StundetAddUserControl(), DockStyle.Left, 0, 0);
        }


        private void öğrenciListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sideBarExpand)
                SideBarHamburgerButton_Click(sender, e);
            PanelControl(new StudentListUserControl(), DockStyle.Fill, 0, 0);
        }


        public void ShowSelectedStudentData(int selectedStudentId, string processDetail)
        {
            if (processDetail == "StudentEdit")
            {
                StudentEditUserControl editUserControl = new StudentEditUserControl();
                editUserControl.StudentID = selectedStudentId;
                editUserControl.StudentFind();
                editUserControl.IslemBitti += (sender, args) =>
                {
                    // 1. İşi biten düzenleme panelini MainPanel'den kaldır ve bellekten sil
                    MainPanel.Controls.Remove(editUserControl);
                    editUserControl.Dispose();

                    // 2. MainPanel'in içinde altta bekleyen Öğrenci Listesini bul ve yenile
                    foreach (Control item in MainPanel.Controls)
                    {
                        if (item is StudentListUserControl listPanel)
                        {
                            listPanel.FillDataGrid(); // Sizin listenizi yenileyen ana metodunuz
                            break;
                        }
                    }
                };
                PanelControl(editUserControl, DockStyle.None, 585, 106);
            }
        }


        public void ShowSelectedExam(int selectedExamId)
        {
            PanelControl(new ExamEditDeleteUserControl(), DockStyle.Fill, 0, 0);
        }


        private void sınavEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sideBarExpand)
                SideBarHamburgerButton_Click(sender, e);
            PanelControl(new ExamScoreEntryUserControll(), DockStyle.Fill, 0, 0);
        }

        private void sınavlarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sideBarExpand)
                SideBarHamburgerButton_Click(sender, e);
            PanelControl(new ExamListUserControl(), DockStyle.Fill, 0, 0);
        }
    }
}