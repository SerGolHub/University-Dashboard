using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Dasboard
{
    internal class FormLoader
    {
        public static void loadForm(Panel panel, Form form)
        {
            panel.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.TopMost = true;
            panel.Controls.Add(form);
            form.Show();
        }
    }
}
