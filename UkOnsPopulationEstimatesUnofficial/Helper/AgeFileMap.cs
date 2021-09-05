using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UkOnsPopulationEstimatesUnofficial.Helper;
using UkOnsPopulationEstimatesUnofficial.Model;

namespace UkOnsPopulationEstimatesUnofficial.Helper
{
    class AgeFileMap : ClassMap<Area>
    {
        public AgeFileMap()
        {

            Map(m => m.Code).Convert(row =>
            {
             return row.Row.GetField<string>(0);
            });

            Map(m => m.Name).Convert(row =>
            {
                return row.Row.GetField<string>(1);
            });

            Map(m => m.Type).Convert(row =>
            {
                AreaType type = EnumParser<AreaType>.GetValueFromName(row.Row.GetField<string>(2));
                return type;
            });
             

            Map(m => m.Population).Convert(row => {

                var list = new List<PopulationCount>();
                for (int i = 0; i <= 90; i++)
                {
                    var count = new PopulationCount();
                    count.MinAge = i;

                    var pop = row.Row.GetField<string>(i + 4); 
                    count.Population = int.Parse(pop, NumberStyles.AllowThousands); 

                    if (i != 90)
                    {
                        count.MaxAge = i; 
                    } else
                    {
                        count.MaxAge = int.MaxValue;
                    }
                    list.Add(count);
                }

                return list;
            }); 
 
        }




    }
}
