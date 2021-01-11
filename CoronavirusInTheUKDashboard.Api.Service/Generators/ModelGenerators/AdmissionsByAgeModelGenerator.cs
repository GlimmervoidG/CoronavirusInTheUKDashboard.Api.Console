using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.ModelGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.AdmissionsByAge;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators.ModelGenerators
{
    public class AdmissionsByAgeModelGenerator : IModelGenerator<AdmissionsByAgePostModel>
    {
        public IOptions Option { get; set; }

        public IAdmissionsByAgeQueryTransformer AdmissionsByAgeQueryTransformer { get; set; }
        public IArchiveTransformer ArchiveQueryTransformer { get; set; }


        public AdmissionsByAgeModelGenerator(
            IOptions option,
            IAdmissionsByAgeQueryTransformer admissionsByAgeQueryTransformer,
            IArchiveTransformer archiveQueryTransformer
            )
        {
            Option = option;
            AdmissionsByAgeQueryTransformer = admissionsByAgeQueryTransformer;
            ArchiveQueryTransformer = archiveQueryTransformer;

        }

        public AdmissionsByAgePostModel GenerateModel()
        {
            var searchData = Option.TargetDate;
            var trueDate = Option.TrueDateTime;
            var doArchive = Option.UseExternalArchiveSite;


            AdmissionsByAgeQueryTransformer.SearchDate = searchData;
            var result = AdmissionsByAgeQueryTransformer.QueryAndTransform();

            var queryRecords = new List<QueryRecord>()
                .Union(result?.QueryRecords != null ? result?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .ToList();

            if (doArchive)
            {
                ArchiveQueryTransformer.ArchiveDate = trueDate;
                ArchiveQueryTransformer.QueryAndTransform(queryRecords);
            }


            var model = new AdmissionsByAgePostModel()
            {
                SearchDate = searchData,
                AdmissionsByAge = result,
                ArchiveInformation = queryRecords
            };

            return model;
        }
    }
}
