namespace Project.Models.ViewModels
{
    public class RequestVM
    {
        public RequestHeader RequstHeader { get; set; }
        public RequestDetail RequestFridgeNo { get; set; }
        public IEnumerable<RequestDetail> RequestDetails { get; set; }
    }
}
