using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RelayEngineWebsite
{
    public partial class TextAlertRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=tcp:evansvilledayschoolserver.database.windows.net,1433;Database=EvansvilleDaySchoolDatabase;User ID=Usiwallabies@evansvilledayschoolserver;Password=Quokka12;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand("Select LIST_NAME from LIST", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            listCheckBox.DataSource = dt;
            listCheckBox.DataValueField = "LIST_NAME";
            listCheckBox.DataBind();
        }

        protected void submitButtonClick(object sender, EventArgs e)
        {
            Boolean okayToSend = true;

            String phoneNumber = "";

            phoneNumber += phoneNumberBox1.Text + phoneNumberBox2.Text + phoneNumberBox3.Text;

            if (phoneNumberBox1.Text == "" || phoneNumberBox2.Text == "" || phoneNumberBox3.Text == "" || firstNameBox.Text == "" || lastNameBox.Text == "" || organizationCodeBox.Text == "")
            {
                warningLabel.Text = "Please enter all fields.";
                okayToSend = false;
            }

            int i;

            if (!int.TryParse(phoneNumberBox1.Text, out i) || !int.TryParse(phoneNumberBox2.Text, out i) || !int.TryParse(phoneNumberBox3.Text, out i))
            {
                warningLabel.Text = "Please make sure your entries are correct.";
                okayToSend = false;
            }

            if (okayToSend)
            {
                String selectCommand = "SELECT USER_ID FROM USERS";

                SqlDataSource1.SelectCommand = selectCommand;
                DataView idView = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                DataTable idTable = idView.ToTable();

                DataRow lastRow = idTable.Rows[idTable.Rows.Count - 1];

                String lastID = lastRow[0].ToString();
                int incID = int.Parse(lastID) + 1;

                String insertCommand = "INSERT INTO USERS (USER_ID, USER_FNAME, USER_LNAME, USER_PHONE) VALUES ('" + incID + "', '" + firstNameBox.Text + "', '" + lastNameBox.Text + "', '" + phoneNumber + "')";

                SqlDataSource1.InsertCommand = insertCommand;
                SqlDataSource1.Insert();

                Response.Redirect("ConfirmationPage.aspx");
            }
        }

        protected void removeAllClick(object sender, EventArgs e)
        {
            phoneNumberBox1.Text = "";
            phoneNumberBox2.Text = "";
            phoneNumberBox3.Text = "";
            firstNameBox.Text = "";
            lastNameBox.Text = "";
            organizationCodeBox.Text = "";
        }
    }
}