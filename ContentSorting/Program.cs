using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;



namespace ContentSorting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var test = JsonConvert.DeserializeObject<List<HPI>>(File.ReadAllText(@"D:\RFV Refactoring\ConsoleApp1\ContentSorting\hpiDetails.json"));
        }
    }
    
}
public record HPI()
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
public enum HpiType
{
    Normal,
    Dynamic,
    StudiesReviewed,
    ChronicCondition
}