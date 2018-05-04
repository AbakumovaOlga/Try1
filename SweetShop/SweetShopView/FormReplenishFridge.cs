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
                List<IngredientViewModel> listC = Task.Run(() => APICustomer.GetRequestData<List<IngredientViewModel>>("api/Ingredient/GetList")).Result;
                if (listC != null)
                {
                    FRFIngredient.DisplayMember = "IngredientName";
                    FRFIngredient.ValueMember = "Id";
                    FRFIngredient.DataSource = listC;
                    FRFIngredient.SelectedItem = null;
                }

                List<FridgeViewModel> listS = Task.Run(() => APICustomer.GetRequestData<List<FridgeViewModel>>("api/Fridge/GetList")).Result;
                if (listS != null)
                {
                    FRFFridge.DisplayMember = "FridgeName";
                    FRFFridge.ValueMember = "Id";
                    FRFFridge.DataSource = listS;
                    FRFFridge.SelectedItem = null;
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
                int IngredientId = Convert.ToInt32(FRFIngredient.SelectedValue);
                int FridgeId = Convert.ToInt32(FRFFridge.SelectedValue);
                int count = Convert.ToInt32(FRFNumber.Text);
                Task task = Task.Run(() => APICustomer.PostRequestData("api/Main/PutIngredientOnFridge", new FridgeIngredientBindingModel
                {
                    IngredientId = IngredientId,
                    FridgeId = FridgeId,
                    Count = count
                }));

                task.ContinueWith((prevTask) => MessageBox.Show("Склад пополнен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information),
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

        private void FRFCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
