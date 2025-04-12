using AutoMapper;
using DailyApp.API.DataModel;
using DailyApp.API.DTOs;

namespace DailyApp.API.AutoMappers
{
    /// <summary>
    /// model之间转换的配置
    /// </summary>
    public class AutoMapperSettings:Profile
    {
        public AutoMapperSettings()
        {
            //登录的用户信息
            CreateMap<AccountInfoDTO,AccountInfo>().ReverseMap();

            //待办事项信息
            CreateMap<WaitDTO, WaitInfo>().ReverseMap();

        }
    }
}
