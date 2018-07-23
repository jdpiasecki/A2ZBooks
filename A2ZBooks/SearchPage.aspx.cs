using System;
using System.Collections.Generic;
using System.Data.OleDb;  // this namespace has to be added
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A2ZBooks
{
    public partial class SearchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            
            string searchTerm = (string) Session["searchTerm"];
            string searchCategory = (string)Session["category"];
            // components for a connection string to an Access 2016 named 'SampleDB.accdb'
            string provider = "Microsoft.ACE.OLEDB.12.0";

            // the data source for Access database if it's placed in the 'App_Data' folder of the 
            //  current project when run within Citrix
            string dataSource = "\\\\itfs1\\wpcarey\\StudentHomeFolders\\kroumina\\Documents\\VisualStudio2017\\Projects\\A2ZBooks\\A2ZBooks\\A2ZBooks.accdb";
            //string dataSource = "C:\\Users\\jdpiasecki\\Downloads\\A2ZBooks\\A2ZBooks\\A2ZBooks\\a2zbooks.accdb";
            //string dataSource = Server.MapPath("a2zbooks.accdb");

            string dbConnectionString = string.Format("Provider={0};Data Source={1};", provider, dataSource);

            OleDbConnection myConn = new OleDbConnection(dbConnectionString);
            myConn.Open();

            searchResultsLabel.Text = "Search results for " + searchCategory + " = '"  + searchTerm + "'";

            
            {
                string query = "SELECT * FROM book WHERE "+ searchCategory +" like '%" + searchTerm + "%'";  // the SampleDB Access database has a table named 'practice'
                
                if(searchCategory == "Course Number")
                {
                   query = "SELECT * FROM book WHERE ID IN (SELECT BookID FROM bookcoursebridge WHERE CourseID IN (SELECT ID FROM course WHERE CODE like '%"+ searchTerm + "%')  )";
                }
                

                OleDbCommand cmd = new OleDbCommand(query, myConn);
                var reader = cmd.ExecuteReader();

                

                while (reader.Read())
                {
                    string author = reader["Author"].ToString(); // get data from the 'Author' column
                    string title = reader["Title"].ToString();
                    string isbn = reader["ISBN"].ToString(); 
                    string price = reader["Price"].ToString();
                    //string courseID = reader["Course ID"].ToString();
                    string quantity = reader["Quantity"].ToString();
                    Button newButton = new Button();
                    newButton.Text = "Add to Cart";
                    newButton.Click += NewButton_Click;
                    newButton.ID = "btn" + reader["ID"].ToString();

                    var newRow = new System.Web.UI.HtmlControls.HtmlTableRow();

                    var newCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    newCell.InnerText = author;
                    newRow.Cells.Add(newCell);

                    var newCell1 = new System.Web.UI.HtmlControls.HtmlTableCell();
                    newCell1.InnerText = title;
                    newRow.Cells.Add(newCell1);

                    var newCell2 = new System.Web.UI.HtmlControls.HtmlTableCell();
                    newCell2.InnerText = isbn;
                    newRow.Cells.Add(newCell2);
                    
                    var newCell4 = new System.Web.UI.HtmlControls.HtmlTableCell();
                    newCell4.InnerText = string.Format("{0:C2}", double.Parse(price));
                    newRow.Cells.Add(newCell4);

                    var newCell5 = new System.Web.UI.HtmlControls.HtmlTableCell();
                    newCell5.InnerText = quantity;
                    newRow.Cells.Add(newCell5);

                    var newCell6 = new System.Web.UI.HtmlControls.HtmlTableCell();
                    newCell6.Controls.Add(newButton);
                    newRow.Cells.Add(newCell6);

                    results.Rows.Add(newRow);


                   
                }//end of while
            }//end of if

        }

        private void NewButton_Click(object sender, EventArgs e)
        {
             List<string> idList = (List<string>)Session["cart"];
            if(idList == null)
            {
                idList = new List<string>();
            }

            Button btnTemp = (Button)sender;
            string bookID = btnTemp.ID.Replace("btn", "");
            idList.Add(bookID);
            itemsInCart.Text = "Items in Cart " + idList.Count;

            Session["cart"] = idList;
        }

        protected void shoppingCartButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}