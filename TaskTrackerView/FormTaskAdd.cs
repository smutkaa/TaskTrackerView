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

namespace TaskTrackerView
{
    public partial class FormTaskAdd : Form
    {
        private readonly TaskLogic _logicT;
        public int? Id { set { id = value; } }
        private int? id;

        public FormTaskAdd(TaskLogic logicT)
        {
            InitializeComponent();
            comboBoxPriority.Items.AddRange(new string[] { "Обычный", "Повышенный" });
            _logicT = logicT;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Введите название проекта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                TaskBindingModel model = new TaskBindingModel
                {
                    Name = textBoxName.Text,
                   
                };
                if (id.HasValue)
                {
                    model.Id = id;
                }
                _logicT.CreateOrUpdate(model);
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

        private void FormTaskAdd_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var listP = _logicT.Read(new TaskBindingModel { Id = id });
                    if (listP != null)
                    {
                        textBoxName.Text = listP[0].Name;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
    }
}
