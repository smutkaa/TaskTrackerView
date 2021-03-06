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
    public partial class FormMainClient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ProjectLogic _logicP;
        public int Id { set { id = value; } }
        private int? id;

        public FormMainClient(ProjectLogic logicP)
        {
            InitializeComponent();
            _logicP = logicP;
        }

        private void FormMainClient_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateProject>();
            form.IdClient = id;
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormTasks>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();  
                }
            }
        }
        private void LoadData()
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logicP.Read(new ProjectBindingModel { Clientid = id });
                    if (view != null)
                    {
                        dataGridView.DataSource = view;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView.Columns[4].Visible = false;
                        dataGridView.Columns[5].Visible = false;
                        dataGridView.Columns[6].Visible = false;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormCreateProject>();
                int idP = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                 form.Id = idP; 
                 form.IdClient = id; 
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReport>();
            form.IdClient = id; 
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
