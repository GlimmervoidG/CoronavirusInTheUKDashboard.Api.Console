using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UkOnsPopulationEstimatesUnofficial.Model
{
    /// <summary>
    /// What type of Area an Area is.
    /// </summary>
    public enum AreaType
    {
        [Display(Name = "Council Area")]
        CouncilArea,
        [Display(Name = "Country")]
        Country,
        [Display(Name = "County")]
        County,
        [Display(Name = "Local Government District")]
        LocalGovernmentDistrict,
        [Display(Name = "London Borough")]
        LondonBorough,
        [Display(Name = "Metropolitan County")]
        MetropolitanCounty,
        [Display(Name = "Metropolitan District")]
        MetropolitanDistrict,
        [Display(Name = "Non-metropolitan District")]
        NonMetropolitanDistrict,
        [Display(Name = "Region")]
        Region,
        [Display(Name = "Unitary Authority")]
        UnitaryAuthority,

    }
}
