namespace empService.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public HashSet<string> Permissions { get; set; } = new HashSet<string>();
    }
}