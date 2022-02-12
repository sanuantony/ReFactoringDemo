using System;

namespace ConsoleApp1
{
    public class HpiDetail
    {
        public Guid PersonId { get; set; }
        public int CcNumber { get; set; }
        public string ChiefComplaint { get; set; }
        public string PopupName { get; set; }
        public string Detail { get; set; }
        public string ReasonForVisit { get; set; }
        public bool IsFollowUp { get; set; }
        public bool IsDuplicate { get; set; }
        public HpiType Type { get; set; }
        public bool IsChronicCondition { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
    }
}