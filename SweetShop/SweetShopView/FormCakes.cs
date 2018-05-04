using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SweetShopView
{
    public partial class FormCakes : Form
    {

        public FormCakes()
        {
            InitializeComponent();
        }

        private void FormCakes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<CakeViewModel> list = Task.Run(() => APICustomer.GetRequestData<List<CakeViewModel>>("api/Cake/GetList")).Result;
                if (list != null)
                {
                    FCakeSList.DataSource = list;
                    FCakeSList.Columns[0].Visible = false;
                    FCakeSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCakeSAdd_Click(object sender, EventArgs e)
        {
            var form = new FormCake();
            form.ShowDialog();
        }

        private void FCakeSUpd_Click(object sender, EventArgs e)
        {
            if (FCakeSList.SelectedRows.Count == 1)
            {
                var form = new FormCake
                {
                    Id = Convert.ToInt32(FCakeSList.SelectedRows[0].Cells[0].Value)
                };
                form.ShowDialog();
            }
        }

        private void FCakeSDel_Click(object sender, EventArgs e)
        {
            if (FCakeSList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(FCakeSList.SelectedRows[0].Cells[0].Value);

                    Task task = Task.Run(() => APICustomer.PostRequestData("api/Cake/DelElement", new CustomerBindingModel { Id = id }));

                    task.ContinueWith((prevTask) => MessageBox.Show("Запись удалена. Обновите список", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information),
                    TaskContinuationOptions.OnlyOnRanToCompletion);

                    task.ContinueWith((prevTask) =>
                    {
                        var ex = (Exception)prevTask.Exception;
                        while (ex.InnerException != null)
                        {
                            ex = ex.InnerException;
                        }
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }, TaskContinuationOptions.OnlyOnFaulted);
                }
            }
        }

        private void FCakeSRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}