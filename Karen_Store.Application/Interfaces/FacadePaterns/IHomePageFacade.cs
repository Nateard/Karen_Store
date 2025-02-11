using Karen_Store.Application.Services.HomePage.Commands.AddNewSlider;
using Karen_Store.Application.Services.HomePage.Quereis.GetSlider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Interfaces.FacadePaterns
{
    public interface IHomePageFacade
    {
        IAddNewSliderService AddNewSliderService { get; }
        IGetSliderService GetSliderService { get; }
    }
}
