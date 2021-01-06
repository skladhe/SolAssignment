//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MastProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MastProduct()
        {
            this.ProdDiscounts = new HashSet<ProdDiscount>();
            this.ProdPricings = new HashSet<ProdPricing>();
        }
    
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public string ProdDesc { get; set; }
        public Nullable<int> UnitsInStock { get; set; }
        public string UnitOfMeasure { get; set; }
        public string UnitOfSales { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdDiscount> ProdDiscounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdPricing> ProdPricings { get; set; }
    }
}
