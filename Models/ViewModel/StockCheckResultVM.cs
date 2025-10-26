using System;

namespace Project.Models.ViewModel
{
    public class StockCheckResultVM
    {
        public bool IsAvailable { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}