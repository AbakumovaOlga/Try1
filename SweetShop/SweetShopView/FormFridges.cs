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
    public partial class FormFridges : Form
    {
        public FormFridges()
        {
            InitializeComponent();
        }

        private void FormFridges_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<FridgeViewModel> list = Task.Run(() => APICustomer.GetRequestData<List<FridgeViewModel>>("api/Fridge/GetList")).Result;
                if (list != null)
                {
                    FFrSList.DataSource = list;
                    FFrSList.Columns[0].Visible = false;
                    FFrSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void FFrSAdd_Click(object sender, EventArgs e)
        {
            var form = new FormFridge();
            form.ShowDialog();
        }

        private void FFrSUpd_Click(object sender, EventArgs e)
        {
            if (FFrSList.SelectedRows.Count == 1)
            {
                var form = new FormFridge
                {
                    Id = Convert.ToInt32(FFrSList.SelectedRows[0].Cells[0].Value)
                };
                form.ShowDialog();
            }
        }

        private void FFrSDel_Click(object sender, EventArgs e)
        {
            if (FFrSList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(FFrSList.SelectedRows[0].Cells[0].Value);

                    Task task = Task.Run(() => APICustomer.PostRequestData("api/Fridge/DelElement", new CustomerBindingModel { Id = id }));

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



        private void FFrSRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}