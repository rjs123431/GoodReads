namespace GoodReads.Api.Models
{
    public class ResponseModel
    {
        public int Status { get; set; }
    }

    public class ErrorResponseModel : ResponseModel
    {
        public ErrorResponseModel(int statusCode, string errorMessage)
        {
            Status = statusCode;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; set; }
    }
}
