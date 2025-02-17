using Karen_Store.Common.Dto;
namespace Karen_Store.Application.Services.Carts
{
    public interface ICartServices
    {
        ResultDto AddToCart(long productId, Guid browserId);
        ResultDto RemoveFromCart(long productId, Guid browserId);
        ResultDto<CartDto> GetMyCart(Guid browserId , long? userId);
        ResultDto Add(long cartItemId);
        ResultDto LowOff(long cartItemId);

    }
}

