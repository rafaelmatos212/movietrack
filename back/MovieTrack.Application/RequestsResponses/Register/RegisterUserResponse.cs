using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTrack.Domain.ValueObjects;

namespace MovieTrack.Application.RequestsResponse.Register
{
    public class RegisterUserResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
