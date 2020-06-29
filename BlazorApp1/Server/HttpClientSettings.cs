namespace Packaging.Server
{
    public class HttpClientSettings
    {
        public string BaseAddress { get; set; }
        public Route Route { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
    public class Route
    {
        public string OData { get; set; }
        public string HttpService { get; set; }
    }
}
