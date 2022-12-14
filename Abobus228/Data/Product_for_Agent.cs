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
    using System.Collections.Generic;
    
    public partial class Product_for_Agent : IComparable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product_for_Agent()
        {
            this.Products_Material = new HashSet<Products_Material>();
        }
    
        public int IdArticul { get; set; }
        public string Name_Products { get; set; }
        public Nullable<int> Minimum_cost_for_Agent { get; set; }
        public string Image { get; set; }
        public int Id_TypeProduct { get; set; }
        public Nullable<int> Number_of_people_for_Production { get; set; }
        public Nullable<int> WorkShop_Number { get; set; }
    
        public virtual TypeProduct TypeProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products_Material> Products_Material { get; set; }

        public int CompareTo(object other)
        {
            var obj = other as Product_for_Agent;
            return Name_Products.CompareTo(obj.Name_Products);
        }

        public int CompareTo(object other, int a)
        {
            var obj = other as Product_for_Agent;
            return Minimum_cost_for_Agent?.CompareTo(obj.Minimum_cost_for_Agent) ?? 0;
        }
    }
}
