using AutoMapper;
using DailyApp.API.ApiReponses;
using DailyApp.API.DataModel;
using DailyApp.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace DailyApp.API.Controllers
{
    /// <summary>
    /// 待办事项控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WaitController : ControllerBase
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private readonly DailyDbContext db;

        /// <summary>
        /// AutoMapper
        /// </summary>
        private readonly IMapper mapper;

        public WaitController(DailyDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }


        /// <summary>
        /// 统计待办数据
        /// </summary>
        /// <returns>1：统计成功 -99：统计异常</returns>
        [HttpGet]
        public IActionResult StatWait()
        {
            ApiReponse res = new ApiReponse();

            try
            {
                //所有的记录
                var list = db.WaitInfos.ToList();
                //已完成的记录
                var finishlist = list.Where(x => x.Status == 1).ToList();
                
                StatWaitDTO statWaitDTO = new StatWaitDTO { TotalCount = list.Count, FinnishCount = finishlist.Count };

                res.ResultCode = 1;
                res.Msg = "统计待办事项成功！";
                res.ResultData = statWaitDTO;
                
            }
            catch (Exception)
            {

                res.ResultCode = -99;
                res.Msg = "服务器端内部错误！请查看后端日志！";

            }
            return Ok(res);
        }

        /// <summary>
        /// 添加待办事项
        /// </summary>
        /// <param name="waitDTO">待办事项信息</param>
        /// <returns>1：添加成功；-1：添加失败； -99：异常</returns>
        [HttpPost]
        public IActionResult AddWait(WaitDTO waitDTO)
        {
            ApiReponse response = new ApiReponse();

            try
            {
                //DTO→实体类
                WaitInfo waitInfo = mapper.Map<WaitInfo>(waitDTO);
                db.WaitInfos.Add(waitInfo);
                int result = db.SaveChanges();
                if(result == 1)
                {
                    response.ResultCode = 1;
                    response.Msg = "添加待办事项成功！";
                }
                else
                {
                    response.ResultCode = -1;
                    response.Msg = "添加待办事项失败！";
                }
            }
            catch (Exception)
            {

                response.ResultCode = -99;
                response.Msg = "服务器端内部错误！请查看后端日志！";
            }

            return Ok(response);
        }

        /// <summary>
        /// 获取待办状态的所有待办事项
        /// </summary>
        /// <returns>1：获取成功；-1：获取失败；99：异常</returns>
        [HttpGet]
        public IActionResult GetWaiting()
        {
            ApiReponse response = new ApiReponse();
            try
            {
                //获取所有的事项
                var list = db.WaitInfos.ToList();
                //获取所有的待办事项
                var waitlist = list.Where(x => x.Status == 0).ToList();
                if (waitlist.Count > 0)
                {
                    response.ResultCode = 1;
                    response.Msg = "获取待办事项成功！";
                    response.ResultData = waitlist;
                }
                else
                {
                    response.ResultCode = -1;
                    response.Msg = "没有待办事项！";
                }
            }
            catch (Exception)
            {
                response.ResultCode = -99;
                response.Msg = "服务器端内部错误！请查看后端日志！";
            }
            return Ok(response);
        }
    }
}
