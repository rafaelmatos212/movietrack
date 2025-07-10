using MovieTrack.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTrack.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; set; }

        private Email() { }

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new InvalidEmailException(email);

            Address = email;
        }
    }
}
