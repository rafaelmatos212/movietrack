using MovieTrack.Domain.Enums;
using MovieTrack.Domain.ValueObjects;

namespace MovieTrack.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public ICollection<UserRelation> UserRelations { get; set; } = new List<UserRelation>();
        public ICollection<MovieInteraction> MovieInteractions { get; set; } = new List<MovieInteraction>();

        private User() { }

        public User(string name, string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = new Email(email);
            PasswordHash = passwordHash;

            UserRelations = new List<UserRelation>();
            MovieInteractions = new List<MovieInteraction>();
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nome não pode ser vazio.");
            Name = name;
        }

        public void Follow(Guid relatedUserId)
        {
            if (relatedUserId == Guid.Empty || relatedUserId == this.Id) throw new ArgumentNullException("Usuário inválido para adicionar como amigo.");

            var userRelation = new UserRelation(this.Id, relatedUserId);
            UserRelations.Add(userRelation);
        }

        public void Unfollow(Guid relatedUserId)
        {
            if (relatedUserId == Guid.Empty || relatedUserId == this.Id) throw new ArgumentNullException("Usuário inválido para remover como amigo.");

            var relation = UserRelations.FirstOrDefault(ur => ur.RelatedUserId == relatedUserId);
            if (relation != null)
            {
                UserRelations.Remove(relation);
            }
        }

        public void AddInteraction(int movieId, InteractionStatus status, string? comment, float rating)
        {
            if (status == InteractionStatus.None) throw new ArgumentException("Status de interação inválido.");
            if (MovieInteractions.Any(mi => mi.MovieId == movieId && mi.UserId == this.Id)) throw new InvalidOperationException("Já existe uma interação para este filme.");

            MovieInteractions.Add(
                MovieInteraction.Create(movieId, this.Id, status, comment, rating)
            );
        }
    }
}
