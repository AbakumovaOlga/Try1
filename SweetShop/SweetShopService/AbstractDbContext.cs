using SweetShop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService
{
    [Table("AbstractDatabase")]
    public class AbstractDbContext : DbContext
    {
        public AbstractDbContext()
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<Baker> Bakers { get; set; }

        public virtual DbSet<Request> Requests { get; set; }

        public virtual DbSet<Cake> Cakes { get; set; }

        public virtual DbSet<CakeIngredient> CakeIngredients { get; set; }

        public virtual DbSet<Fridge> Fridges { get; set; }

        public virtual DbSet<FridgeIngredient> FridgeIngredients { get; set; }

    }
}
