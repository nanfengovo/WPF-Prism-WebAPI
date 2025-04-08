using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Study.API.Controllers
{
    /// <summary>
    /// Router 路由
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudyController : ControllerBase
    {
        /// <summary>
        /// 功能一
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Fun()
        {
            return Ok("龙马哥");
        }

        /// <summary>
        /// 功能二
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Fun1(string name)
        {
            return Ok(name);
        }
    }
}
