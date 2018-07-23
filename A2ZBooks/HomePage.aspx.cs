using System;
using System.Collections.Generic;
using System.Data.OleDb;  // this namespace has to be added
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A2ZBooks
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         


        }

        protected void searchButton_Click(object sender, ImageClickEventArgs e)
        {

            var searchTerm = searchTextBox.Text;
            var searchCategory = searchDropDownList.SelectedValue;
            Session["category"] = searchCategory;
            
            Session["searchTerm"] = searchTerm;

            Response.Redirect("SearchPage.aspx");

        }//end of click

        protected void shoppingCartButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}