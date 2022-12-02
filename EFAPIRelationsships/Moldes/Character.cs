namespace EFAPIRelationsships.Moldes
{
    public class Character
    {
        public int id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string PublisheBy { get; set; } = String.Empty;

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
