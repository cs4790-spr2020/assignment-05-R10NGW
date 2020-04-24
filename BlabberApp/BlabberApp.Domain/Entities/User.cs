using System;
using System.Net.Mail;
using BlabberApp.Domain.Interfaces;
namespace BlabberApp.Domain.Entities
{
    /// <summary>
    /// I have rewritten Blab and User to match Don's
    /// This ensures that the sql given works!
    /// 
    /// User is the User equivalent to Twitter.
    /// </summary>
    public class User : IEntity
    {
        /// <summary>
        /// Getters/Setters
        /// </summary>
        public Guid Id {get; set;}
        public System.DateTime RegisterDTTM { get; set; }
        public System.DateTime LastLoginDTTM { get; set; }
        public string Email { get; private set; }
        /// <summary>
        /// Creates a Blank User
        /// </summary>
        public User()
        {
            Id = Guid.NewGuid();
        }
        /// <summary>
        /// Creates a User with an email
        /// </summary>
        /// <param name="email">User email</param>
        public User(string email)
        {
            Id = Guid.NewGuid();
            ChangeEmail(email); 
        }
        /// <summary>
        /// Changes the email of this user object.
        /// </summary>
        /// <param name="email">New email</param>
        public void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > 50)
                throw new FormatException("Email is invalid");
            try
            {
                MailAddress m = new MailAddress(email); 
            }
            catch (FormatException)
            {
                throw new FormatException(email + " is invalid");
            }
            Email = email;
        }
        /// <summary>
        /// Checks to see if this is a valid user.
        /// </summary>
        /// <returns></returns>
        //public bool IsValid()
        //{
        //    if (Id == null) throw new ArgumentNullException();
        //    if (Email == null) throw new ArgumentNullException();
        //    if (Email.ToString() == "") throw new FormatException();
        //    if (LastLoginDTTM == null) throw new ArgumentNullException();
        //    if (RegisterDTTM == null) throw new ArgumentNullException();
        //    return true;
        //}
    }
}