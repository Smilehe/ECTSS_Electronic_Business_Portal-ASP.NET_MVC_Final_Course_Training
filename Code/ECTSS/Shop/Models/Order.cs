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
        [Display(Name ="订单编号")]
        public string Number { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="商品编号")]
        public string SoNumber { get; set; }

        [Display(Name="商品数量")]
        public int SoNum { get; set; }

        [StringLength(50)]
        [Display(Name ="类别I")]
        public string CategoryI { get; set; }

        [StringLength(50)]
        [Display(Name = "类别II")]
        public string CategoryII { get; set; }

        [StringLength(50)]
        [Display(Name = "买家名")]
        public string BuyerName { get; set; }

        [StringLength(50)]
        [Display(Name = "联系电话")]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "收货地址")]
        public string DelAddress { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "供应商编号")]
        public string SuNumber { get; set; }

        [Display(Name = "总额")]
        public int Total { get; set; }

        [Display(Name = "付款详情")]
        public int Payment { get; set; }

        [Display(Name = "发货详情")]
        public int DelGoods { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "下单时间")]
        public string Time { get; set; }
    }
}
