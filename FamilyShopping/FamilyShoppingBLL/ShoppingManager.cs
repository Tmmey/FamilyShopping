using FamilyShopping.FamilyShoppingDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace FamilyShopping.FamilyShoppingBLL
{
    public class ShoppingManager
    {
        #region Lazy-loaded classes

        private ShoppingRepository _shoppingRepository;
        private ShoppingRepository ShoppingRepository()
        {
            if (_shoppingRepository == null)
            {
                _shoppingRepository = new ShoppingRepository();
            }
            return _shoppingRepository;
        }

        private ShoppingValidator _shoppingValidator;
        private ShoppingValidator ShoppingValidator()
        {
            if (_shoppingValidator == null)
            {
                _shoppingValidator = new ShoppingValidator();
            }
            return _shoppingValidator;
        }

        #endregion

        #region Populate view elements
        public ListItem[] ShoppingPlaceGetAllToListBox()
        {
            var resVal = new List<ListItem>();
            var query = ShoppingRepository().ShoppingPlaceGetAll();
            foreach (var shoppingPlace in query)
            {
                var text = string.Format("{0} - Cím:{1}", shoppingPlace.Description, shoppingPlace.Address);
                resVal.Add(new ListItem() { Text = text, Value = shoppingPlace.OID.ToString() });
            }
            //resVal.Insert(0, new ListItem() { Text = "-- Mindegy --", Value = "" });
            return resVal.ToArray();
        }

        public ListItem[] ShoppingDateGetAllToListBox()
        {
            var resVal = new List<ListItem>();
            var query = ShoppingRepository().ShoppingDatesGetAll();
            foreach (var shoppingDate in query)
            {
                var text = shoppingDate.Date.ToString("d");
                resVal.Add(new ListItem() { Text = text, Value = shoppingDate.OID.ToString() });
            }

            return resVal.ToArray();
        }

        public bool HasAnyFutureShoppingDates()
        {
            var hasAny = ShoppingRepository().ShoppingDatesGetAll().Any();
            return hasAny;
        }

        public ListItem[] ShoppingUnitAmountGetAllToListBox()
        {
            var resVal = new List<ListItem>();
            var query = ShoppingRepository().ShoppingUnitAmountGetAll();
            foreach (var shoppingUnitAmount in query)
            {
                var text = shoppingUnitAmount.Description;
                resVal.Add(new ListItem() { Text = text, Value = shoppingUnitAmount.OID.ToString() });
            }

            return resVal.ToArray();
        }

        #endregion

        #region business logic  -  CRUD logic
        public string ShoppingPlaceAdd(string description, string address)
        {
            if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(address))
            {
                return "Kérem töltse ki megfelelően az űrlapot!";
            }
            else
            {
                if (ShoppingRepository().ShoppingPlaceGetAll().Any(x => x.Address == address && x.Description == description))
                {
                    return "Bevásárlóhely már korábban hozzáadva.";
                }
                else
	            {
                    var shoppingPlace = new ShoppingPlace()
                    {
                        Description = description,
                        Address = address
                    };
                    if (ShoppingRepository().ShoppingPlaceAdd(shoppingPlace))
                    {
                        return "Bevásárlóhely sikeresen hozzáadva.";
                    }
                    else
                    {
                        return "Hiba történt....";
                    }
	            }

            }
        }

        public string ShoppingDateAdd(DateTime date)
        {
            if (date.Date < DateTime.Now.Date)
            {
                return "Kérem ne múltbéli dátumot!";
            }
            else if (ShoppingRepository().ShoppingDateGetAll(true).Any(x => x.Date == date.Date))
            {
                return "Az időpont már létezik!";
            }
            else
            {
                var shoppingDate = new ShoppingDate() 
                { 
                    Date = date
                };
                if (ShoppingRepository().ShoppingDateAdd(shoppingDate))
                {
                    return "Időpont sikeresen hozzáadva.";
                }
                else
                {
                    return "Hiba történt....";
                }
            }
        }

        public string ShoppingItemAdd(string description, string quantityAsSting, string unitAmountOidAsString, 
                                        string shoppingDateOidAsString, string shoppingPlaceOidAsString, string maxPriceAsString)
        {
            var resval = string.Empty;

            var validationErrors = ShoppingValidator().ValidateAllForShoppingItemAdd(description, quantityAsSting, shoppingDateOidAsString,
                                                        unitAmountOidAsString, shoppingPlaceOidAsString, maxPriceAsString);
            if(validationErrors.Any())
            {
                resval = string.Join(" ", validationErrors);
            }
            else
            {
                var shoppingItem = new ShoppingItem()
                {
                    ItemDescription = description,
                    Quantity = Convert.ToInt32(quantityAsSting),
                    MaxPrice = Convert.ToDecimal(maxPriceAsString),
                    ShoppingDateOID = Convert.ToInt64(shoppingDateOidAsString),
                    ShoppingPlaceOID = Convert.ToInt64(shoppingPlaceOidAsString),
                    ShoppingUnitAmountOID = Convert.ToInt64(unitAmountOidAsString)
                };

                if (ShoppingRepository().ShoppingItemAdd(shoppingItem))
                    resval = "Tétel sikeresen hozzáadva";
                else
                    resval = "Hiba történt.";
            }
            
            return resval;
        }

        public string GetFormattedShoppingItemList(string shoppingDateOidAsString)
        {
            var resVal = string.Empty;

            var items = ShoppingRepository().GetShoppingItemsByDateOid(Convert.ToInt64(shoppingDateOidAsString));
            if (!items.Any())
                resVal = "Erre a dátumra még nem érkezett kívánság.";
            else
                resVal = FormatShoppingItemList(items);
            return resVal;
        }

        private string FormatShoppingItemList(List<ShoppingItemDTO> list)
        {
            var resVal = new StringBuilder();

            foreach (var item in list)
            {
                resVal.AppendFormat("Termék:{0} - {1} {2} (innen hozd:{3} {4})", item.ItemDescription, item.Quantity, item.UnitAmountDescription, item.PlaceDescription, item.PlaceAddress);
                resVal.Append(Environment.NewLine);
            }

            return resVal.ToString();
        }

        #endregion

    }
}