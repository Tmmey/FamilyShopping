using FamilyShopping.FamilyShoppingBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyShopping.FamilyShoppingPL
{
    public partial class ShoppingItemsList : System.Web.UI.Page
    {
        private ShoppingManager _shoppingManager;
        private ShoppingManager ShoppingManager()
        {
            if (_shoppingManager == null)
            {
                _shoppingManager = new ShoppingManager();
            }
            return _shoppingManager;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ShoppingManager().HasAnyFutureShoppingDates())
            {
                if (!IsPostBack)
                {
                    //dropdownlistek populálása
                    dropdownShoppingDate.Items.AddRange(ShoppingManager().ShoppingDateGetAllToListBox());
                    txtWishList.Text = ShoppingManager().GetFormattedShoppingItemList(dropdownShoppingDate.SelectedValue);
                }
            }
            else
            {
                //oldal tiltása
                lblShoppingDateWarning.Visible = true;
                dropdownShoppingDate.Visible = false;
            }
        }

        protected void dropdownShoppingDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWishList.Text = ShoppingManager().GetFormattedShoppingItemList(dropdownShoppingDate.SelectedValue);
        }

        protected void dropdownShoppingDate_TextChanged(object sender, EventArgs e)
        {
            txtWishList.Text = ShoppingManager().GetFormattedShoppingItemList(dropdownShoppingDate.SelectedValue);
        }
    }
}