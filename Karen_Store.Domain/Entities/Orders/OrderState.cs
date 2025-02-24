using System.ComponentModel.DataAnnotations;

namespace Karen_Store.Domain.Entities.Orders
{
    public enum OrderState
    {
        [Display(Name = "در حال پردازش")]
        Proccesing = 0,
        [Display(Name = "لغو شده")]
        Cancled = 1,
        [Display(Name = "تحویل شده")]
        Delivered = 2,
    }




}
