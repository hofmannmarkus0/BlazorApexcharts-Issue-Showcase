namespace BlazorApp1.Data
{
    public class DataItem
    {
        public DateTime Label { get; set; }
        public decimal Data { get; set; }

        public DataItem(DateTime label, decimal data)
        {
            Label = label;
            Data = data;
        }

        public DataItem(DateTime label, int data) : this(label, Convert.ToDecimal(data)) { }
    }
}
