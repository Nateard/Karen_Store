using Karen_Store.Application.Services.Finance.Command.AddRequestPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Interfaces.FacadePaterns
{
    public interface IPaymentFacade
    {
       IAddRequestPayService AddRequestPayService { get; }    
    }
}
