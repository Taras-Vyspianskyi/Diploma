using Diploma.Interfaces.Services.RouteProvider.Dto;
using System.Threading.Tasks;

namespace Diploma.Interfaces.Services.RouteProvider
{
    public interface IRouteService
    {
        Task<GetRouteTimeResponseDto> GetRouteTime(GetRouteTimeRequestDto requestDto);
    }
}
