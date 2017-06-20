namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shops")]
    public partial class Shops
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��Ʒ���")]
        public string Number { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��Ʒ����")]
        public string Name { get; set; }

        [Display(Name = "����")]
        public double PurPrice { get; set; }

        [Display(Name = "�ۼ�")]
        public double Price { get; set; }

        [Display(Name = "��������")]
        public int SalesVolumes { get; set; }

        [Display(Name = "���I")]
        public int CategoryI { get; set; }

        [Display(Name = "���II")]
        public int CategoryII { get; set; }

        [Display(Name = "��Ӧ��")]
        public int Supplier { get; set; }

        [Required]
        [StringLength(50)]
        public string KeyAttribute { get; set; }
    }
}
