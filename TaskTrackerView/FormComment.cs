using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.BusinessLogics;
using Unity;

namespace TaskTrackerView
{
    public partial class FormComment : Form
    {
        private readonly CommentLogic _logicC;
        public int? Id { set { id = value; } }
        private int? id;

        public FormComment(CommentLogic logicC)
        {
            InitializeComponent();
            comboBoxMark.Items.AddRange(new string[] { "Не нравится", "Нравится" });
            _logicC = logicC;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            /*if (string.IsNullOrEmpty()
            {
                MessageBox.Show("Введите название проекта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            try
            {
                CommentBindingModel model = new CommentBindingModel
                {
                   

                };
                if (id.HasValue)
                {
                    model.Id = id;
                }
                _logicC.CreateOrUpdate(model);
                MessageBox.Show("Успешно", "Сохранено",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
