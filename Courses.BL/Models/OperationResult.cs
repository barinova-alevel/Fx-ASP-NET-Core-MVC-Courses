namespace Courses.BL.Models
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static OperationResult Ok(string message = null)
        {
            return new OperationResult { Success = true, Message = message };
        }

        public static OperationResult Error(string message)
        {
            return new OperationResult { Success = false, Message = message };
        }
    }
} 