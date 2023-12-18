using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderingSystem
{
    public partial class SalesOrderDetails : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["OrderingSystemConnectionString"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSalesIDDropDown();
                BindGridView();
            }
        }

        private void BindGridView()
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT ID, SalesID, ItemName, Qty, Rate FROM SalesOrderDetails", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewSalesOrder.DataSource = dt;
                GridViewSalesOrder.DataKeyNames = new string[] { "ID" };
                GridViewSalesOrder.DataBind();

                con.Close();
            }
        }

        private void BindSalesIDDropDown()
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT SalesID FROM SalesOrder", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                SalesIDDropDown.DataSource = dt;
                SalesIDDropDown.DataTextField = "SalesID";
                SalesIDDropDown.DataValueField = "SalesID";
                SalesIDDropDown.DataBind();

                con.Close();
            }
        }

        protected void SaveAll_Click(object sender, EventArgs e)
        {
            if (SalesIDDropDown.SelectedValue != "" && ItemNameTxt.Text != "" && QuantityTxt.Text != "" && RateTxt.Text != "")
            {
                using (con = new SqlConnection(cs))
                {
                    con.Open();

                    cmd = new SqlCommand("INSERT INTO SalesOrderDetails (SalesID, ItemName, Qty, Rate)" +
                        " VALUES (@salesID, @itemName, @quantity, @rate)", con);
                    cmd.Parameters.AddWithValue("@salesID", SalesIDDropDown.SelectedValue);
                    cmd.Parameters.AddWithValue("@itemName", ItemNameTxt.Text);
                    cmd.Parameters.AddWithValue("@quantity", QuantityTxt.Text);
                    cmd.Parameters.AddWithValue("@rate", RateTxt.Text);

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
                cmd = new SqlCommand("DELETE FROM SalesOrderDetails WHERE ID = @id", con);
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
                cmd = new SqlCommand("UPDATE SalesOrderDetails SET ItemName = @itemName, Qty = @quantity, Rate = @rate WHERE ID = @id", con);

                string itemName = e.NewValues["ItemName"] as string;
                decimal quantity = Convert.ToDecimal(e.NewValues["Qty"]);
                decimal rate = Convert.ToDecimal(e.NewValues["Rate"]);

                if (!string.IsNullOrWhiteSpace(itemName))
                    cmd.Parameters.AddWithValue("@itemName", itemName);
                else
                    cmd.Parameters.AddWithValue("@itemName", DBNull.Value);

                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@rate", rate);
                cmd.Parameters.AddWithValue("@id", GridViewSalesOrder.DataKeys[index].Value);

                cmd.ExecuteNonQuery();
                con.Close();
                GridViewSalesOrder.EditIndex = -1;
                BindGridView();
            }
        }



    }
}