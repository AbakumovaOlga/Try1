using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity.Attributes;
using Unity;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using SweetShopService.BindingModels;

namespace SweetShopView
{
    public partial class FormReplenishFridge : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IFridgeService serviceF;

        private readonly IIngredientService serviceI;

        private readonly IMainService serviceM;

        public FormReplenishFridge(IFridgeService serviceF, IIngredientService serviceI, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceF = serviceF;
            this.serviceI = serviceI;
            this.serviceM = serviceM;
        }

        private void FormReplenishFridge_Load(object sender, EventArgs e)
        {
            try
            {
                List<IngredientViewModel> listC = serviceI.GetList();
                if (listC != null)
                {
                    FRFIngredient.DisplayMember = "IngredientName";
                    FRFIngredient.ValueMember = "Id";
                    FRFIngredient.DataSource = listC;
                    FRFIngredient.SelectedItem = null;
                }
                List<FridgeViewModel> listS = serviceF.GetList();
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
                serviceM.PutIngredientOnFridge(new FridgeIngredientBindingModel
                {
                    IngredientId = Convert.ToInt32(FRFIngredient.SelectedValue),
                    FridgeId = Convert.ToInt32(FRFFridge.SelectedValue),
                    Count = Convert.ToInt32(FRFNumber.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
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
