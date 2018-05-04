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
    public partial class FormBakers : Form
    {
        public FormBakers()
        {
            InitializeComponent();
        }

        private void FormBakers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<BakerViewModel> list = Task.Run(() => APICustomer.GetRequestData<List<BakerViewModel>>("api/Baker/GetList")).Result;
                if (list != null)
                {
                    FBakSList.DataSource = list;
                    FBakSList.Columns[0].Visible = false;
                    FBakSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void FBakSAdd_Click(object sender, EventArgs e)
        {
            var form = new FormBaker();
            form.ShowDialog();
        }

        private void FBakSUpd_Click(object sender, EventArgs e)
        {
            if (FBakSList.SelectedRows.Count == 1)
            {
                var form = new FormBaker
                {
                    Id = Convert.ToInt32(FBakSList.SelectedRows[0].Cells[0].Value)
                };
                form.ShowDialog();
            }
        }

        private void FBakSDel_Click(object sender, EventArgs e)
        {
            if (FBakSList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(FBakSList.SelectedRows[0].Cells[0].Value);

                    Task task = Task.Run(() => APICustomer.PostRequestData("api/Baker/DelElement", new CustomerBindingModel { Id = id }));

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

        private void FBakSRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void FBakSList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}