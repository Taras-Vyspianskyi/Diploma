using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Interfaces.Services.RouteProvider.Dto
{
    public class GetRouteTimeRequestDto
    {
        public string CoordinatesFrom { get; set; }

        public string CoordinatesTo { get; set; }

        public string TransportType { get; set; }
    }
}
