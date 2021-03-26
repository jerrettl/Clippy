namespace Clippy.Models.Admin
{
    public class ExportUserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Bio { get; set; }
        public string Roles { get; set; }
        public string Following { get; set; }
    }
}
