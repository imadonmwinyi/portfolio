
using System;

namespace ResumeApp.Models
{
    public class Message
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Comment { get; set; }

    }
}
