using System.ComponentModel.DataAnnotations.Schema;
using UBC.Students.Domain.Domain.Entities;

namespace UBC.Students.Domain.Entities
{
    [Table("Users")]
    public class User : Entity
    {
        public int Id { get; set; } = default(int);
        public string Username { get; set; }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = EncryptPassword(value); }
        }

        public User() { }

        public User(int id, string username, string password) : base()
        {
            Id = id;
            Username = username;
            Password = password;
            Validate();
        }
        private string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string providedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, _password);
        }

        public override void Validate()
        {
            IsValid = true;
            if (string.IsNullOrEmpty(Username?.Trim()))
                IsValid = false;
            if (string.IsNullOrEmpty(Password?.Trim()) || Password.Length < 6)
                IsValid = false;
        }
    }
}
