namespace Diploma.Interfaces.Services.Order.Dto
{
    public class CreateOrderResponseDto : BaseResponseDto
    {
        public string OrderId { get; set; }

        public string OperatorId { get; set; }
    }
}
