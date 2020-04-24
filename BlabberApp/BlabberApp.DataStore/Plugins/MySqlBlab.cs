using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Plugins
{
    /// <summary>
    /// Stores Blabs in the database
    /// </summary>
    public class MySqlBlab : IBlabPlugin
    {
        /// <summary>
        /// Connection to the database
        /// </summary>
        MySqlConnection conn;
        /// <summary>
        /// Constructor for Database object
        /// </summary>
        public MySqlBlab()
        {
            //Example Connection
            //this.dcBlab = new MySqlConnection("server=142.93.114.73;database=donbstringham;user=donbstringham;password=letmein");
            conn = new MySqlConnection("server=142.93.114.73;database=R10NGW;user=R10NGW;password=letmein");
            try
            {
                conn.Open();
            }catch (Exception ex){throw new Exception(ex.ToString());}
        }
        /// <summary>
        /// Closes connection to database
        /// </summary>
        public void Close()
        {
            conn.Close();
        }
        /// <summary>
        /// Creates a Blab object in the database
        /// </summary>
        /// <param name="obj"></param>
        public void Create(IEntity obj)
        {   
            try
            {
                Blab blab = (Blab)obj;
                DateTime now = DateTime.Now;
                //Use Don's SQL, it worked when he did it. Don't change
                string sql = "INSERT INTO blabs (sys_id, message, dttm_created, user_id) VALUES ('"
                     + blab.Id + "', '"
                     + blab.Message + "', '"
                     + now.ToString("yyyy-MM-dd HH:mm:ss") + "', '"
                     + blab.User.Email + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        /// <summary>
        /// Returns all Blabs from the database
        /// </summary>
        /// <returns>IEnumerable of Blab objects</returns>
        public IEnumerable ReadAll()
        {
            try
            {
                string sql = "SELECT * FROM blabs";
                //string sql = "Truncate table blabs";
                MySqlDataAdapter daBlabs = new MySqlDataAdapter(sql, this.conn); // To avoid SQL injection.
                MySqlCommandBuilder cbBlabs = new MySqlCommandBuilder(daBlabs);
                DataSet dsBlabs = new DataSet();

                daBlabs.Fill(dsBlabs);

                ArrayList alBlabs = new ArrayList();

                foreach( DataRow dtRow in dsBlabs.Tables[0].Rows)
                {
                    alBlabs.Add(DataRow2Blab(dtRow));
                }
                
                return alBlabs;
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }

        private Blab DataRow2Blab(DataRow row)
        {
            Blab blab = new Blab();

            blab.Id = new Guid(row["sys_id"].ToString());
            blab.Message = (string)row["message"];
            blab.User = new User((string)row["user_id"].ToString());

            return blab;
        }
        /// <summary>
        /// Read Blab by GUID
        /// </summary>
        /// <param name="Id">GUID of Blab</param>
        /// <returns>Blab associated with GUID</returns>
        public IEntity ReadById(Guid Id)
        {
            try
            {
                //Don't change Don's SQL
                string sql = "SELECT * FROM blabs WHERE blabs.sys_id = '" + Id.ToString() + "'";
                MySqlDataAdapter daBlab = new MySqlDataAdapter(sql, conn); // To avoid SQL injection.
                MySqlCommandBuilder cbBlab = new MySqlCommandBuilder(daBlab);
                DataSet dsBlab = new DataSet();

                daBlab.Fill(dsBlab, "blabs");

                DataRow row = dsBlab.Tables[0].Rows[0];
                Blab blab = new Blab();

                blab.Id = new Guid(row["sys_id"].ToString());

                return blab;
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        /// <summary>
        /// Returns Blabs associated with a User email
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>IEnumerable of Blabs from User</returns>
        public IEnumerable ReadByUserId(string email)
        {
            try
            {
                //Don't change Don's SQL
                string sql = "SELECT * FROM blabs WHERE blabs.user_id = '" + email.ToString() + "'";
                MySqlDataAdapter daBlabs = new MySqlDataAdapter(sql, conn); // To avoid SQL injection.
                MySqlCommandBuilder cbBlabs = new MySqlCommandBuilder(daBlabs);
                DataSet dsBlabs = new DataSet();

                daBlabs.Fill(dsBlabs);

                ArrayList alBlabs = new ArrayList();

                foreach( DataRow dtRow in dsBlabs.Tables[0].Rows)
                {
                    alBlabs.Add(dtRow);
                }
                
                return alBlabs;
            }catch (Exception ex){throw new Exception(ex.ToString());
    }
}
        /// <summary>
        /// I don't believe this works, but I'll troubleshoot it later.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(IEntity obj)
        {
            try
            {
                Blab blab = (Blab)obj;
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }

        /// <summary>
        /// I don't believe this works, but I'll troubleshoot it later.
        /// </summary>
        /// <param name="obj"></param>
        public void Delete(IEntity obj)
        {
            try
            {
                Blab blab = (Blab)obj;
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
    }
}