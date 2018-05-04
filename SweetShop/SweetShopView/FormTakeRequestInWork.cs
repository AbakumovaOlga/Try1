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
    public partial class FormTakeRequestInWork : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormTakeRequestInWork()
        {
            InitializeComponent();
        }

        private void FormBaker_Load(object sender, EventArgs e)
        {
            try
            {
                if (!id.HasValue)
                {
                    MessageBox.Show("Не указан заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                List<BakerViewModel> list = Task.Run(() => APICustomer.GetRequestData<List<BakerViewModel>>("api/Baker/GetList")).Result;
                if (list != null)
                {
                    FTRBaker.DisplayMember = "BakerFIO";
                    FTRBaker.ValueMember = "Id";
                    FTRBaker.DataSource = list;
                    FTRBaker.SelectedItem = null;
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

        private void FTRSave_Click(object sender, EventArgs e)
        {
            if (FTRBaker.SelectedValue == null)
            {
                MessageBox.Show("Выберите исполнителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int BakerId = Convert.ToInt32(FTRBaker.SelectedValue);
                Task task = Task.Run(() => APICustomer.PostRequestData("api/Main/TakeRequestInWork", new RequestBindingModel
                {
                    Id = id.Value,
                    BakerId = BakerId
                }));

                task.ContinueWith((prevTask) => MessageBox.Show("Заказ передан в работу. Обновите список", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information),
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

                Close();
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


        private void FTRCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
