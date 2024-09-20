namespace InvoiceManagementWebApiCore.Model
{
    public class StandardResponse<T>
    {
        public bool Success { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; } 
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public StandardResponse(bool success, 
                                string statusCode,                      
                                string message, 
                                T data = default,  
                                List<string> errors = null) { 
            Success = success;
            StatusCode = statusCode;
            Message = message;
            Data = data;
            Errors = errors;
        }


    }
}
