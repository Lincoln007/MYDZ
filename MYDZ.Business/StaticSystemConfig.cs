﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Config.Soft;

namespace MYDZ.Business
{
    public static class StaticSystemConfig
    {
        /// <summary>
        /// 此项目的静态文件配置
        /// </summary>
        public static SoftInfoConfig soft = SoftInfoConfigs.GetConfig();
    }
}
