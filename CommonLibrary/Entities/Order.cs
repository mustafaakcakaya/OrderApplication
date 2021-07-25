using CommonLibrary.Entities;
using CommonLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLibrary.Entities
{
    public class Order : BaseEntity
    {
        public string CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        //enum olarak tasarlayıp extension yazıp display attribute value çekip orada text tutmak daha yönetilmesi kolay geliyordu ama dökümanda string istediği için geri aldım bu adımı
        //public OrderStatus Status { get; set; }
        public string Status { get; set; }
        public Address Address { get; set; }
        public Product Product { get; set; }

    }
}
