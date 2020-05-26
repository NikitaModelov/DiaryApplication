namespace DiaryApplication.Core.ResponseWrapper
{
    class Error : IResponseWrapper
    {
        public string Message { get; }

        public Error(string message)
        {
            Message = message;
        }
    }
}
