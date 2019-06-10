namespace DatingApp.Helpers
{
    public class MessageParams
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

        public string MessageContainer { get; set; } = "Unread";
    }
}