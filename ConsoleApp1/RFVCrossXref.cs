using System;

namespace ConsoleApp1
{
    public class RFVXref
    {
        public Guid PK { get; set; }
        public RFVType Type { get; set; }
        public Guid CrossRefId { get; set; }
        public Guid EncounterId { get; set; }
    }

    public enum RFVType
    {
        HPI = 0, Problems = 1, Diagnosis = 2
    }
}
