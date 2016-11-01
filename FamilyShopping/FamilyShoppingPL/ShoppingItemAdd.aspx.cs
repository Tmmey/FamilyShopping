using FamilyShopping.FamilyShoppingBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyShopping.FamilyShoppingPL
{
    public partial class ShoppingItemAdd : System.Web.UI.Page
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
                    dropdownDate.Items.AddRange(ShoppingManager().ShoppingDateGetAllToListBox());
                    dropdownUnit.Items.AddRange(ShoppingManager().ShoppingUnitAmountGetAllToListBox());
                    dropdownShoppingPlace.Items.AddRange(ShoppingManager().ShoppingPlaceGetAllToListBox());
                }
            }
            else
            {
                //oldal tiltása
                lblShoppingDateWarning.Visible = true;
                dropdownDate.Visible = false;
                btnAdd.Enabled = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblMessage.Text = ShoppingManager().ShoppingItemAdd(txtDescription.Text, txtQunatity.Text, dropdownUnit.SelectedValue, 
                                                dropdownDate.SelectedValue, dropdownShoppingPlace.SelectedValue, txtMaxPrice.Text);
        }
    }
}