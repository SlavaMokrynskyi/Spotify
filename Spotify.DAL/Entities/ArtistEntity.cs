namespace Spotify.DAL.Entities
{
    public class ArtistEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<TrackEntity> Tracks { get; set; } = [];
    }
}
