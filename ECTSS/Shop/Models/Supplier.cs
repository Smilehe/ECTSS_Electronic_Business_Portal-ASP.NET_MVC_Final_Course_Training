namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        public int ID { get; set; }

        [Display(Name = "���")]
        public int Number { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��Ӧ������")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��Ӧ�̵�ַ")]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "�ؼ���")]
        public string Keyword { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��������")]
        public string Postcode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��ϵ�绰")]
        public string ContNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��ϵ��")]
        public string Contacts { get; set; }

        [Required]
        [Display(Name = "���I")]
        public int CommodityI { get; set; }

        [Required]
        [Display(Name = "���II")]
        public int CommodityII { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "�����˺�")]
        public string BankAccount { get; set; }
    }
}
