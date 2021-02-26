using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorFrontEnd.Data
{
    public class Item
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        [MaxLength(20)]
        public string nameOfItem { get; set; }
        public string description { get; set; }
        public string imageName { get; set; }
        public int cost { get; set; }
    }
}