using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FamilyShopping.FamilyShoppingDAL;

namespace FamilyShopping.FamilyShoppingDAL
{
    public class ShoppingRepository
    {
        public List<ShoppingPlace> ShoppingPlaceGetAll()
        {
            var resVal = new List<ShoppingPlace>();
            using(var dc = new ShoppingDataClassesDataContext())
	        {
		        resVal = (from p in dc.ShoppingPlaces
                            select p).ToList();
	        }
            return resVal;
        }

        public List<ShoppingDate> ShoppingDatesGetAll()
        {
            var resVal = new List<ShoppingDate>();
            using (var dc = new ShoppingDataClassesDataContext())
            {
                resVal = (from p in dc.ShoppingDates
                          where p.Date >= DateTime.Now.Date
                          select p).ToList();
            }
            return resVal;
        }

        public List<ShoppingUnitAmount> ShoppingUnitAmountGetAll()
        {
            var resVal = new List<ShoppingUnitAmount>();
            using (var dc = new ShoppingDataClassesDataContext())
            {
                resVal = (from p in dc.ShoppingUnitAmounts
                          select p).ToList();
            }
            return resVal;
        }

        public bool ShoppingPlaceAdd(ShoppingPlace shoppingPlace)
        {
            try
            {
                using (var dc = new ShoppingDataClassesDataContext())
                {
                    dc.ShoppingPlaces.InsertOnSubmit(shoppingPlace);
                    dc.SubmitChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                //logolni illene
                return false;
            }

        }

        public List<DateTime> ShoppingDateGetAll(bool isFutureOnly)
        {
            var resVal = new List<DateTime>();
            using (var dc = new ShoppingDataClassesDataContext())
            {
                var query = dc.ShoppingDates.Select(x => x.Date);
                if (isFutureOnly)
                {
                    query.Where(x => x.Date >= DateTime.Now.Date);
                }
                resVal = query.ToList();
            }
            return resVal;
        }

        public bool ShoppingDateAdd(ShoppingDate shoppingDate)
        {
            try
            {
                using (var dc = new ShoppingDataClassesDataContext())
                {
                    dc.ShoppingDates.InsertOnSubmit(shoppingDate);
                    dc.SubmitChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ShoppingItemAdd(ShoppingItem shoppingItem)
        {
            try
            {
                using (var dc = new ShoppingDataClassesDataContext())
                {
                    dc.ShoppingItems.InsertOnSubmit(shoppingItem);
                    dc.SubmitChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ShoppingItemDTO> GetShoppingItemsByDateOid(long dateOid)
        {
            var resVal = new List<ShoppingItemDTO>();

            using (var dc = new ShoppingDataClassesDataContext())
            {
                var query = dc.ShoppingItems.Where(x => x.ShoppingDateOID == dateOid);

                foreach (var item in query)
                    resVal.Add(new ShoppingItemDTO()
                    {
                        OID = item.OID,
                        MaxPrice = item.MaxPrice,
                        ItemDescription = item.ItemDescription,
                        Quantity = item.Quantity,
                        PlaceAddress = item.ShoppingPlace.Address,
                        PlaceDescription = item.ShoppingPlace.Description,
                        UnitAmountDescription = item.ShoppingUnitAmount.Description,
                        ShoppingUnitAmountOID = item.ShoppingUnitAmountOID,
                        ShoppingPlaceOID = item.ShoppingPlaceOID,
                        ShoppingDateOID = item.ShoppingDateOID
                    });
            }

            return resVal;
        }
    }
}