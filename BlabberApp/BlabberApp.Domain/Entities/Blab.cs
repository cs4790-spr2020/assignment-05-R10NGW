using System;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.Domain.Entities
{
    /// <summary>
    /// I have rewritten Blab and User to match Don's
    /// This ensures that the sql given works!
    /// 
    /// Blab is the BlabberApp equivalent to a Tweet.
    /// </summary>
    public class Blab : IEntity
    {
        /// <summary>
        /// constructor, creates a blank blab with a blank user.
        /// </summary>
        public Blab()
        {
            Id = Guid.NewGuid();
            User = new User();
            Message = "";
            DTTM = DateTime.Now;
        }
        /// <summary>
        /// Creates a Blab with a message and a blank user.
        /// </summary>
        /// <param name="Message">Blab Message</param>
        public Blab(string Message)
        {
            Id = Guid.NewGuid();
            User = new User();
            this.Message = Message;
            DTTM = DateTime.Now;
        }
        /// <summary>
        /// Creates a Blank Blab with a User object
        /// </summary>
        /// <param name="user">User object</param>
        public Blab(User user)
        {
            Id = Guid.NewGuid();
            User = user;
            Message = "";
            DTTM = DateTime.Now;
        }
        /// <summary>
        /// Creates a Blab with a User and message
        /// </summary>
        /// <param name="Message">Blab Message</param>
        /// <param name="user">User for the Blab</param>
        public Blab(string Message, User user)
        {
            Id = Guid.NewGuid();
            User = user;
            this.Message = Message;
            DTTM = DateTime.Now;
        }
        /// <summary>
        /// Getter/Setters
        /// </summary>
        public Guid Id { get; set; }
        public DateTime DTTM { get; }
        public string Message { get; set; }
        public User User { get; set; }

    }
}