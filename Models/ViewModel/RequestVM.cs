namespace Project.Models.ViewModel
{
    public class RequestVM
    {
        public RequestHeader RequstHeader { get; set; }
        public RequestDetails RequestFridgeNo { get; set; }
        public IEnumerable<RequestDetails> RequstDetail { get; set; }
       
        public int SelectedFridgeId { get; set; }
    }
}
