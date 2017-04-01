namespace ReportClassLibrary.BusinessModel
{
    public class AttachmentForTreament
    {
        public long Id { get; set; }

        public string AttachmentId { get; set; }

        public Treatment Treatment { get; set; }

        public long TreatmentId { get; set; }
    }
}
