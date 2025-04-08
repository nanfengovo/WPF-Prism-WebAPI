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
            CreateMap<AccountInfoDTO,AccountInfo>().ReverseMap();
        }
    }
}
