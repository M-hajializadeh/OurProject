using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Models
{
    public class OptionalItem
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "اطلاعات سفارش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Details { get; set; }
        [Display(Name = "توضیحات سفارش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Description { get; set; }
        [Display(Name = "فایل های ضمیمه")]
        public string AttachFileURL { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey(nameof(CustomerID))]
        public virtual Customer Customer { get; set; }

    }
}
