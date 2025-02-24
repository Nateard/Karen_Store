using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.Carts;
using Karen_Store.Domain.Entities.Products;
using Karen_Store.Domain.Entities.Users;
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

        public ResultDto AddToGuestCart(long productId, Guid browserId)
        {

            var cart = _context.Carts.Where(p => p.BrowserId == browserId && p.IsFinished == false && p.User == null).FirstOrDefault();
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

        public ResultDto AddToUserCart(long productId, long? userId, Guid browserId)
        {
            var cart = _context.Carts.Where(p => p.IsFinished == false && p.UserId == userId).FirstOrDefault();
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

        public ResultDto AssignCurrentCartToUser(Guid browserId, long? userId)
        {

            var cart = _context.Carts
                .Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.ProductImages)
                .Where(p => p.BrowserId == browserId && p.IsFinished == false)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();

            if (userId != null)
            {
                var user = _context.Users.Find(userId);
                cart.User = user;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                };
            }
            return new ResultDto
            {
                IsSuccess = false
            }; 
        }
            
        public ResultDto CreateCartForGuest(Guid browserId)
        {
            Cart cart = new Cart()
            {
                IsFinished = false,
                BrowserId = browserId
            };
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
            };
        }

        public ResultDto CreateCartForUser(long? userId)
        {

            Cart cart = new Cart()
            {

                IsFinished = false,
                UserId = userId

            };
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
            };
        }

        public ResultDto<CartDto> GetMyCartByBrowserId(Guid browserId)
        {
            var cart = _context.Carts
                .Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.ProductImages)
                .Where(p => p.BrowserId == browserId && p.IsFinished == false && p.UserId == null)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();
            if (cart != null)
            {
                return new ResultDto<CartDto>
                {
                    Data = new CartDto()
                    {
                        ProductCount = cart.CartItems.Count,
                        SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
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

        public ResultDto<CartDto> GetMyCartByUserId(long? userId)
        {
            var cart = _context.Carts
                .Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.ProductImages)
                .Where(p => p.UserId == userId && p.IsFinished == false)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();
            if (cart != null)
            {
                var user = _context.Users.Find(userId);
                cart.User = user;
                _context.SaveChanges();
                return new ResultDto<CartDto>
                {
                    Data = new CartDto()
                    {
                        CartId = cart.Id,
                        UserId= userId,
                        ProductCount = cart.CartItems.Count,
                        SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
                        
                        CartItems = cart.CartItems.Select(p => new CartItemDto
                        {
                            Image = p.Product?.ProductImages?.FirstOrDefault()?.Src ?? "",
                            Count = p.Count,
                            Price = p.Price,
                            ProductName = p.Product?.Name,
                            Id = p.Id,
                           

                        }).ToList(),
                    },
                    Message = "",
                    IsSuccess = true,
                };
            }
            //if (cart != null)
            //{
            //    {
            //        return new ResultDto<CartDto>
            //        {

            //            Data = new CartDto()
            //            {
            //                ProductCount = cart.CartItems.Count,
            //                SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
            //                CartItems = cart.CartItems.Select(p => new CartItemDto
            //                {
            //                    Image = p.Product?.ProductImages?.FirstOrDefault()?.Src ?? "",
            //                    Count = p.Count,
            //                    Price = p.Price,
            //                    ProductName = p.Product?.Name,
            //                    Id = p.Id

            //                }).ToList(),
            //            },
            //            Message = "",
            //            IsSuccess = true,
            //        };
            //    }
            //}
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

