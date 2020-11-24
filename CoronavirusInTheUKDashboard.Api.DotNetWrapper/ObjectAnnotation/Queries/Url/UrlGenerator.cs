using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Formats;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.LatestBys;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Releases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Structure;
using System.Reflection;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries.Url
{
    public class UrlGenerator
    {
        public QueryOptions Options { get; set; }
        public Type StructureType { get; set; }

        public string GetUrl()
        {
            if (Options == null)
            {
                Options = QueryOptions.Default();
            }
            var request = new ApiRequest();

            var filters = GetFilter();
            var structure = GetStructure();
            var format = GetFormat();
            var release = GetRelease();

            request.Parts.Add(filters);
            request.Parts.Add(structure);
            request.Parts.Add(format);
            request.Parts.Add(release);

            return GetUrl(request);
        }

        private string GetUrl(ApiRequest urlFull)
        {  
            var uri = new Uri(new Uri(UrlConstants.DashboardApiUrl), urlFull.ToString()).ToString();  
            var escapedUri = Uri.EscapeUriString(uri);
            return escapedUri;
        }

        private UrlConstruction.Filters.Filter GetFilter()
        {
            var filters = new UrlConstruction.Filters.Filter();
            if (Options.Filter.AreaType != null)
            {
                filters.Parts.Add(new UrlConstruction.Filters.FilterElements.AreaTypeFilter() { Value = Options.Filter.AreaType.Value });
            }
            if (Options.Filter.AreaCode != null)
            {
                filters.Parts.Add(new UrlConstruction.Filters.FilterElements.AreaCodeFilter() { Value = Options.Filter.AreaCode.Value });
            }
            if (Options.Filter.AreaName != null)
            {
                filters.Parts.Add(new UrlConstruction.Filters.FilterElements.AreaNameFilter() { Value = Options.Filter.AreaName.Value });
            }
            if (Options.Filter.Date != null)
            {
                filters.Parts.Add(new UrlConstruction.Filters.FilterElements.DateFilter() { Value = Options.Filter.Date.Value });
            }
            return filters;

        }
        private Structure GetStructure()
        {
            var body = ParseStructureObject("", StructureType);
            Structure master = new Structure() { Parts = body.Parts };
            return master;
        }
        private StructureBody ParseStructureObject(string name, Type t)
        {

            StructureBody part = new StructureBody() { Name = name };
            var properties = t.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public);
            foreach (var prop in properties)
            {
                var metric = (StructureMetricAttribute)Attribute.GetCustomAttribute(prop, typeof(StructureMetricAttribute), true);

                if (metric != null)
                {
                    part.Parts.Add(new StructureMetric() { Name = prop.Name, Metric = metric.Metric });
                }

                var structure = (StructureAttribute)Attribute.GetCustomAttribute(prop, typeof(StructureAttribute), true);
                if (structure != null)
                {
                    part.Parts.Add(ParseStructureObject(prop.Name, prop.PropertyType));
                }
            }
            return part;
        }

        private UrlConstruction.Formats.FormatPart GetFormat()
        {
            return new UrlConstruction.Formats.FormatPart() { Type = Options.Format.Value };
        }
        private UrlConstruction.Releases.Release GetRelease()
        {
            if (Options.Release == null)
            {
                return new UrlConstruction.Releases.ReleaseByLatest();
            }
            else
            {
                return new UrlConstruction.Releases.ReleaseByDate() { Value = Options.Release.Value };
            }
        }

    }
}
