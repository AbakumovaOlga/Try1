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
                var response = APICustomer.GetRequest("api/Baker/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<BakerViewModel> list = APICustomer.GetElement<List<BakerViewModel>>(response);
                    if (list != null)
                    {
                        FTRBaker.DisplayMember = "BakerFIO";
                        FTRBaker.ValueMember = "Id";
                        FTRBaker.DataSource = list;
                        FTRBaker.SelectedItem = null;
                    }
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

        private void FTRSave_Click(object sender, EventArgs e)
        {
            if (FTRBaker.SelectedValue == null)
            {
                MessageBox.Show("Выберите исполнителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var response = APICustomer.PostRequest("api/Main/TakeRequestInWork", new RequestBindingModel
                {
                    Id = id.Value,
                    BakerId = Convert.ToInt32(FTRBaker.SelectedValue)
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

        private void FTRCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}