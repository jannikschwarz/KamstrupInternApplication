using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Order
    {
        [Key]
        [Required]
        public int orderId { get; set; }

        [Required]
        [MaxLength(20)]
        public string nameOfBuyer { get; set; }
        
        [Required]
        public string timeOfOrder { get; set; }

        [Required]
        public Item boughtItem { get; set; }
        
        public Order(){}
        
        public Order(string name, Item boughtItem)
        {
            timeOfOrder = "" + DateTime.Now.Day +"/" + DateTime.Now.Month +"/" + DateTime.Now.Year;
            nameOfBuyer = name;
            this.boughtItem = boughtItem;
        }
    }
}