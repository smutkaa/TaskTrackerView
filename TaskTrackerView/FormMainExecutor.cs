using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskTrackerBusinessLogic.BusinessLogics;

namespace TaskTrackerView
{
    public partial class FormMainExecutor : Form
    {
        private readonly ProjectLogic _logicP;
        public int Id { set { id = value; } }
        private int? id;

        public FormMainExecutor(ProjectLogic logicP)
        {
            InitializeComponent();
            _logicP = logicP;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }

        private void FormMainExecutor_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
                try
                {
                    var view = _logicP.Read(null);
                    if (view != null)
                    {
                        dataGridView.DataSource = view;
                        dataGridView.Columns[0].Visible = false;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
