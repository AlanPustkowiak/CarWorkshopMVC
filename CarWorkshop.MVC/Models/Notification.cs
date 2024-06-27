namespace CarWorkshop.MVC.Models
{
    public class Notification
    {
        public Notification(string message, string type)
        {
            Message = message;
            Type = type;
        }

        public string Message { get; set; }
        public string Type { get; set; }
    }
}
