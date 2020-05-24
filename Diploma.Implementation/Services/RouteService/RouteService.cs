using Diploma.Interfaces.Services.Route.Dto;
using Diploma.Interfaces.Services.RouteProvider;
using Diploma.Interfaces.Services.RouteProvider.Dto;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diploma.Implementation.Services.RouteService
{
    public class RouteService : IRouteService
    {
        public async Task<GetRouteTimeResponseDto> GetRouteTime(GetRouteTimeRequestDto requestDto)
        {
            var url = $"https://api.mapbox.com/directions/v5/mapbox/{requestDto.TransportType}/{requestDto.CoordinatesFrom};{requestDto.CoordinatesTo}?access_token=pk.eyJ1IjoidGFyYXN2eXNwaWFzbnNreWkiLCJhIjoiY2thamw0YnEyMGJtZDJybW40ejFpMGFnbyJ9.qhz1YuWYaAwRJ20YwNmy2A";
            var responseJson = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse res = (HttpWebResponse)await request.GetResponseAsync())
            {
                using (Stream stream = res.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        responseJson = await reader.ReadToEndAsync();
                    }
                }
            }

            var response = JsonSerializer.Deserialize<FullApiResponse>(responseJson);

            return new GetRouteTimeResponseDto
            {
                Minutes = response.Routes.First().Duration
            };            
        }
    }
}
