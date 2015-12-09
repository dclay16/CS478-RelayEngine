﻿using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CS478_RelayEngine
{
    public partial class text_message_page : System.Web.UI.Page
    {
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Shane\\Documents\\CS478-RelayEngine\\CS478-RelayEngine\\CS478-RelayEngine\\App_Data\\Project_Database.mdf;Integrated Security=True";
        public static string testSender = "egestas@mus.com";
        int list_id;
        int tokens;
        int sub_one = 0, sub_two = 0, sub_three = 0, sub_four = 0, sub_five = 0;
        int recipients = 0;
        List<int> subs = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label5.Text = testSender;

            SqlDataReader dr = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                String commandText = "SELECT LIST_ID FROM LIST WHERE LIST_ID IN (SELECT LIST_ID FROM AUTHORIZATIONS WHERE SENDER_ID IN (SELECT SENDER_ID FROM SENDER WHERE SENDER_EMAIL='egestas@mus.com'));";

                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list_id = dr.GetInt32(0);
                        checkLists();
                    }
                    dr.Close();
                }

            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                String commandText = "SELECT LIST_ID FROM SUBSCRIPTION;";

                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);

                        if (id == 0) sub_one++;
                        else if (id == 1) sub_two++;
                        else if (id == 2) sub_two++;
                        else if (id == 3) sub_three++;
                        else if (id == 4) sub_four++;
                    }
                }
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                String commandText = "SELECT ADMIN_TOKENS FROM ADMINISTRATOR;";

                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        tokens = dr.GetInt32(0);
                        Label6.Text = tokens.ToString();
                        checkTokens();
                    }
                    dr.Close();
                }
            }

            CheckBox1.Text = "School Cancellation/Delays (" + sub_one.ToString() + " recipients)";
            CheckBox2.Text = "Upper School Sports (" + sub_two.ToString() + " recipients)";
            CheckBox3.Text = "Lower School Sports (" + sub_three.ToString() + " recipients)";
            CheckBox4.Text = "Upper School Announcements (" + sub_four.ToString() + " recipients)";
            CheckBox5.Text = "Lower School Announcements (" + sub_five.ToString() + " recipients)";
        }

        public void checkLists()
        {
            if (list_id == 0) CheckBox1.Visible = true;
            else if (list_id == 1) CheckBox2.Visible = true;
            else if (list_id == 2) CheckBox3.Visible = true;
            else if (list_id == 3) CheckBox4.Visible = true;
            else if (list_id == 4) CheckBox5.Visible = true;
        }

        public void checkTokens()
        {
            if (sub_one > tokens)
            {
                CheckBox1.Enabled = false;
                CheckBox1.Text = "Insufficient number of tokens to send this message";
                CheckBox1.ForeColor = System.Drawing.Color.Red;
            }
            if (sub_two > tokens)
            {
                CheckBox2.Enabled = false;
                CheckBox2.Text = "Insufficient number of tokens to send this message";
                CheckBox2.ForeColor = System.Drawing.Color.Red;
            }
            if (sub_three > tokens)
            {
                CheckBox3.Enabled = false;
                CheckBox3.Text = "Insufficient number of tokens to send this message";
                CheckBox3.ForeColor = System.Drawing.Color.Red;
            }
            if (sub_four > tokens)
            {
                CheckBox4.Enabled = false;
                CheckBox4.Text = "Insufficient number of tokens to send this message";
                CheckBox4.ForeColor = System.Drawing.Color.Red;
            }
            if (sub_five > tokens)
            {
                CheckBox5.Enabled = false;
                CheckBox5.Text = "Insufficient number of tokens to send this message";
                CheckBox5.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox2.Checked = false;
            CheckBox3.Checked = false;
            CheckBox4.Checked = false;
            CheckBox5.Checked = false;
        }
        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox1.Checked = false;
            CheckBox3.Checked = false;
            CheckBox4.Checked = false;
            CheckBox5.Checked = false;
        }
        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox1.Checked = false;
            CheckBox2.Checked = false;
            CheckBox4.Checked = false;
            CheckBox5.Checked = false;
        }
        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox1.Checked = false;
            CheckBox3.Checked = false;
            CheckBox2.Checked = false;
            CheckBox5.Checked = false;
        }
        protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox1.Checked = false;
            CheckBox3.Checked = false;
            CheckBox4.Checked = false;
            CheckBox2.Checked = false;
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Label7.Text = "Message (160 Characters Max)   " + TextBox1.Text.Length + "/160";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Length > 160)
            {
                Label8.Text = "Unable to send message: your message contains too many characters.";
                Label8.Visible = true;
            }
            else if (TextBox1.Text.Length == 0)
            {
                Label8.Text = "Unable to send message: message is blank.";
                Label8.Visible = true;
            }
            else if (CheckBox1.Checked == false && CheckBox2.Checked == false && CheckBox3.Checked == false
                && CheckBox4.Checked == false && CheckBox5.Checked == false)
            {
                Label8.Text = "Unable to send message: you did not select a list.";
                Label8.Visible = true;
            }
            else
            {
                if (CheckBox1.Checked == true) recipients = sub_one;
                else if (CheckBox2.Checked == true) recipients = sub_two;
                else if (CheckBox3.Checked == true) recipients = sub_three;
                else if (CheckBox4.Checked == true) recipients = sub_four;
                else if (CheckBox5.Checked == true) recipients = sub_five;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    String commandText = "UPDATE ADMINISTRATOR SET ADMIN_TOKENS=ADMIN_TOKENS-" + recipients.ToString() + ";";

                    SqlCommand cmd = new SqlCommand(commandText, con);
                    cmd.ExecuteReader();
                }


                Response.Redirect("text-message-confirmation.aspx");
            }
        }
    }
}