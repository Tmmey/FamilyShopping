using FamilyShopping.FamilyShoppingBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyShopping.FamilyShoppingPL
{
    public partial class ShoppingDateAdd : System.Web.UI.Page
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
            
        }

        protected void btnShoppingDateAdd_Click(object sender, EventArgs e)
        {
            lblMessage.Text = ShoppingManager().ShoppingDateAdd(calendar.SelectedDate);
        }
    }
}