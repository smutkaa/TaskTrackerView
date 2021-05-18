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
        private readonly TaskofprojectLogic _logicTP;
        public int? Id { set { id = value; } }
        private int? id;

        public FormTaskAdd(TaskLogic logicT, TaskofprojectLogic logicTP)
        {
            InitializeComponent();
            comboBoxPriority.Items.AddRange(new string[] { "Обычный", "Повышенный" });
            _logicT = logicT;
            _logicTP = logicTP;
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
                TaskBindingModel taskModel = new TaskBindingModel
                {
                    Id=id,
                    Name = textBoxName.Text,
                    StartDate = dateTimePickerFrom.Value,
                    EndDate = dateTimePickerTo.Value,
                    Priority = comboBoxPriority.Text,
                    Text= richTextBoxComment.Text
                };
                _logicT.CreateOrUpdate(taskModel);

                var model = _logicT.Read(taskModel);

                int ? IdTask= model[0].Id;

                TaskofprojectBindingModel taskofprojectModel = new TaskofprojectBindingModel
                {
                   Projectid=id,
                   Taskid = IdTask
                };
                _logicTP.CreateOrUpdate(taskofprojectModel);
              
                MessageBox.Show("Регистрация прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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
                    if (listP[0] != null)
                    {
                        textBoxName.Text = listP[0].Name;
                        dateTimePickerFrom.Value = listP[0].StartDate.Date;
                        dateTimePickerTo.Value = listP[0].EndDate.Date;
                        comboBoxPriority.Text = listP[0].Priority;
                        richTextBoxComment.Text = listP[0].Text;
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
