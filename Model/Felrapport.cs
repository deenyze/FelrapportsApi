namespace FelrapportsApi.Model
{
    public class Felrapport
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string RecreatingSteps { get; set; } = string.Empty;
        public string ExpectedBehavior { get; set; } = string.Empty;
        public string ActualBehavior { get; set; } = string.Empty;
        public int Frequency { get; set; }
        public string Logs { get; set; } = string.Empty;
        public string SystemInformation { get; set; } = string.Empty;
    }
}
