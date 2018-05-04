using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SweetShopView
{
    public partial class FormBaker : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormBaker()
        {
            InitializeComponent();
        }

        private void FormBaker_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var Baker = Task.Run(() => APICustomer.GetRequestData<BakerViewModel>("api/Baker/Get/" + id.Value)).Result;
                    FBakFIO.Text = Baker.BakerFIO;
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
        }

        private void FBakSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FBakFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fio = FBakFIO.Text;
            Task task;
            if (id.HasValue)
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Baker/UpdElement", new BakerBindingModel
                {
                    Id = id.Value,
                    BakerFIO = fio
                }));
            }
            else
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Baker/AddElement", new BakerBindingModel
                {
                    BakerFIO = fio
                }));
            }

            task.ContinueWith((prevTask) => MessageBox.Show("Сохранение прошло успешно. Обновите список", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information),
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

        private void FBakCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FBakFIO_TextChanged(object sender, EventArgs e)
        {

        }
    }
}