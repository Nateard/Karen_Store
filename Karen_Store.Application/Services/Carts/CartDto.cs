namespace Karen_Store.Application.Services.Carts
{
    public class CartDto
    {
        public long ProductId { get; set; }
        public ICollection<CartItemDto> CartItems { get; set; }

    }
}

