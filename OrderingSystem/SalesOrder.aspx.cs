using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderingSystem
{
    public partial class SalesOrder : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["OrderingSystemConnectionString"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        private void BindGridView()
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT SalesID, CustomerName, CONVERT(datetime, Created_At) AS Created_At_Converted, Vihacle_Name, Delivary_Date FROM SalesOrder", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewSalesOrder.DataSource = dt;
                GridViewSalesOrder.DataKeyNames = new string[] { "SalesID" }; 
                GridViewSalesOrder.DataBind();

                con.Close();
            }
        }





        protected void SaveAll_Click(object sender, EventArgs e)
        {
            if (TxtName.Text != "")
            {
                using (con = new SqlConnection(cs))
                {
                    con.Open();



                    cmd = new SqlCommand("insert into SalesOrder (CustomerName,Vihacle_Name,Delivary_Date)" +
                        " values(@customerName,@vihacleName,@delivaryDate)", con);
                    cmd.Parameters.AddWithValue("@customerName", TxtName.Text);
                    cmd.Parameters.AddWithValue("@vihacleName", VihacleText.Text);
                    cmd.Parameters.AddWithValue("@delivaryDate", DelivaryDateTxt.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    con.Close();

                    BindGridView();
                }
            }
        }

        protected void GridViewSalesOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM SalesOrder WHERE SalesID = @id", con);
                cmd.Parameters.AddWithValue("@id", GridViewSalesOrder.DataKeys[index].Value);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGridView();
            }
        }

        protected void GridViewSalesOrder_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewSalesOrder.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridViewSalesOrder_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewSalesOrder.EditIndex = -1;
            BindGridView();
        }

        protected void GridViewSalesOrder_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;

            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("UPDATE SalesOrder SET CustomerName = @customerName, Vihacle_Name = @vihacleName, Delivary_Date = @delivaryDate WHERE SalesID = @id", con);

                string customerName = e.NewValues["CustomerName"] as string;
                string vihacleName = e.NewValues["Vihacle_Name"] as string;
                string delivaryDate = e.NewValues["Delivary_Date"] as string;

                if (!string.IsNullOrWhiteSpace(customerName))
                    cmd.Parameters.AddWithValue("@customerName", customerName);
                else
                    cmd.Parameters.AddWithValue("@customerName", DBNull.Value);

                if (!string.IsNullOrWhiteSpace(vihacleName))
                    cmd.Parameters.AddWithValue("@vihacleName", vihacleName);
                else
                    cmd.Parameters.AddWithValue("@vihacleName", DBNull.Value);

                if (!string.IsNullOrWhiteSpace(delivaryDate))
                    cmd.Parameters.AddWithValue("@delivaryDate", delivaryDate);
                else
                    cmd.Parameters.AddWithValue("@delivaryDate", DBNull.Value);

                cmd.Parameters.AddWithValue("@id", GridViewSalesOrder.DataKeys[index].Value);

                cmd.ExecuteNonQuery();
                con.Close();
                GridViewSalesOrder.EditIndex = -1;
                BindGridView();
            }
        }


    }
}