namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="�������")]
        public string Number { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="��Ʒ���")]
        public string SoNumber { get; set; }

        [Display(Name="��Ʒ����")]
        public int SoNum { get; set; }

        [StringLength(50)]
        [Display(Name ="���I")]
        public string CategoryI { get; set; }

        [StringLength(50)]
        [Display(Name = "���II")]
        public string CategoryII { get; set; }

        [StringLength(50)]
        [Display(Name = "�����")]
        public string BuyerName { get; set; }

        [StringLength(50)]
        [Display(Name = "��ϵ�绰")]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "�ջ���ַ")]
        public string DelAddress { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "��Ӧ�̱��")]
        public string SuNumber { get; set; }

        [Display(Name = "�ܶ�")]
        public int Total { get; set; }

        [Display(Name = "��������")]
        public int Payment { get; set; }

        [Display(Name = "��������")]
        public int DelGoods { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "�µ�ʱ��")]
        public string Time { get; set; }
    }
}
