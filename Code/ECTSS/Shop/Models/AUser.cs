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
        [Display(Name ="�˺�")]
        public string AccNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "����")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "����")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "�ǳ�")]
        public string Nickname { get; set; }

        [Display(Name = "���")]
        public int Category { get; set; }

        [Display(Name = "Ȩ��")]
        public int Jurisdiction { get; set; }

        [Display(Name = "���ʼ�¼")]
        public int AccessRecord { get; set; }
    }
}
