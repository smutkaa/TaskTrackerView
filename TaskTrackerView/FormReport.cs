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
    public partial class FormReport : Form
    {
        private readonly ReportLogic logic;
        public int? IdClient { set { idClient = value; } }
        private int? idClient;
        public FormReport(ReportLogic report)
        {
            logic = report;
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
     
            var list = logic.GetClientInfoFiltered(new ReportBindingModel
            {  
                ClientId = idClient,
                DateTo = dateTimePickerFrom.Value
            });
            if (list == null)
                return;
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
