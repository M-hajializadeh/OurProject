using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "تعداد محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public uint Count { get; set; }
        [Display(Name = "میزان تخفیف")]
        [MaxLength(100,ErrorMessage ="میزان تخفیف نباید بیشتر از 100درصد باشد")]
        [MinLength(0,ErrorMessage ="میزان تخفیف نباید کمتراز 0درصد باشد")]
        public uint Off { get; set; } = 0;
        [Display(Name = "وضعیت سفارش")]
        public byte StatusOrder { get; set; }

        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        
        [ForeignKey(nameof(CustomerID))]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(ProductID))]
        public virtual Product Product { get; set; }
    }
}
