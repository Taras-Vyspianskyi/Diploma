using Nest;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Diploma.Interfaces.Services.Elastic.Dto
{
    [ElasticsearchType(RelationName = "crew", IdProperty = "CrewId")]
    public class CrewAvailability
    {
        [Number(Name = "CrewId")]
        public int CrewId { get; set; }

        [Number(Name = "Minutes")]
        public double Minutes { get; set; }
    }
}
