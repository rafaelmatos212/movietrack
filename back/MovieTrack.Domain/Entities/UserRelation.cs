namespace MovieTrack.Domain.Entities
{
    public class UserRelation
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid RelatedUserId { get; set; }
        public User RelatedUser { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        private UserRelation() { }

        public UserRelation(Guid userId, Guid relatedUserId)
        {
            if (userId == Guid.Empty) throw new ArgumentException("Usuário inválido.");
            if (relatedUserId == Guid.Empty) throw new ArgumentException("Usuário relacionado inválido.");
            if (userId == relatedUserId) throw new ArgumentException("Você não pode seguir a si mesmo.");

            UserId = userId;
            RelatedUserId = relatedUserId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
