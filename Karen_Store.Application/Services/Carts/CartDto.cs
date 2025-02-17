namespace Karen_Store.Application.Services.Carts
{
    public class CartDto
    {
        public int ProductCount { get; set; }
        public int SumAmount { get; set; }
        public long ProductId { get; set; }
        public ICollection<CartItemDto> CartItems { get; set; }

    }
}

