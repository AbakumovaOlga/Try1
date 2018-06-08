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
                    var response = APICustomer.GetRequest("api/Baker/Get/" + id.Value);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var Baker = APICustomer.GetElement<BakerViewModel>(response);
                        FBakFIO.Text = Baker.BakerFIO;
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

        private void FBakSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FBakFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APICustomer.PostRequest("api/Baker/UpdElement", new BakerBindingModel
                    {
                        Id = id.Value,
                        BakerFIO = FBakFIO.Text
                    });
                }
                else
                {
                    response = APICustomer.PostRequest("api/Baker/AddElement", new BakerBindingModel
                    {
                        BakerFIO = FBakFIO.Text
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

        private void FBakCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void FBakFIO_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
