using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Finance.Queries
{
    public interface IGetRequestPayService
    {
        ResultDto<RequestPayDto> Execute(Guid guid);
    }

    public class GetRequestPayService : IGetRequestPayService
    {
        private readonly IDataBaseContext _context;
        public GetRequestPayService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<RequestPayDto> Execute(Guid guid)
        {
            try
            {
                var result = _context.RequestPays.Where(p => p.Guid == guid).FirstOrDefault();
                if (result != null)
                {
                    return new ResultDto<RequestPayDto>
                    {
                        IsSuccess = true,
                        Data = new RequestPayDto
                        {
                            Id = result.Id,
                            Amount = result.Amount,
                        }
                    };
                }
                return new ResultDto<RequestPayDto>
                {
                    IsSuccess = false,
                    Message = "Payment Not Found"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }



    public class RequestPayDto
    {
        public long Id { get; set; }    
        public int Amount { get; set; }
    }
}
