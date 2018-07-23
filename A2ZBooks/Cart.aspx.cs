using System;
using System.Collections.Generic;
using System.Data.OleDb;


namespace A2ZBooks
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> idList = (List<string>)Session["cart"];
            if (idList == null)
            {
                idList = new List<string>();
            }

            string provider = "Microsoft.ACE.OLEDB.12.0";

            // the data source for Access database if it's placed in the 'App_Data' folder of the 
            //  current project when run within Citrix
            //string dataSource = "\\\\itfs1\\wpcarey\\StudentHomeFolders\\apedroz1\\Documents\\A2ZBooks.accdb";
            //string dataSource = "C:\\Users\\jdpiasecki\\Downloads\\A2ZBooks\\A2ZBooks\\A2ZBooks\\a2zbooks.accdb";
            string dataSource = Server.MapPath("a2zbooks.accdb");

            string dbConnectionString = string.Format("Provider={0};Data Source={1};", provider, dataSource);
            OleDbConnection myConn = new OleDbConnection(dbConnectionString);
            myConn.Open();

            string idVal = "(";
            foreach(string s in idList)
            {
                idVal += s + ",";
            }
            string query = "SELECT * FROM book WHERE ID IN " + idVal + ")";
            OleDbCommand cmd = new OleDbCommand(query, myConn);
            var reader = cmd.ExecuteReader();

            double sum = 0;
            while (reader.Read())
            {
                string author = reader["Author"].ToString(); // get data from the 'Author' column
                string title = reader["Title"].ToString();
                string isbn = reader["ISBN"].ToString();
                string price = reader["Price"].ToString();
                //string courseID = reader["Course ID"].ToString();
                int bookCount = 0;
                foreach(string s in idList)
                {
                    if(s == reader["ID"].ToString())
                    {
                        bookCount++;
                    }
                }
                string quantity = reader["Quantity"].ToString();

                var newRow = new System.Web.UI.HtmlControls.HtmlTableRow();

                var newCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                newCell.InnerText = author;
                newRow.Cells.Add(newCell);

                var newCell1 = new System.Web.UI.HtmlControls.HtmlTableCell();
                newCell1.InnerText = title;
                newRow.Cells.Add(newCell1);

                var newCell4 = new System.Web.UI.HtmlControls.HtmlTableCell();
                newCell4.InnerText = string.Format("{0:C2}", Double.Parse(price));
                newRow.Cells.Add(newCell4);

                var newCell5 = new System.Web.UI.HtmlControls.HtmlTableCell();
                newCell5.InnerText = bookCount.ToString();
                newRow.Cells.Add(newCell5);

                var newCell6 = new System.Web.UI.HtmlControls.HtmlTableCell();
                double tmpPrice = double.Parse(price);
                tmpPrice = tmpPrice * bookCount;
                newCell6.InnerText = string.Format("{0:C2}", tmpPrice);
                sum += tmpPrice;
                newRow.Cells.Add(newCell6);

                results.Rows.Add(newRow);



            }//end of while

            var anotherRow = new System.Web.UI.HtmlControls.HtmlTableRow();
            for(int i = 0; i < 4; i++)
            {
                anotherRow.Cells.Add(new System.Web.UI.HtmlControls.HtmlTableCell());
            }
            var cellTotal = new System.Web.UI.HtmlControls.HtmlTableCell();
            cellTotal.InnerHtml = "<strong>" + string.Format("{0:C2}", sum) + "</strong>";
            anotherRow.Cells.Add(cellTotal);
            results.Rows.Add(anotherRow);
        }

        protected void btnShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmation.aspx");
        }
    }
}