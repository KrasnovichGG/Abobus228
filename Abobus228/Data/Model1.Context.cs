//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Abobus228.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PodgotovkaEGSEntities : DbContext
    {
        public PodgotovkaEGSEntities()
            : base("name=PodgotovkaEGSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Product_for_Agent> Product_for_Agent { get; set; }
        public virtual DbSet<Products_Material> Products_Material { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type_Material> Type_Material { get; set; }
        public virtual DbSet<TypeProduct> TypeProduct { get; set; }
    }
}
