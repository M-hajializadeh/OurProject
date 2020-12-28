using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Province { get; set; }
        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string City { get; set; }
        [Display(Name = "خیابان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Street { get; set; }
        [Display(Name = "کوچه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Alley { get; set; }
        [Display(Name = "ادامه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string ContinueAddress { get; set; }
        [Display(Name = "کدپستی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [MaxLength(10, ErrorMessage = "تعداد {0} باید 10 کاراکتر باشد")]
        [MinLength(10, ErrorMessage = "تعداد {0} باید 10 کاراکتر باشد")]
        public string PostalCode { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey(nameof(CustomerID))]
        public virtual Customer Customer { get; set; }

    }
}
