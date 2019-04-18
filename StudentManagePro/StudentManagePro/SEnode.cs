using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentManagePro
{
    /// <summary>
    /// 大节点
    /// </summary>
    public class SEnode 
    {
        public string Name;
        public List<SMnode> SMnodeList=new List<SMnode>();
    }
}
