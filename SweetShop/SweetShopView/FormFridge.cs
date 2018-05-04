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
    public partial class FormFridge : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormFridge()
        {
            InitializeComponent();
        }

        private void FormFridge_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var Fridge = Task.Run(() => APICustomer.GetRequestData<FridgeViewModel>("api/Fridge/Get/" + id.Value)).Result;
                    FFrName.Text = Fridge.FridgeName;
                    dataGridView.DataSource = Fridge.FridgeIngredients;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void FFrSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FFrName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name = FFrName.Text;
            Task task;
            if (id.HasValue)
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Fridge/UpdElement", new FridgeBindingModel
                {
                    Id = id.Value,
                    FridgeName = name
                }));
            }
            else
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Fridge/AddElement", new FridgeBindingModel
                {
                    FridgeName = name
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

        private void FFrCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FFrName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
