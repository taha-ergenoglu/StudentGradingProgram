using StudentGradingProgram.DataBaseOperations;
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
    public partial class ClassUserControl : UserControl
    {
        public ClassUserControl()
        {
            InitializeComponent();
        }


        ClassDataBaseOperations dbOperations = new ClassDataBaseOperations();


        private void ClassUserControl_Load(object sender, EventArgs e)
        {
            ClassDataGrid.DataSource = dbOperations.ClassList();
        }


        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ClassAddRadioButton.Checked == true)
            {
                ClassTextBox.PlaceholderText = "Eklenecek veriyi giriniz";
            }
            else if (ClassDeleteRadioButton.Checked == true)
            {
                ClassTextBox.PlaceholderText = "Silinecek verinin ID'si";
            }
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            if (ClassAddRadioButton.Checked == true)
            {
                dbOperations.ClassAdd(ClassTextBox.Text);
            }
        }
    }
}
