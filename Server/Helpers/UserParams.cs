namespace Server.Helpers
{
    public class UserParams
    {
        private const int MAX_PAGE_SIZE = 50;

        public int Page { get; set; } = 1;

        private int size = 10;
        public int Size
        {
            get { return size; }
            set { size = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value; }
        }

        public int UserId { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; } = 18;
        public int MaxAge { get; set; } = 99;
        public string OrderBy { get; set; }
        public bool Likees { get; set; } = false;
        public bool Likers { get; set; } = false;
    }
}
