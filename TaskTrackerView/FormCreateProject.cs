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
    public partial class FormCreateProject : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private ProjectLogic _logicP { get; set; }
        private TaskLogic _logicT { get; set; }
        public int? Id { set { id = value; } }
        private int? id;
        public int? IdClient { set { idClient = value; } }
        private int? idClient;
        public Dictionary<int?, (string, DateTime, DateTime?, string, string, string)> Tasks;

        public FormCreateProject(TaskLogic logicT, ProjectLogic logicP)
        {
            InitializeComponent();
            _logicT = logicT;
            _logicP = logicP;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTaskAdd>();
            form.Id = id;
            form.ShowDialog();
            LoadData();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewTask.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormTaskAdd>();
               // form.Id = Convert.ToInt32(dataGridViewTask.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTask.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewTask.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        _logicT.Delete(new TaskBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
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
   
                ProjectBindingModel model = new ProjectBindingModel
                {
                    Id = id,
                    Name = textBoxName.Text,
                    Deadline = dateTimePicker.Value,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    Clientid = idClient
                };
                
                _logicP.CreateOrUpdate(model);
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
        private void LoadData()
        {

            try
            {
                if (Tasks != null)
                {
                    dataGridViewTask.Rows.Clear();
                    foreach (var pc in Tasks)
                    {
                        dataGridViewTask.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2, pc.Value.Item3, pc.Value.Item4, pc.Value.Item5 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormCreateProject_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var listP = _logicP.Read(new ProjectBindingModel { Id = id });
                    if (listP != null)
                    {
                        textBoxName.Text = listP[0].Name;
                        dateTimePicker.Value = listP[0].Deadline;
                        textBoxPrice.Text = Convert.ToString(listP[0].Price);
                        Tasks = listP[0].Tasks;
                        LoadData();
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
