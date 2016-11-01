using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyShopping.FamilyShoppingDAL
{
    public class ShoppingItemDTO : ShoppingItem
    {
        public string UnitAmountDescription { get; set; }
        public string PlaceDescription { get; set; }
        public string PlaceAddress { get; set; }

    }
}