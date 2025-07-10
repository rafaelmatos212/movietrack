using MovieTrack.Domain.Entities;

namespace MovieTrack.Tests.Domain.Tests.Entities
{
    public class UserTest
    {
        [Fact]
        public void User_CanBeCreated_WithValidData()
        {
            // Arrange
            string name = "Rafael";
            string email = "rafael@email.com";
            string passwordHash = "hashedpassword123";

            // Act
            var user = new User(name, email, passwordHash);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(name, user.Name);
            Assert.Equal(email, user.Email.Address);
            Assert.Equal(passwordHash, user.PasswordHash);
        }
    }
}
