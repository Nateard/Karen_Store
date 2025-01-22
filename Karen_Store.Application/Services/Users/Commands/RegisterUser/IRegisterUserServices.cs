using Karen_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserServices
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }   

}
