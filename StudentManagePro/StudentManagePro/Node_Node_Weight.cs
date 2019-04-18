using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagePro
{
    public class Node_Node_Weight
    {
        /// <summary>
        /// 小起点
        /// </summary>
        public SMnode NodeStart;
        /// <summary>
        /// 小终点
        /// </summary>
        public SMnode NodeEnd;
        /// <summary>
        /// 权重
        /// </summary>
        public int Weight;
        /// <summary>
        /// 折线点
        /// </summary>
        public List<PointLatLng> PointLatLngList=new List<PointLatLng>();
    }
}
