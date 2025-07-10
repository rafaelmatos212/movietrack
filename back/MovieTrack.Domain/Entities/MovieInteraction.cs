using MovieTrack.Domain.Enums;
using MovieTrack.Domain.Exceptions;

namespace MovieTrack.Domain.Entities
{
    public class MovieInteraction
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }


        public Guid UserId { get; set; }
        public User? User { get; set; }

        public InteractionStatus Status { get; set; }
        public string? Comment { get; set; }
        public float? Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        private MovieInteraction() { }

        public static MovieInteraction Create(int movieId, Guid userId, InteractionStatus status, string? comment = null, float? rating = null)
        {
            if (movieId <= 0) throw new ArgumentException("Filme inválido.");
            if (userId == Guid.Empty) throw new ArgumentException("Usuário inválido.");
            if (comment?.Length > 500) throw new ArgumentException("Comentário muito longo.");

            return new MovieInteraction
            {
                MovieId = movieId,
                UserId = userId,
                Status = status,
                Comment = comment,
                Rating = rating,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };
        }

        public void UpdateStatus(InteractionStatus status)
        {
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateComment(string comment)
        {
            if (comment.Length > 500) throw new ArgumentException("Comentário muito longo.");
            Comment = comment;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateRating(float rating)
        {
            if (rating < 0 || rating > 10) throw new InvalidRatingException(rating);
            Rating = rating;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
