namespace Project.Models
{
    public class ReportResult
    {
        public string Title { get; set; }
        public List<SummaryItem> Summary { get; set; }
        public List<Dictionary<string, object>> Data { get; set; }
        public List<ColumnDefinition> Columns { get; set; }
        public ChartData ChartData { get; set; }
    }

    public class SummaryItem
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string Trend { get; set; }
    }

    public class ColumnDefinition
    {
        public string Field { get; set; }
        public string Title { get; set; }
        public string Type { get; set; } // text, number, date, currency
    }

    public class ChartData
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public List<string> Labels { get; set; }
        public List<ChartDataset> Datasets { get; set; }
    }

    public class ChartDataset
    {
        public string Label { get; set; }
        public List<decimal> Data { get; set; }
        public List<string> BackgroundColor { get; set; }
        public List<string> BorderColor { get; set; }
    }
}
