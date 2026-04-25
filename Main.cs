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

        public void ShowContextMenu(Guna2ContextMenuStrip contextMenu, Guna2Button button, int locationY)
        {
            contextMenu.Show(button, button.Width + 10, locationY);
        }


        private void ExamButton_Click(object sender, EventArgs e)
        {
            ShowContextMenu(ExamContextMenu, ExamButton, 2);
        }

        private void StudentButton_Click(object sender, EventArgs e)
        {
            ShowContextMenu(StudentContextMenu, StudentButton, 2);
        }


        private void ClassButton_Click(object sender, EventArgs e)
        {
            ShowContextMenu(ClassContextMenu, ClassButton, 2);
        }


        public void PanelControl(UserControl control, DockStyle style)
        {
            control.Dock = style;

            if (control.Name == "StudentEditUserControl")
                control.Location = new Point(585, 160);
            else
                MainPanel.Controls.Clear();
            MainPanel.Controls.Add(control);
            control.BringToFront();

        }


        private void sınıfEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelControl(new ClassUserControl(), DockStyle.Left);
        }


        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelControl(new StundetAddUserControl(), DockStyle.Left);
        }


        private void öğrenciListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sideBarExpand)
                SideBarHamburgerButton_Click(sender, e);
            PanelControl(new StudentListUserControl(), DockStyle.Fill);
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
                PanelControl(editUserControl, DockStyle.None);
            }
        }

        private void sınavEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelControl(new ExamAddUserControll(), DockStyle.Fill);
        }
    }
}