namespace Project.Models.ViewModel
{
    public class RequestVM
    {
        public RequestHeader RequestHeader { get; set; }
        public RequestDetails RequestFridgeNo { get; set; }
        public IEnumerable<RequestDetails> RequestDetails { get; set; }
       
        public int SelectedFridgeId { get; set; }
    }
}
