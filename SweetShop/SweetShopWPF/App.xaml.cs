using SweetShopService;
using SweetShopService.ImplementationsBD;
using SweetShopService.ImplementationsList;
using SweetShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace SweetShopWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            APICustomer.Connect();
            //var container = BuildUnityContainer();

            var application = new App();
            application.Run(new FormMain());
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
            currentContainer.RegisterType<IReportService, ReportServiceBD>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
