using FamilyShopping.FamilyShoppingDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyShopping.FamilyShoppingBLL
{
    public class ShoppingValidator
    {
        private ShoppingRepository _shoppingRepository;
        private ShoppingRepository ShoppingRepository()
        {
            if (_shoppingRepository == null)
            {
                _shoppingRepository = new ShoppingRepository();
            }
            return _shoppingRepository;
        }

        public List<string> ValidateAllForShoppingItemAdd(string description, string quantityAsSting, string unitAmountOidAsString,
                                        string shoppingDateOidAsString, string shoppingPlaceOidAsString, string maxPriceAsString)
        {
            var resVal = new List<string>();

            var descriptionError = ValidateDescription(description);
            if (!string.IsNullOrWhiteSpace(descriptionError))
                resVal.Add(descriptionError);

            var quantityError = ValidateQuantity(quantityAsSting);
            if (!string.IsNullOrWhiteSpace(quantityError))
                resVal.Add(quantityError);

            var unitAmountError = ValidateUnitAmount(unitAmountOidAsString);
            if (!string.IsNullOrWhiteSpace(unitAmountError))
                resVal.Add(unitAmountError);

            var shoppingDateError = ValidateDate(shoppingDateOidAsString);
            if (!string.IsNullOrWhiteSpace(shoppingDateError))
                resVal.Add(shoppingDateError);

            var shoppingPlaceError = ValidateShoppingPlace(shoppingPlaceOidAsString);
            if (!string.IsNullOrWhiteSpace(shoppingPlaceError))
                resVal.Add(shoppingPlaceError);

            var maxPriceError = ValidateMaxPrice(maxPriceAsString);
            if (!string.IsNullOrWhiteSpace(maxPriceError))
                resVal.Add(maxPriceError);

            return resVal;
        }

        public string ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return "Kérem adja meg a terméket.";

            return string.Empty;
        }

        public string ValidateQuantity(string quantityAsSting)
        {
            if (string.IsNullOrWhiteSpace(quantityAsSting))
                return "Kérem adja meg a mennyiséget.";

            var quantity = 0;
            if (!Int32.TryParse(quantityAsSting, out quantity))
                return "Kérem a mennyiséghez számot adjon meg.";

            if (quantity <= 0)
                return "Kérem mennyiségként pozitív számot adjon meg.";

            return string.Empty;
        }

        public string ValidateUnitAmount(string unitAmountOidAsString)
        {
            long unit = 0;
            var convert = Int64.TryParse(unitAmountOidAsString, out unit);
            if (string.IsNullOrWhiteSpace(unitAmountOidAsString)
                || !convert
                || unit <= 0
                || !ShoppingRepository().ShoppingUnitAmountGetAll().Select(x => x.OID).ToList().Contains(unit))
                return "Kérem adja meg a mennyiség egységet.";

            return string.Empty;
        }

        public string ValidateDate(string shoppingDateOidAsString)
        {
            long date = 0;
            var convert = Int64.TryParse(shoppingDateOidAsString, out date);
            if (string.IsNullOrWhiteSpace(shoppingDateOidAsString)
                || !convert
                || date <= 0
                || !ShoppingRepository().ShoppingPlaceGetAll().Select(x => x.OID).ToList().Contains(date))
                return "Kérem adja meg a dátumot.";

            return string.Empty;
        }

        public string ValidateShoppingPlace(string shoppingPlaceOidAsString)
        {
            long place = 0;
            var convert = Int64.TryParse(shoppingPlaceOidAsString, out place);
            if (string.IsNullOrWhiteSpace(shoppingPlaceOidAsString)
                || !convert
                || place <= 0
                || !ShoppingRepository().ShoppingPlaceGetAll().Select(x => x.OID).ToList().Contains(place))
                return "Kérem adja meg a helyet.";

            return string.Empty;
        }

        public string ValidateMaxPrice(string maxPriceAsString)
        {
            if (string.IsNullOrWhiteSpace(maxPriceAsString))
                return "Kérem adja meg a legmagasabb árat.";

            var maxPrice = 0;
            if (!Int32.TryParse(maxPriceAsString, out maxPrice))
                return "Kérem a legmagasabb árhoz számot adjon meg.";

            if (maxPrice <= 0)
                return "Kérem legmagasabb árként pozitív számot adjon meg.";

            return string.Empty;
        }

    }
}