using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SweetShopView
{
    public partial class FormCakeIngredient : Form
    {
        public CakeIngredientViewModel Model { set { model = value; } get { return model; } }

        private CakeIngredientViewModel model;

        public FormCakeIngredient()
        {
            InitializeComponent();
        }

        private void FormProductComponent_Load(object sender, EventArgs e)
        {
            try
            {
                var response = APICustomer.GetRequest("api/Component/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    comboBox1.DisplayMember = "ComponentName";
                    comboBox1.ValueMember = "Id";
                    comboBox1.DataSource = APICustomer.GetElement<List<IngredientViewModel>>(response);
                    comboBox1.SelectedItem = null;
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
            if (model != null)
            {
                comboBox1.Enabled = false;
                comboBox1.SelectedValue = model.IngredientId;
                FCINumber.Text = model.Count.ToString();
            }
        }

        private void FCISave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FCINumber.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new CakeIngredientViewModel
                    {
                        IngredientId = Convert.ToInt32(comboBox1.SelectedValue),
                        IngredientName = comboBox1.Text,
                        Count = Convert.ToInt32(FCINumber.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(FCINumber.Text);
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCICancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void FormCakeIngredient_Load(object sender, EventArgs e)
        {

        }
    }
}
