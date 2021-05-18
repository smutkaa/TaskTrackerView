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
    public partial class FormTasks : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly TaskLogic _logicT;
        private readonly ProjectLogic _logicP;
        private int? id;
        public Dictionary<int?, (string, DateTime, DateTime, string, string, string)> Tasks;
        public FormTasks(TaskLogic logicT, ProjectLogic logicP)
        {
            InitializeComponent();
            _logicT = logicT;
            _logicP = logicP;
        }

        private void buttonComment_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormComment>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Регистрация прошло успешно", "Сообщение",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormTasks_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var listP = _logicP.Read(new ProjectBindingModel { Id = id });
                    if (listP != null)
                    {
                            Tasks = listP[0].Tasks;
                           
                        try
                        {
                            if (Tasks != null)
                            {
                                dataGridView.Rows.Clear();
                                foreach (var pc in Tasks)
                                {
                                    dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2, pc.Value.Item3, pc.Value.Item4, pc.Value.Item5 });
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
