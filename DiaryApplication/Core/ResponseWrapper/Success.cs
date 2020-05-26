namespace DiaryApplication.Core.ResponseWrapper
{
    class Success<T> : IResponseWrapper
    {
        public T Data { get; }

        public Success(T data)
        {
            Data = data;
        }
    }
}
