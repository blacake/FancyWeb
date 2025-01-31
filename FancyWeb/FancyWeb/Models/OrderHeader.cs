//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FancyWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderHeader()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Questions = new HashSet<Question>();
        }
    
        public int OrderID { get; set; }
        public string OrderNum { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public int UserID { get; set; }
        public int PayMethodID { get; set; }
        public int ShippingID { get; set; }
        public int OrderStatusID { get; set; }
        public int OrderAmount { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> RegionID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ReceipterName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual PayMethod PayMethod { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual OrderStatusList OrderStatusList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }
        public virtual User User { get; set; }
    }
}
