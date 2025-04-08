using AutoMapper;
using DailyApp.API.ApiReponses;
using DailyApp.API.DataModel;
using DailyApp.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DailyApp.API.Controllers
{
    /// <summary>
    /// 账号控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private readonly DailyDbContext db;

        /// <summary>
        /// automapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">数据库连接</param>
        /// <param name="_mapper">automapper</param>
        public AccountController(DailyDbContext _db,IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="accountInfoDTO">注册信息</param>
        /// <returns>-1：账号已存在 1：注册成功 -99：未知错误</returns>
        [HttpPost]
        public IActionResult Reg(AccountInfoDTO accountInfoDTO)
        {
            //响应的数据
            ApiReponse res = new ApiReponse();
            //业务
            try
            {
                //1、账号是否存在(没有考虑高并发)
                var account = db.AccountInfos.FirstOrDefault(a => a.Account == accountInfoDTO.Account);
                if (account != null)
                {
                    res.ResultCode = -1;//账号已存在
                    res.Msg = "账号已存在";
                    return Ok(res);
                }
                //2、如果不存在则添加
                AccountInfo accountInfo = mapper.Map<AccountInfo>(accountInfoDTO);
                db.AccountInfos.Add(accountInfo);
                if (db.SaveChanges() > 0)
                {
                    res.ResultCode = 1;//注册成功
                    res.Msg = "注册成功";
                }
                else
                {
                    res.ResultCode = -99;
                    res.Msg = "注册失败";
                }
            }
            catch (Exception ex)
            {

                res.ResultCode = -99;
                res.Msg = "服务器发生异常";
                res.ResultData = ex.Message;
            }
            return Ok(res);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [HttpGet]

        public IActionResult Login(string account,string pwd)
        {
            ApiReponse res = new ApiReponse();

            try
            {
                var dbAccountInfo = db.AccountInfos.Where(x => x.Account == account).FirstOrDefault();
                if(dbAccountInfo == null)
                {
                    res.ResultCode = -1;
                    res.Msg = "账号不存在";
                    return Ok(res);
                }
                if (dbAccountInfo.Pwd != pwd)
                {
                    res.ResultCode = -2;
                    res.Msg = "密码错误";
                    return Ok(res);
                }
                res.ResultCode = 1;
                res.Msg = "登录成功";
                res.ResultData = dbAccountInfo;
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(res);
        }
    }
}
