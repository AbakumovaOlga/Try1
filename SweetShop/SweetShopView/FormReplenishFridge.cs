using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using SweetShopService.BindingModels;

namespace SweetShopView
{
    public partial class FormReplenishFridge : Form
    {
        public FormReplenishFridge()
        {
            InitializeComponent();
        }

        private void FormReplenishFridge_Load(object sender, EventArgs e)
        {
            try
            {
                var responseC = APICustomer.GetRequest("api/Ingredient/GetList");
                if (responseC.Result.IsSuccessStatusCode)
                {
                    List<IngredientViewModel> list = APICustomer.GetElement<List<IngredientViewModel>>(responseC);
                    if (list != null)
                    {
                        FRFIngredient.DisplayMember = "IngredientName";
                        FRFIngredient.ValueMember = "Id";
                        FRFIngredient.DataSource = list;
                        FRFIngredient.SelectedItem = null;
                    }
                }
                else
                {
                    throw new Exception(APICustomer.GetError(responseC));
                }
                var responseS = APICustomer.GetRequest("api/Fridge/GetList");
                if (responseS.Result.IsSuccessStatusCode)
                {
                    List<FridgeViewModel> list = APICustomer.GetElement<List<FridgeViewModel>>(responseS);
                    if (list != null)
                    {
                        FRFFridge.DisplayMember = "FridgeName";
                        FRFFridge.ValueMember = "Id";
                        FRFFridge.DataSource = list;
                        FRFFridge.SelectedItem = null;
                    }
                }
                else
                {
                    throw new Exception(APICustomer.GetError(responseC));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRFSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FRFNumber.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FRFIngredient.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FRFFridge.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var response = APICustomer.PostRequest("api/Main/ReplenishFridge", new FridgeIngredientBindingModel
                {
                    IngredientId = Convert.ToInt32(FRFIngredient.SelectedValue),
                    FridgeId = Convert.ToInt32(FRFFridge.SelectedValue),
                    Count = Convert.ToInt32(FRFNumber.Text)
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

        private void FRFCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
