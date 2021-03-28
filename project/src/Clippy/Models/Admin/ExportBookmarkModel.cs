namespace Clippy.Models.Admin
{
    public class ExportBookmarkModel
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Public { get; set; }
        public bool Favorite { get; set; }
        public string Tags { get; set; }
        public string Username { get; set; }
    }
}
