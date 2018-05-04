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
    public partial class FormCreateRequest : Form
    {
        public FormCreateRequest()
        {
            InitializeComponent();
        }

        private void FormCreateRequest_Load(object sender, EventArgs e)
        {
            try
            {
                var responseC = APICustomer.GetRequest("api/Customer/GetList");
                if (responseC.Result.IsSuccessStatusCode)
                {
                    List<CustomerViewModel> list = APICustomer.GetElement<List<CustomerViewModel>>(responseC);
                    if (list != null)
                    {
                        FCRCustomer.DisplayMember = "CustomerFIO";
                        FCRCustomer.ValueMember = "Id";
                        FCRCustomer.DataSource = list;
                        FCRCustomer.SelectedItem = null;
                    }
                }
                else
                {
                    throw new Exception(APICustomer.GetError(responseC));
                }
                var responseP = APICustomer.GetRequest("api/Cake/GetList");
                if (responseP.Result.IsSuccessStatusCode)
                {
                    List<CakeViewModel> list = APICustomer.GetElement<List<CakeViewModel>>(responseP);
                    if (list != null)
                    {
                        FCRCake.DisplayMember = "CakeName";
                        FCRCake.ValueMember = "Id";
                        FCRCake.DataSource = list;
                        FCRCake.SelectedItem = null;
                    }
                }
                else
                {
                    throw new Exception(APICustomer.GetError(responseP));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (FCRCake.SelectedValue != null && !string.IsNullOrEmpty(FCRNumber.Text))
            {
                try
                {
                    int id = Convert.ToInt32(FCRCake.SelectedValue);
                    var responseP = APICustomer.GetRequest("api/Cake/Get/" + id);
                    if (responseP.Result.IsSuccessStatusCode)
                    {
                        CakeViewModel Cake = APICustomer.GetElement<CakeViewModel>(responseP);
                        int count = Convert.ToInt32(FCRNumber.Text);
                        FCRSum.Text = (count * (int)Cake.Price).ToString();
                    }
                    else
                    {
                        throw new Exception(APICustomer.GetError(responseP));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FCRNumber_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void FCRCake_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void FCRSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FCRNumber.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FCRCustomer.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FCRCake.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var response = APICustomer.PostRequest("api/Main/CreateRequest", new RequestBindingModel
                {
                    CustomerId = Convert.ToInt32(FCRCustomer.SelectedValue),
                    CakeId = Convert.ToInt32(FCRCake.SelectedValue),
                    Count = Convert.ToInt32(FCRNumber.Text),
                    Sum = Convert.ToInt32(FCRSum.Text)
                });
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

        private void FCRCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void FCRNumber_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
