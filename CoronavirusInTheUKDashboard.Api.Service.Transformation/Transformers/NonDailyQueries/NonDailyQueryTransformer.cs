using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NoneDailyQueries; 
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NonDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.NonDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.NonDailyQueries
{
   public class NonDailyQueryTransformer : INonDailyQueryTransformer
    {
        public DateTime TargetDate { get; set; }
        public INonDailyQuery Query { get; set; }
        public NonDailyQueryTransformer(INonDailyQuery query)
        {
            Query = query;
        }
        public Result<IrregularRecord> QueryAndTransform()
        {
            Query.TargetDate = TargetDate;
            var result = Query.DoQuery();

            var records = new List<IrregularRecord>();

            var filteredResults = result.Data.Where(d => d.Date <= TargetDate).ToList();

            // Get the most up to date record for each metric
            var capacity = filteredResults.FirstOrDefault(d => d.Capacity.HasValue);
            var capacityPCR = filteredResults.FirstOrDefault(d => d.CapacityPCR.HasValue);
            var patientsInHospital = filteredResults.FirstOrDefault(d => d.PatientsInHospital.HasValue);
            var patientsInVentilatorBeds = filteredResults.FirstOrDefault(d => d.PatientsInVentilatorBeds.HasValue);
            var patientsAdmitted = filteredResults.FirstOrDefault(d => d.PatientsAdmitted.HasValue);
            var weeklyOnsDeaths = filteredResults.FirstOrDefault(d => d.WeeklyOnsDeaths.HasValue);
            var totalOnsDeaths = filteredResults.FirstOrDefault(d => d.TotalOnsDeaths.HasValue);
            //var weeklyFirstDose = filteredResults.FirstOrDefault(d => d.WeeklyFirstDose.HasValue);
            //var totalFirstDose = filteredResults.FirstOrDefault(d => d.TotalFirstDose.HasValue);

            records.Add(GetRecord(NameConstants.NoneDailyQuery_Capacity, capacity, capacity?.Capacity));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_CapacityPCR, capacityPCR, capacityPCR?.CapacityPCR));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_PatientsInHospital, patientsInHospital, patientsInHospital?.PatientsInHospital));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_PatientsInVentilatorBeds, patientsInVentilatorBeds, patientsInVentilatorBeds?.PatientsInVentilatorBeds));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_PatientsAdmitted, patientsAdmitted, patientsAdmitted?.PatientsAdmitted));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_WeeklyOnsDeaths, weeklyOnsDeaths, weeklyOnsDeaths?.WeeklyOnsDeaths));
            records.Add(GetRecord(NameConstants.NoneDailyQuery_TotalOnsDeaths, totalOnsDeaths, totalOnsDeaths?.TotalOnsDeaths));
            //records.Add(GetRecord(NameConstants.NoneDailyQuery_TotalFirstDose, weeklyFirstDose, weeklyFirstDose?.WeeklyFirstDose));
            //records.Add(GetRecord(NameConstants.NoneDailyQuery_WeeklyFirstDose, totalFirstDose, totalFirstDose?.TotalFirstDose));

            records = records.Where(r => r != null).ToList();
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
                    IsNew = (record.Date == TargetDate || record.Date == TargetDate.AddDays(-1))
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
