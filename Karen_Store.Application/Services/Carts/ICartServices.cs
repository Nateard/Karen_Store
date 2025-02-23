using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.Users;
namespace Karen_Store.Application.Services.Carts
{
    public interface ICartServices
    {
        ResultDto AddToGuestCart(long productId, Guid browserId);
        ResultDto AddToUserCart(long productId, long? userId , Guid browserId);
        ResultDto RemoveFromCart(long productId, Guid browserId);
        ResultDto<CartDto> GetMyCartByUserId(long? userId);
        ResultDto<CartDto> GetMyCartByBrowserId(Guid browserId);
        ResultDto Add(long cartItemId);
        ResultDto LowOff(long cartItemId);
        ResultDto CreateCartForUser(long? userId);
        ResultDto CreateCartForGuest(Guid browserId);
        ResultDto AssignCurrentCartToUser(Guid browserId , long? userId);

    }
}

