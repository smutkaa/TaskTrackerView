using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace TaskTrackerView
{
    public partial class FormEntry : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public FormEntry()
        {
            InitializeComponent();
        }

        private void buttonSingOut_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRegistration>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Успешно", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSingIn_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAuthorization>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Успешно", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
