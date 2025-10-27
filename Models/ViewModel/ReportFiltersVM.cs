using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class ReportFilters
    {
        public string? ReportType { get; set; } = "faults_summary";
        public string? DateRange { get; set; } = "this_month";

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public string? Status { get; set; }
        public string? Technician { get; set; }
    }


    public class ReportResult
    {
        public string? Title { get; set; } = "Faults Summary Report";
        public List<ColumnDefinition>? Columns { get; set; } = new List<ColumnDefinition>();
        public List<Dictionary<string, object>>? Data { get; set; } = new List<Dictionary<string, object>>();
        public List<SummaryItem>? Summary { get; set; } = new List<SummaryItem>();
        public ChartData? ChartData { get; set; }
    }

    public class ColumnDefinition
    {
        public string? Field { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
    }

    public class SummaryItem
    {
        public string? Title { get; set; }
        public string? Value { get; set; }
        public string? Color { get; set; }
        public string? Icon { get; set; }
    }

    public class ChartData
    {
        public string? Type { get; set; }
        public string? Title { get; set; }
        public List<string>? Labels { get; set; } = new List<string>();
        public List<ChartDataset>? Datasets { get; set; } = new List<ChartDataset>();
    }

    public class ChartDataset
    {
        public string? Label { get; set; }
        public List<decimal>? Data { get; set; } = new List<decimal>();
        public List<string>? BackgroundColor { get; set; } = new List<string>();
        public List<string>? BorderColor { get; set; } = new List<string>();
    }

   
    

  

  
}