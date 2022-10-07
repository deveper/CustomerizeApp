namespace Customerize.Common.Dtos
{
    public class DataTableModel
    {
        public string? Draw { get; set; }
        public string? Start { get; set; }
        public string? Length { get; set; }
        public string? SortColumn { get; set; }
        public string? SortColumnDirection { get; set; }
        public string? SsearchValue { get; set; }
        public int PageSize { get; set; }
        public int Skip { get; set; }
        public int? RecordsTotal { get; set; } = 0;
    }
}
