using SweetShopService;
using SweetShopService.ImplementationsBD;
using SweetShopService.ImplementationsList;
using SweetShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace SweetShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AbstractDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerService, CustomerServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientService, IngredientServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBakerService, BakerServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICakeService, CakeServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IFridgeService, FridgeServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceBD>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
