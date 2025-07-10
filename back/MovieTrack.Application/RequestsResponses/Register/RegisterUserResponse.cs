using MovieTrack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTrack.Application.RequestsResponse.Register
{
    public class RegisterUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
    }
}
