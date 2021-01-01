﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records.Ages
{
    public class AdmissionsByAgeRecord
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<AdmissionsByAgeItemRecord> Records { get; set; }

        public AdmissionsByAgeItemRecord Get0to5() {
            return Records.FirstOrDefault(r => r.AgeRange == "0_to_5"); 
        }
        public AdmissionsByAgeItemRecord Get6To17()
        {
            return Records.FirstOrDefault(r => r.AgeRange == "6_to_17");
        }
        public AdmissionsByAgeItemRecord Get18To64()
        {
            return Records.FirstOrDefault(r => r.AgeRange == "18_to_64");
        }
        public AdmissionsByAgeItemRecord Get65To84()
        {
            return Records.FirstOrDefault(r => r.AgeRange == "65_to_84");
        }
        public AdmissionsByAgeItemRecord Get85OrMore()
        {
            return Records.FirstOrDefault(r => r.AgeRange == "85+");
        } 
    }
}
