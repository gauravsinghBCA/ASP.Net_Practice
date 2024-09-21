using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Practice_checkbox
{
    public partial class UserPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-EIES60D\\SQLEXPRESS01;initial catalog=checkboxdb;integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void bindgrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from checkboxpractice", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            sda.Fill(dt);
            con.Close();
            gridv.DataSource = dt;
            gridv.DataBind();


        }

        public void cleardata()
        {
            txtname.Text = "";
            rblgender.ClearSelection();
            cblhobbies.ClearSelection();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string kk = "";
            for(int i = 0; i< cblhobbies.Items.Count; i++)
            {
                if (cblhobbies.Items[i].Selected == true)
                {
                    kk += cblhobbies.Items[i] + ",";
                }          
            }
            kk = kk.TrimEnd(',');

            if (btnsubmit.Text== "submit") { 
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into checkboxpractice(name,gender,hobbies)values('"+txtname.Text+"','"+rblgender.SelectedValue+"','"+kk+"')", con);
            cmd.ExecuteNonQuery();
            con.Close() ;
            bindgrid();
            cleardata();

            }
            else if(btnsubmit.Text == "update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update checkboxpractice set name='"+txtname.Text+"',gender='"+rblgender.SelectedValue+"',hobbies='"+kk+"' where id='"+ ViewState["idd"] + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                bindgrid();
                cleardata();
                btnsubmit.Text = "submit";

            }
        }

        protected void gridv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "delet_data")
            { 
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from checkboxpractice where id='"+e.CommandArgument+"'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            bindgrid();
            }
            else if(e.CommandName== "edit_data")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from checkboxpractice where id='"+e.CommandArgument+"'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                String[] arr = dt.Rows[0]["hobbies"].ToString().Split(',');
                cblhobbies.ClearSelection();
                for (int i = 0; i < cblhobbies.Items.Count; i++)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (cblhobbies.Items[i].Text == arr[j])
                        {
                            cblhobbies.Items[i].Selected = true;
                        }
                    }
                }
                    bindgrid();
                btnsubmit.Text = "update";
                ViewState["idd"]=e.CommandArgument;


            }
    }
    }
}