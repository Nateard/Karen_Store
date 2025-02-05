namespace Karen_Store.Application.Services.Products.Commands.AddNewCategory
{
    public partial class AddNewCategoryServices
    {
        public class AddNewCategoryDto
        {
            public string Name { get; set; }
            public long? ParentId { get; set; }
        }
    }
}
