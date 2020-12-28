using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string ProductName { get; set; }
        [Display(Name = "تعداد محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public uint Count { get; set; }
        [Display(Name = "میزان تخفیف")]
        [MaxLength(100, ErrorMessage = "میزان تخفیف نباید بیشتر از 100درصد باشد")]
        [MinLength(0, ErrorMessage = "میزان تخفیف نباید کمتراز 0درصد باشد")]
        public byte Off { get; set; } = 0;
        [Display(Name = "قابل نمایش")]
        public bool IsShow { get; set; }
        [Display(Name = "مبلغ محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [MinLength(0,ErrorMessage ="لطفا مبلغ صحیح وارد نمایید")]
        public uint Price { get; set; }
        [Display(Name = "عکس محصول")]
        public string PictureUrl { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Description { get; set; }

        public int MainGroupID { get; set; }
        [ForeignKey(nameof(MainGroupID))]
        public virtual MainGroup MainGroup { get; set; }
    }
}
