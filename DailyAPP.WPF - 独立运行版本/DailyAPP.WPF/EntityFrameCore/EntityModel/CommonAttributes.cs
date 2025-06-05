
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.EntityFrameCore.EntityModel
{
    public class CommonAttributes
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string? Describe { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastModifiedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 是否删除(软删除)
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
