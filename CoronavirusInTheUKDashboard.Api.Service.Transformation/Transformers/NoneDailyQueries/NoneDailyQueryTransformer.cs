using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NoneDailyQueries; 
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.NoneDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.NoneDailyQueries
{
   public class NoneDailyQueryTransformer
    {
        public DateTime SearchDate { get; set; }
        public Result<IrregularRecord> QueryAndTransform()
        {
            var query = new NoneDailyQuery() { SearchDate = SearchDate };
            var result = query.DoQuery();

            var records = new List<IrregularRecord>();

            var filteredResults = result.Data.Where(d => d.Date <= SearchDate).ToList();

            // Get the most up to date record for each metric
            var capacity = filteredResults.FirstOrDefault(d => d.Capacity.HasValue);
            var capacityPCR = filteredResults.FirstOrDefault(d => d.CapacityPCR.HasValue);
            var patientsInHospital = filteredResults.FirstOrDefault(d => d.PatientsInHospital.HasValue);
            var patientsInVentilatorBeds = filteredResults.FirstOrDefault(d => d.PatientsInVentilatorBeds.HasValue);
            var patientsAdmitted = filteredResults.FirstOrDefault(d => d.PatientsAdmitted.HasValue);
            var weeklyOnsDeaths = filteredResults.FirstOrDefault(d => d.WeeklyOnsDeaths.HasValue);
            var totalOnsDeaths = filteredResults.FirstOrDefault(d => d.TotalOnsDeaths.HasValue);
            var weeklyFirstDose = filteredResults.FirstOrDefault(d => d.WeeklyFirstDose.HasValue);
            var totalFirstDose = filteredResults.FirstOrDefault(d => d.TotalFirstDose.HasValue);

            records.Add(GetRecord(NameConstants.NoneDailyQuery_Capacity, capacity, capacity?.Capacity));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_CapacityPCR, capacityPCR, capacityPCR?.CapacityPCR));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_PatientsInHospital, patientsInHospital, patientsInHospital?.PatientsInHospital));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_PatientsInVentilatorBeds, patientsInVentilatorBeds, patientsInVentilatorBeds?.PatientsInVentilatorBeds));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_PatientsAdmitted, patientsAdmitted, patientsAdmitted?.PatientsAdmitted));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_WeeklyOnsDeaths, weeklyOnsDeaths, weeklyOnsDeaths?.WeeklyOnsDeaths));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_TotalOnsDeaths, totalOnsDeaths, totalOnsDeaths?.TotalOnsDeaths));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_TotalFirstDose, weeklyFirstDose, weeklyFirstDose?.WeeklyFirstDose));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_WeeklyFirstDose, totalFirstDose, totalFirstDose?.TotalFirstDose));


            records = records.OrderByDescending(r => r.Date).ToList();
             
            return new Result<IrregularRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.NoneDailyQuery_Name, Url = result.Url }
                }
            };
        }

        private IrregularRecord GetRecord(string name, NonDailyQueryModel record, long? value)
        {
            if (record != null)
            {
                return new IrregularRecord()
                {
                    Date = record.Date,
                    LastReportedTotal = value,
                    Name = name,
                    IsNew = (record.Date == SearchDate || record.Date == SearchDate.AddDays(-1))
                };
            }
            else
            {
                return null;
                //return new IrregularRecord()
                //{
                //    Date = DateTime.MinValue,
                //    LastReportedTotal = null,
                //    Name = name
                //};
            } 
        }


    }
}
