using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore;
namespace Karen_Store.Application.Services.Carts
{
    public class CartServices : ICartServices
    {
        private readonly IDataBaseContext _context;
        public CartServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Add(long cartItemId)
        {

            var cartItem = _context.CartItems.Find(cartItemId);
            cartItem.Count++;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true
            };
        }

        public ResultDto AddToCart(long productId, Guid browserId)
        {

            var cart = _context.Carts.Where(p => p.BrowserId == browserId && p.IsFinished == false).FirstOrDefault();
            if (cart == null)
            {
                Cart newCart = new Cart
                {
                    BrowserId = browserId,
                    IsFinished = false,
                };
                _context.Carts.Add(newCart);
                _context.SaveChanges();
                cart = newCart;
            }
            var product = _context.Products.Find(productId);

            var cartItem = _context.CartItems.Where(p => p.ProductId == productId && p.CartId == cart.Id).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Count++;
            }
            else
            {
                CartItem newCartItem = new CartItem
                {
                    Cart = cart,
                    Count = 1,
                    Price = product.Price,
                    Product = product,

                };
                _context.CartItems.Add(newCartItem);
                _context.SaveChanges();
            }

            return new ResultDto
            {
                IsSuccess = true,
                Message = $" محصول {product.Name} به سبد شما افزوده شد "
            };

        }

        public ResultDto<CartDto> GetMyCart(Guid browserId, long? userId)
        {
            var cart = _context.Carts
                .Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.ProductImages)
                .Where(p => p.BrowserId == browserId && p.IsFinished == false)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();
         

            
            if (userId!= null && cart.UserId== null)
            {
                var user = _context.Users.Find(userId);
                cart.User = user;
                _context.SaveChanges();
            }
            if (cart != null)
            {
                {
                    return new ResultDto<CartDto>
                    {
                        
                        Data = new CartDto()
                        {
                            ProductCount = cart.CartItems.Count,
                            SumAmount = cart.CartItems.Sum(p => p.Price* p.Count),
                            CartItems = cart.CartItems.Select(p => new CartItemDto
                            {
                                Image = p.Product?.ProductImages?.FirstOrDefault()?.Src ?? "",
                                Count = p.Count,
                                Price = p.Price,
                                ProductName = p.Product?.Name,
                                Id = p.Id

                            }).ToList(),
                        },
                        Message = "",
                        IsSuccess = true,
                    };
                }
            }
            return new ResultDto<CartDto>
            {
                Data = new CartDto()
                {
                    CartItems = new List<CartItemDto>(),

                },
                IsSuccess = false,
                Message = ""
            };
        }

        public ResultDto LowOff(long cartItemId)
        {
            var cartItem = _context.CartItems.Find(cartItemId);
            if (cartItem.Count <= 1)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                };
            }
            cartItem.Count--;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true
            };
        }

        public ResultDto RemoveFromCart(long productId, Guid browserId)
        {
            var cartItem = _context.CartItems.Where(p => p.Cart.BrowserId == browserId).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.IsDeleted = true;
                cartItem.DeleteTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = ""
                };

            }
            return new ResultDto
            {
                IsSuccess = false,
                Message = "محصول یافت نشد"
            };
        }


    }
}

