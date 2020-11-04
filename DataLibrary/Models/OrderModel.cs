﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLibrary.Models
{
    public class OrderModel
    {
        //decorations usually done on frontend
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "You need to keep the name to a max of 20 characters")]
        [MinLength(3, ErrorMessage = "You need to enter at least 3 characters")]
        [DisplayName("Name for the Order")]
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        [DisplayName("Meal")]
        [Range(1, int.MaxValue, ErrorMessage = "You need to select a meal from the list")]       
        public int FoodId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "You can select up to 10 meals")]
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
