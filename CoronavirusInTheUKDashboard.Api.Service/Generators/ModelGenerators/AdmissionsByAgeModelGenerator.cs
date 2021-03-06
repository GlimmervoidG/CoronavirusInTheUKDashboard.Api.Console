﻿using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries;
using Microsoft.Extensions.Logging;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator.ModelGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.AdmissionsByAge;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators.ModelGenerators
{
    public class AdmissionsByAgeModelGenerator : IModelGenerator<AdmissionsByAgePostModel>
    {
        public IOptions Option { get; set; }

        public IAdmissionsByAgeQueryTransformer AdmissionsByAgeQueryTransformer { get; set; }
        public IArchiveTransformer ArchiveQueryTransformer { get; set; }
        private ILogger<AdmissionsByAgeModelGenerator> Logger { get; set; }


        public AdmissionsByAgeModelGenerator(
            IOptions option,
            IAdmissionsByAgeQueryTransformer admissionsByAgeQueryTransformer,
            IArchiveTransformer archiveQueryTransformer,
            ILogger<AdmissionsByAgeModelGenerator> logger
            )
        {
            Option = option;
            AdmissionsByAgeQueryTransformer = admissionsByAgeQueryTransformer;
            ArchiveQueryTransformer = archiveQueryTransformer;
            Logger = logger;

        }

        public AdmissionsByAgePostModel GenerateModel()
        {
            Logger.LogInformation($"Starting Model Creation.");

            var searchData = Option.TargetDate;
            var trueDate = Option.TrueDateTime;
            var doArchive = Option.UseExternalArchiveSite;


            AdmissionsByAgeQueryTransformer.TargetDate = searchData;
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
                TargetDate = searchData,
                AdmissionsByAge = result,
                ArchiveInformation = queryRecords
            };

            return model;
        }
    }
}
