using System.ComponentModel.DataAnnotations;

namespace MovieTrack.Domain.Enums
{
    public enum InteractionStatus
    {
        [Display(Name = "Nenhum")]
        None = 0,
        [Display(Name = "Assistido")]
        Watched = 1,
        [Display(Name = "Favorito")]
        Favorite = 2,
        [Display(Name = "Quero Assistir")]
        WantToWatch = 3,
        [Display(Name = "Abandonado")]
        Dropped = 4,
        [Display(Name = "Assistindo Novamente")]
        Rewatching = 5
    }
}
