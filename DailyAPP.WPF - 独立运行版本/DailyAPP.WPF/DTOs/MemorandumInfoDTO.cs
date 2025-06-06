﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.DTOs
{
    internal class MemorandumInfoDTO
    {
            /// <summary>
            /// 待办事项ID
            /// </summary>
            public int MemorandumId { get; set; }

            /// <summary>
            /// 标题
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// 内容
            /// </summary>
            public string Content { get; set; }

            /// <summary>
            /// 状态
            /// </summary>
            public int Status { get; set; }
    }
}
