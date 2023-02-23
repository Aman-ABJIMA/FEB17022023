#nullable disable
namespace FormatAPI.Models
{
    public class ResponseWrapper<T>
    {
        public T Result { get; set; }

        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }
        public string Message { get; set; }


        public ResponseWrapper()
        {

        }

        public ResponseWrapper(T result)
        {
            Result = result;
        }

        public ResponseWrapper(Exception ex)
        {
            IsError = true;
            ErrorMessage = ex.Message;
        }
        public ResponseWrapper(string message, T result) : this(result)
        {
            Message = message;
        }


        public void Set(T result)
        {
            Result = result;
        }


        public void Set(Exception ex)
        {
            IsError = true;
            ErrorMessage = ex.Message;
        }
        public void Set(string message, T result)
        {
            Message = message;
            Set(result);
        }
    }
}
