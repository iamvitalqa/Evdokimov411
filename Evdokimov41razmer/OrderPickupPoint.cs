//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Evdokimov41razmer
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderPickupPoint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderPickupPoint()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int OrderPickupPoint1 { get; set; }
        public Nullable<int> OrderIndex { get; set; }
        public string OrderCity { get; set; }
        public string OrderStreet { get; set; }
        public Nullable<int> OrderHouse { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
