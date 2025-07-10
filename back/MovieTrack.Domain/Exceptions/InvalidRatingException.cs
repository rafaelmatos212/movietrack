using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTrack.Domain.Exceptions
{
    public class InvalidRatingException : DomainException
    {
        public InvalidRatingException(float rating) : base($"A nota '{rating}' deve estar entre 0 e 10.") { }
        public InvalidRatingException() : base("A nota fornecida é inválida. Deve estar entre 0 e 10.") { }
    }
}
