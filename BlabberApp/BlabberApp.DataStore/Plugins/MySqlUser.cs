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
    /// Stores Users in database
    /// </summary>
    public class MySqlUser : IUserPlugin
    {
        /// <summary>
        /// Connection to database
        /// </summary>
        MySqlConnection conn;
        /// <summary>
        /// Constructor for database connection
        /// </summary>
        public MySqlUser()
        {
            //Example connection
            //conn = new MySqlConnection("server=142.93.114.73;database=donbstringham;user=donbstringham;password=letmein");
            conn = new MySqlConnection("server=142.93.114.73;database=R10NGW;user=R10NGW;password=letmein");
            try
            {
                conn.Open();
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        /// <summary>
        /// Closes database connection
        /// </summary>
        public void Close()
        {
            conn.Close();
        }
        /// <summary>
        /// Creates User, stores in database
        /// </summary>
        /// <param name="obj">User object to Create</param>
        public void Create(IEntity obj)
        {
            try
            {
                ////TEMP
                //string tempsql = "CREATE TABLE `R10NGW`.`users` (`id` INT NOT NULL AUTO_INCREMENT,  `sys_id` VARCHAR(36) NOT NULL,  `email` VARCHAR(255) NULL,  `dttm_registration` DATETIME NULL,  `dttm_last_login` DATETIME NULL,  PRIMARY KEY(`id`),  UNIQUE INDEX `Id_UNIQUE` (`id` ASC),  UNIQUE INDEX `sys_id_UNIQUE` (`sys_id` ASC)); ";
                //MySqlCommand tempcmd = new MySqlCommand(tempsql, conn);
                //tempcmd.ExecuteNonQuery();
                //tempsql = "CREATE TABLE `R10NGW`.`blabs` (  `id` INT NOT NULL AUTO_INCREMENT,  `sys_id` VARCHAR(36) NOT NULL,  `message` VARCHAR(255) NULL,  `dttm_created` DATETIME NOT NULL,  `user_id` VARCHAR(36) NOT NULL,  PRIMARY KEY(`id`),  UNIQUE INDEX `id_UNIQUE` (`id` ASC),  UNIQUE INDEX `sys_id_UNIQUE` (`sys_id` ASC)); ";
                //tempcmd = new MySqlCommand(tempsql, conn);
                //tempcmd.ExecuteNonQuery();
                /////TEMP

                User user = (User)obj;
                DateTime now = DateTime.Now;
                //Don't change the SQL, if it works for Don, it works for me.
                string sql = "INSERT INTO users (sys_id, email, dttm_registration, dttm_last_login) VALUES ('"
                     + user.Id + "', '"
                     + user.Email + "', '"
                     + now.ToString("yyyy-MM-dd HH:mm:ss")
                     + "', '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        /// <summary>
        /// Get all users from database
        /// </summary>
        /// <returns>IEnumerable of User objects</returns>
        public IEnumerable ReadAll()
        {
            try
            {
                //string sql = "SELECT * FROM users Where email in (Select email from users Group By email)";
                string sql = "Select Max(sys_id) as sys_id, email, Max(dttm_registration) as dttm_registration, Max(dttm_last_login) as dttm_last_login from users Group by email";
                MySqlDataAdapter daUser = new MySqlDataAdapter(sql, conn); // To avoid SQL injection.
                MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
                DataSet dsUsers = new DataSet();

                daUser.Fill(dsUsers, "users");

                ArrayList users = new ArrayList();

                foreach (DataRow row in dsUsers.Tables[0].Rows)
                {
                    users.Add(DataRow2User(row));
                }

                return users;
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        /// <summary>
        /// Get User object by GUID
        /// </summary>
        /// <param name="Id">User GUID</param>
        /// <returns>User associated with GUID</returns>
        public IEntity ReadById(Guid Id)
        {
            try
            {
                string sql = "SELECT * FROM users WHERE users.sys_id = '" + Id.ToString() + "'";
                MySqlDataAdapter daUser = new MySqlDataAdapter(sql, conn); // To avoid SQL injection.
                MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
                DataSet dsUser = new DataSet();

                daUser.Fill(dsUser, "users");

                DataRow row = dsUser.Tables[0].Rows[0];

                return DataRow2User(row);
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        /// <summary>
        /// Gets User by Email
        /// </summary>
        /// <param name="email">User Email</param>
        /// <returns>User associated with Email</returns>
        public IEntity ReadByUserEmail(string email)
        {
            try
            {
                //Too afraid to change the SQL, still don't think tostring is necessary.
                string sql = "SELECT * FROM users WHERE users.email = '" + email.ToString() + "'";
                MySqlDataAdapter daUser = new MySqlDataAdapter(sql, conn); // To avoid SQL injection.
                MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
                DataSet dsUser = new DataSet();

                daUser.Fill(dsUser, "users");

                DataRow row = dsUser.Tables[0].Rows[0];

                return DataRow2User(row);
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        /// <summary>
        /// I'm not sure this works, but I'll troubleshoot it later.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(IEntity obj)
        {
            try
            {
                User user = (User)obj;
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        /// <summary>
        /// Deletes User from database
        /// </summary>
        /// <param name="obj">User Object to delete</param>
        public void Delete(IEntity obj)
        {
            try
            {
                User user = (User)obj;
                string sql = "DELETE FROM users WHERE users.email='" + user.Email + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        /// <summary>
        /// Converts query results to User objects
        /// </summary>
        /// <param name="row">Data row to User</param>
        /// <returns>User object</returns>
        private User DataRow2User(DataRow row)
        {
            User user = new User();

            user.Id = new Guid(row["sys_id"].ToString());
            user.ChangeEmail(row["email"].ToString());
            user.RegisterDTTM = (DateTime)row["dttm_registration"];
            user.LastLoginDTTM = (DateTime)row["dttm_last_login"];

            return user;
        }
    }
}