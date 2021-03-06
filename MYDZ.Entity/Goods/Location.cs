﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYDZ.Entity.Goods
{
    /// <summary>
    /// 商品所在地
    /// </summary>
    [Serializable]
    public class Location : Response
    {
        /// <summary>
        /// 系统数据库
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// 详细地址，最大256个字节（128个中文）
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// 所在城市（中文名称）
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 国家名称
        /// </summary>
        [XmlElement("country")]
        public string Country { get; set; }

        /// <summary>
        /// 区/县（只适用于物流API）
        /// </summary>
        [XmlElement("district")]
        public string District { get; set; }

        /// <summary>
        /// 所在省份（中文名称）
        /// </summary>
        [XmlElement("state")]
        public string State { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [XmlElement("zip")]
        public string Zip { get; set; }
    }
}
