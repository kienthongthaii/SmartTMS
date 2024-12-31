using DataLayer;
using SmartTMS_Project.HETHONG;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SmartTMS_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists("connectdb.dba"))
            {
                string conStr = "";
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);
                connect cp = (connect)bf.Deserialize(fs);
                string servername = Encryptor.Decrypt(cp.servername, "qwertyuiop", true);
                string database = Encryptor.Decrypt(cp.database, "qwertyuiop", true);
                string username = Encryptor.Decrypt(cp.username, "qwertyuiop", true);
                string password = Encryptor.Decrypt(cp.password, "qwertyuiop", true);
                conStr += "Data Source=" + servername + "; Initial Catalog =" + database + ";User ID=" + username + ";Password=" + password + ";";
                connoi = conStr;
                //myFunctions._sv = servername;
                //myFunctions._db = database;
                //myFunctions._us = username;
                //myFunctions._pw = password;

                SqlConnection con = new SqlConnection(conStr);
                try
                {
                    con.Open();

                }
                catch (Exception)
                {

                    MessageBox.Show("Không thể kết nối đến DataBase!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fs.Close();
                }
                con.Close();
                fs.Close();
                Application.Run(new frm_Login());
                //if (File.Exists("sysparam.ini"))
                //{
                //    Application.Run(new frm_Login());
                //}
                //else
                //{
                //    Application.Run(new frm_SetParam());
                //} 

            }
            else
            {
                Application.Run(new frm_ConnectDB());
            }


        }
        public static string connoi = "";
    }
}