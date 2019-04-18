using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentManagePro
{
    /// <summary>
    /// 小节点
    /// </summary>
    public class SMnode 
    {
        public string Name;
        /// <summary>
        /// 是否在地图上 false不在地图上 true在地图上
        /// </summary>
        public bool PointLatLngFlag;
        /// <summary>
        /// 地图上的位置
        /// </summary>
        public PointLatLng PointLatLng;
    }
}
