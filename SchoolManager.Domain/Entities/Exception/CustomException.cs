namespace SchoolManager.Domain.Entities.Exception
{
    public class CustomException : System.Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }
}
