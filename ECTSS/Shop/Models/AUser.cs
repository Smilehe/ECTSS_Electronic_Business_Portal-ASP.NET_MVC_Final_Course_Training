namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AUser")]
    public partial class AUser
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="账号")]
        public string AccNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "昵称")]
        public string Nickname { get; set; }

        [Display(Name = "类别")]
        public int Category { get; set; }

        [Display(Name = "权限")]
        public int Jurisdiction { get; set; }

        [Display(Name = "访问记录")]
        public int AccessRecord { get; set; }
    }
}
