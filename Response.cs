namespace itijuana
{
    public class Response<T>
    {
        public string Error { get; set; }
        public T? Result { get; set; }
        public int? Count { get; set; }
    }
}
