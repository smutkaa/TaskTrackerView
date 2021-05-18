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
        public int? Idclient { set { idcl = value; } }
        private int? idcl;

        public FormComment(CommentLogic logicC)
        {
            InitializeComponent();
            comboBoxMark.Items.AddRange(new string[] { "Не нравится", "Нравится" });
            _logicC = logicC;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
           
            try
            {
                CommentBindingModel model = new CommentBindingModel
                {
                    Mark = Convert.ToString(comboBoxMark.SelectedValue),
                    Text = richTextBoxComment.Text,
                    ClientId = idcl,
                    TaskId = id
                };

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
