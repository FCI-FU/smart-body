using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace Smart__Body.Classes
{
    public class DB
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=smartbody;password=1234");
        MySqlCommand cmd;
        MySqlDataAdapter ad = new MySqlDataAdapter();
        DataSet ds = new DataSet();

        /* return Count of Rows */
        public int getCount()
        {
            return ds.Tables[0].Rows.Count;
        }

        /* Get Data From DataSet */
        public string getData(int i,int j)
        {
            return ds.Tables[0].Rows[i][j].ToString();
        }
        
        /* Open Database Connection */
        public void open()
        {
            con.Open();
        }

        /* Select Query */
        public void select(string Query)
        {
            ad.SelectCommand = new MySqlCommand(Query,con);
            ad.Fill(ds);
        }

        /* Insert , Update and Delete Query */
        public void Modify(string Query)
        {
            cmd = new MySqlCommand(Query , con);
            cmd.ExecuteNonQuery();
        }

        /* Close Database Connection */
        public void close()
        {
            con.Close();
        }

    }
}