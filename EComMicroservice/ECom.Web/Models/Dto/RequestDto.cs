using static ECom.Web.Utility.SD;

namespace ECom.Web.Models.Dto
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public object Data { get; set; }
        public string Url { get; set; }
        public string AccessToken { get; set; }
    }
}
