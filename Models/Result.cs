namespace CheckOrSaveBusiness.Models
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static Result Success()
        {
            return new Result { IsSuccess = true };
        }

        public static Result Error(string message)
        {
            return new Result
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}
