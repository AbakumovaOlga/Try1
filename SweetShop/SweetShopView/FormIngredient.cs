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
using System.Net.Http;

namespace SweetShopView
{
    public partial class FormIngredient : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormIngredient()
        {
            InitializeComponent();
        }

        private void FormIngredient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var Ingredient = Task.Run(() => APICustomer.GetRequestData<IngredientViewModel>("api/Ingredient/Get/" + id.Value)).Result;
                    FIngrName.Text = Ingredient.IngredientName;
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

        private void FIngrSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FIngrName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name = FIngrName.Text;
            Task task;
            if (id.HasValue)
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Ingredient/UpdElement", new IngredientBindingModel
                {
                    Id = id.Value,
                    IngredientName = name
                }));
            }
            else
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Ingredient/AddElement", new IngredientBindingModel
                {
                    IngredientName = name
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

        private void FIngrCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
