﻿namespace Karen_Store.Application.Services.Products.Commands.EditCategories
{
    public partial class EditCategory
    {
        public class EditCategoryDto
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
}
