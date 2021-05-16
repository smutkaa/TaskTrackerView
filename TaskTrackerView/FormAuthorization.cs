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
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.BusinessLogics;
using TaskTrackerBusinessLogic.Enums;


namespace TaskTrackerView
{
    public partial class FormAuthorization : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly UserLogic _logicU;
        private readonly CustomerLogic _logicC;
        public FormAuthorization(UserLogic logicU, CustomerLogic logicC)
        {
            InitializeComponent();
            _logicU = logicU;
            _logicC = logicC;
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            var user = _logicU.Read(new UserBindingModel { Login = textBoxEmail.Text, Password = textBoxPassword.Text })?[0];
            if (user == null)
            {
                MessageBox.Show("Неверный Email или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Program.Client = user;

            else if (user.Role == UserRole.Заказчик)
            {
                var forms = Container.Resolve<FormMainClient>();
                var clientL = _logicC.Read(new CustomerBindingModel { UserId = user.Id });
                forms.Id = clientL[0].Id;
                forms.ShowDialog();  
            }
            else if (user.Role == UserRole.Исполнитель)
            {
                
                var forms = Container.Resolve<FormMainExecutor>();
                forms.ShowDialog();
            }
           
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
