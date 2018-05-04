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
                    var response = APICustomer.GetRequest("api/Fridge/Get/" + id.Value);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var Fridge = APICustomer.GetElement<FridgeViewModel>(response);
                        FFrName.Text = Fridge.FridgeName;
                        dataGridView.DataSource = Fridge.FridgeIngredients;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else
                    {
                        throw new Exception(APICustomer.GetError(response));
                    }
                }
                catch (Exception ex)
                {
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
            try
            {
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APICustomer.PostRequest("api/Fridge/UpdElement", new FridgeBindingModel
                    {
                        Id = id.Value,
                        FridgeName = FFrName.Text
                    });
                }
                else
                {
                    response = APICustomer.PostRequest("api/Fridge/AddElement", new FridgeBindingModel
                    {
                        FridgeName = FFrName.Text
                    });
                }
                if (response.Result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    throw new Exception(APICustomer.GetError(response));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FFrCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FFrName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
