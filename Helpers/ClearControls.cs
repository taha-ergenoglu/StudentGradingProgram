using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.Helpers
{
    internal class ClearControls
    {
        public void ClearControl(Control.ControlCollection allControls)
        {
            foreach (Control control in allControls)
            {
                if (control.HasChildren)
                {
                    ClearControl(control.Controls);
                }

                switch (control)
                {
                    case Guna2TextBox txt:
                        txt.Clear();
                        break;
                    case Guna2ComboBox combo:
                        if (combo.Items.Count > 0)
                            combo.SelectedIndex = 0;
                        break;
                    case Guna2RadioButton radio:
                        radio.Checked = false;
                        break;
                    case Guna2DateTimePicker dtp:
                        dtp.Value = DateTime.Now;
                        break;
                }
            }
        }
    }
}
