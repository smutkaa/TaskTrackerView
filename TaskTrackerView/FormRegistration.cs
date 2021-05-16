using System;
using System.Windows.Forms;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.BusinessLogics;
using TaskTrackerBusinessLogic.Enums;
using Unity;

namespace TaskTrackerView
{
    public partial class FormRegistration : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly CustomerLogic _logicC;
        private readonly UserLogic _logicU;
        public FormRegistration(CustomerLogic logicC, UserLogic logicU)
        {
            InitializeComponent();
            _logicC = logicC;
            _logicU = logicU;
            comboBoxRole.Items.AddRange(new string[] { "Заказчик", "Исполнитель" });
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPassword.Text) || comboBoxRole.SelectedValue != null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                UserBindingModel userModel = new UserBindingModel
                {
                    Login = textBoxEmail.Text,
                    Password = textBoxPassword.Text,
                    Role = (UserRole)Enum.Parse(typeof(UserRole), comboBoxRole.Text)
                };
                
                _logicU.CreateOrUpdate(userModel);
                var model = _logicU.Read(new UserBindingModel { Login = textBoxEmail.Text, Password = textBoxPassword.Text })?[0];

                int? idUser = model.Id;
                CustomerBindingModel clientModel = new CustomerBindingModel
                {
                    Name = textBoxFIO.Text,
                    Company = textBoxCompany.Text,
                    UserId = idUser
                };
                _logicC.CreateOrUpdate(clientModel);

                MessageBox.Show("Регистрация прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                var form = Container.Resolve<FormAuthorization>();
                form.ShowDialog();
                Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
