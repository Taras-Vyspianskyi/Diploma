using System.Collections.Generic;

namespace Diploma.Interfaces.Services.Order.Dto
{
    public class GetOrderInfoResponseDto : BaseResponseDto
    {
        public IEnumerable<Entities.Order> OrderData { get; set; }
    }
}
