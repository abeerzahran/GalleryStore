﻿using GallaryStore.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GallaryStore.DTOs
{
    public class OrderProductsDTO
    {
        public OrderProductsDTO()
        {
            
        }
        public OrderProductsDTO(int orderId, int productId, int? quantity)
        {
            this.orderId = orderId;
            this.productId = productId;
            this.quantity = quantity;
            
            
        }
        
        public int orderId { get; set; }
        public int productId { get; set; }
        public int? quantity { get; set; }
        

       
    }
}
