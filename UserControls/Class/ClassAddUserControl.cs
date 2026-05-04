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
    public partial class ClassAddUserControl : UserControl
    {
        public ClassAddUserControl()
        {
            InitializeComponent();
        }


        ClassDataBaseOperations dbOperations = new ClassDataBaseOperations();


        private void ClassUserControl_Load(object sender, EventArgs e)
        {
            FillDataGrid();
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
            if (!string.IsNullOrEmpty(ClassTextBox.Text))
            {
                if (ClassAddRadioButton.Checked == true)
                {
                    bool isSuccess = dbOperations.ClassAdd(ClassTextBox.Text);
                    if (isSuccess)
                    {
                        MessageBox.Show("Sınıf başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sınıf kaydederken hata meydana geldi.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (ClassDeleteRadioButton.Checked == true)
                {
                    if (short.TryParse(ClassTextBox.Text, out short classId))
                    {
                        dbOperations.ClassRemove(classId);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen silmek için geçerli bir ID (Sayı) giriniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Hatalıysa aşağıdaki FillDataGrid'i çalıştırmadan işlemi kes
                    }
                }
                ClassTextBox.Clear();
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("Kutucuk boş geçilemez", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void FillDataGrid()
        {
            var classList = dbOperations.ClassList();
            ClassDataGrid.DataSource = classList;
            ClassDataGrid.Columns["Students"].Visible = false;
        }
    }
}
