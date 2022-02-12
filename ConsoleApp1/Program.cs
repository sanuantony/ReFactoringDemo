using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var content = File.ReadAllText(@"D:\RFV Refactoring\ConsoleApp1\ConsoleApp1\json1.json");
            var allHpis = JsonConvert.DeserializeObject<List<AllHPI>>(content);
            var allHpi = allHpis.First();
            var hpiDetails = PivotTable(allHpi);
        }

        private static List<HpiDetail> PivotTable(AllHPI allHpi)
        {
            var hpiDetails = new List<HpiDetail>();
            for (var i = 0; i < 6; i++)
                hpiDetails.Add(new HpiDetail
                {
                    PersonId = allHpi.PersonId,
                    CcNumber = i + 1,
                    Type = HpiType.Normal,
                    IsDeleted = false
                });

            var properties = allHpi.GetType().GetProperties();
            var hpiKeyValuePair = new List<KeyValuePair<string, object>>();
            foreach (var property in properties)
            {
                var x = Convert.ToString(property.Name.Last());
                var ccNumber = 0;

                if (int.TryParse(x, out ccNumber))
                    MappingHpiDetails(hpiDetails, allHpi, property, ccNumber);
            }

            return hpiDetails;
        }

        private static dynamic GetValueByName<T>(T obj, PropertyInfo property)
        {
            return property.GetValue(obj, null);
        }

        private static void MappingHpiDetails(List<HpiDetail> hpiDetails, AllHPI allHpi, PropertyInfo property,
            int ccNumber)
        {
            var i = ccNumber - 1;
            hpiDetails[i].CcNumber = ccNumber;
            if (property.Name.Contains("ChiefComplaint"))
                hpiDetails[i].ChiefComplaint = GetValueByName(allHpi, property);
            else if (property.Name.Contains("PopupName"))
                hpiDetails[i].PopupName = GetValueByName(allHpi, property);
            else if (property.Name.Contains("Detail"))
                hpiDetails[i].Detail = GetValueByName(allHpi, property);
            else if (property.Name.Contains("ReasonForVisit"))
                hpiDetails[i].ReasonForVisit = GetValueByName(allHpi, property);
            else if (property.Name.Contains("IsFollowUp"))
                hpiDetails[i].IsFollowUp = GetValueByName(allHpi, property) == 1;
        }
    }

    public enum HpiType
    {
        Normal,
        Dynamic,
        StudiesReviewed,
        ChronicCondition
    }
}