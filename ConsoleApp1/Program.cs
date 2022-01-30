using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = File.ReadAllText(@"D:\RFV Refactoring\ConsoleApp1\ConsoleApp1\json1.json");
            var allHpis = JsonConvert.DeserializeObject<List<AllHPI>>(content);
            var allHpi = allHpis.First();
            HpiDetails details = new HpiDetails();
            List<HpiDetails> hpiDetails = new List<HpiDetails>();
            for (int i = 0; i < 6; i++)
                hpiDetails.Add(new HpiDetails()
                {
                    PersonId = allHpi.PersonId,
                    CcNumber = i + 1,
                    Type = HpiType.Normal,
                    IsDeleted = false
                ,
                });

            var properties = allHpi.GetType().GetProperties(); ;
            List<KeyValuePair<string, object>> hpiKeyValuePair = new List<KeyValuePair<string, object>>();
            foreach (var property in properties)
            {
                var x = Convert.ToString(property.Name.Last());
                int ccNumber = 0;

                if (int.TryParse(x, out ccNumber))
                    MappingHpiDetails(hpiDetails, allHpi, property, ccNumber);
            }
            var result = hpiDetails;
        }

        static dynamic GetValueByName<T>(T obj, PropertyInfo property)
        {
            return property.GetValue(obj, null);
        }

        static void MappingHpiDetails(List<HpiDetails> hpiDetails, AllHPI allHpi, PropertyInfo property, int ccNumber)
        {
            int i = ccNumber - 1;
            hpiDetails[i].CcNumber = ccNumber;
            if (property.Name.Contains("ChiefComplaint"))
            {
                hpiDetails[i].ChiefComplaint = GetValueByName(allHpi, property);
            }
            else if (property.Name.Contains("PopupName"))
            {
                hpiDetails[i].PopupName = GetValueByName(allHpi, property);
            }
            else if (property.Name.Contains("Detail"))
            {
                hpiDetails[i].Detail = GetValueByName(allHpi, property);
            }
            else if (property.Name.Contains("ReasonForVisit"))
            {
                hpiDetails[i].ReasonForVisit = GetValueByName(allHpi, property);
            }
            else if (property.Name.Contains("IsFollowUp"))
            {
                hpiDetails[i].IsFollowUp = GetValueByName(allHpi, property) == 1;
            }
        }
    }

    public class HpiDetails
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
        public bool IsDeleted { get; set; }
    }

    public enum HpiType
    {
        Normal,
        Dynamic,
        StudiesReviewed,
        ChronicCondition
    }
    public class AllHPI
    {
        public Guid PersonId { get; set; }
        public string ChiefComplaint1 { get; set; }
        public string PopupName1 { get; set; }
        public string Detail1 { get; set; }
        public string ReasonForVisit_1 { get; set; }
        public int IsFollowUp1 { get; set; }
        public string CCNumber1 { get; set; }
        public string ChiefComplaint2 { get; set; }
        public string PopupName2 { get; set; }
        public string Detail2 { get; set; }
        public string ReasonForVisit_2 { get; set; }
        public int IsFollowUp2 { get; set; }
        public string CCNumber2 { get; set; }
        public string ChiefComplaint3 { get; set; }
        public string PopupName3 { get; set; }
        public string Detail3 { get; set; }
        public string ReasonForVisit_3 { get; set; }
        public int IsFollowUp3 { get; set; }
        public string CCNumber3 { get; set; }
        public string ChiefComplaint4 { get; set; }
        public string PopupName4 { get; set; }
        public string Detail4 { get; set; }
        public string ReasonForVisit_4 { get; set; }
        public int IsFollowUp4 { get; set; }
        public string CCNumber4 { get; set; }
        public string ChiefComplaint5 { get; set; }
        public string PopupName5 { get; set; }
        public string Detail5 { get; set; }
        public string ReasonForVisit_5 { get; set; }
        public int IsFollowUp5 { get; set; }
        public string CCNumber5 { get; set; }
        public string ChiefComplaint6 { get; set; }
        public string PopupName6 { get; set; }
        public string Detail6 { get; set; }
        public string ReasonForVisit_6 { get; set; }
        public int IsFollowUp6 { get; set; }
        public string CCNumber6 { get; set; }
    }
}
