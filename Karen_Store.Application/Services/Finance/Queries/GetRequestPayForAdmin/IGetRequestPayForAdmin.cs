using Karen_Store.Common.Dto;

namespace Karen_Store.Application.Services.Finance.Queries.GetRequestPayForAdmin
{
    public partial interface IGetRequestPayForAdmin
    {
        public interface IGetRequestPayForAdminService
        {
            ResultDto<List<RequestPayDto>> Execute();
        }
    }
}
