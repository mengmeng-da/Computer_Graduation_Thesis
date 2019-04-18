using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentManagePro
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        GMapControl gMapControl1;
        private void Form1_Load(object sender, EventArgs e)
        {
            gMapControl1 = new GMapControl();
            gMapControl1.Dock = DockStyle.Fill;
            this.gMapControl1.CacheLocation = Path.GetFullPath(@"baidu");//指定地图缓存存放路径
            this.gMapControl1.MapProvider = GMapProviders.BaiduMap;
            this.gMapControl1.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;//地图加载模式
            this.gMapControl1.MinZoom = 1;// mapdata.MinZoom;// 3;   //最小比例
            this.gMapControl1.MaxZoom = 19;// mapdata.MaxZoom;// 32; //最大比例
            this.gMapControl1.Zoom = 5;// mapdata.Zoom; //当前比例
            this.gMapControl1.ShowCenter = true; //不显示中心十字点
            this.gMapControl1.DragButton = System.Windows.Forms.MouseButtons.Left;//左键拖拽地图
            //this.gMapControl1.Position = mapdata.PointLatLng;//39.92, 116.46
            this.gMapControl1.Position = new PointLatLng(25.0681850763586, 69.5008850097656);//39.92, 116.46
            //this.tabPageMap.Controls.Add(this.gMapControl1);
            //gMapControl1.MouseClick += GMapControl1_MouseClick;
            //gMapControl1.MouseDown += GMapControl1_MouseDown;
            this.panel1.Controls.Add(gMapControl1);
        }

        //下载区域信息
        private void button1_Click(object sender, EventArgs e)
        {
            GMapOverlay overlay = new GMapOverlay("overLayDownLoadMap");
            RectLatLng area = this.gMapControl1.SelectedArea;
            this.gMapControl1.Overlays.Add(overlay);
            //this.gMapControl1.Overlays.Insert(0,overlay);
            if (!area.IsEmpty)
            {
                for (int i = (int)this.gMapControl1.Zoom; i <= this.gMapControl1.MaxZoom; i++)
                {
                    DialogResult res = MessageBox.Show("准备下载 " + i + " 级地图?", "GMap.NET", MessageBoxButtons.YesNoCancel);

                    if (res == DialogResult.Yes)
                    {
                        using (TilePrefetcher obj = new TilePrefetcher())
                        {
                            obj.Overlay = overlay; // set overlay if you want to see cache progress on the map

                            obj.Shuffle = this.gMapControl1.Manager.Mode != AccessMode.CacheOnly;

                            obj.Owner = this;
                            obj.ShowCompleteMessage = true;
                            obj.Start(area, i, this.gMapControl1.MapProvider, this.gMapControl1.Manager.Mode == AccessMode.CacheOnly ? 0 : 100, this.gMapControl1.Manager.Mode == AccessMode.CacheOnly ? 0 : 1);
                        }
                    }
                    else if (res == DialogResult.No)
                    {
                        continue;
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        break;
                    }
                }
                //overlay.Markers.Clear();
                this.gMapControl1.Overlays.Remove(overlay);
                this.gMapControl1.SelectedArea = RectLatLng.Empty;
            }
            else
            {
                MessageBox.Show("请选中地图区域！", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        //清空数据
        private void button2_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("是否清空地图缓存?", "清空 GMap.NET 缓存?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    this.gMapControl1.Manager.PrimaryCache.DeleteOlderThan(DateTime.Now, null);
                    MessageBox.Show("缓存已经清空.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //树形结构表示点
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {




        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 添加车站ToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void 插入车站ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 添加站台ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 删除站台ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //string json = JsonConvert.SerializeObject(mapdata);//用Json序列化存储
            List<SEnode> list = new List<SEnode>();
            SEnode senode = new SEnode() { Name="北太平桥西"};
            senode.SMnodeList.Add(new SMnode() { Name = "A" });
            senode.SMnodeList.Add(new SMnode() { Name = "B" });
            senode.SMnodeList.Add(new SMnode() { Name = "C" });
            list.Add(senode);
            senode = new SEnode() { Name = "蓟门桥" };
            senode.SMnodeList.Add(new SMnode() { Name = "D" });
            senode.SMnodeList.Add(new SMnode() { Name = "E" });
            senode.SMnodeList.Add(new SMnode() { Name = "F" });
            list.Add(senode);
            string json = JsonConvert.SerializeObject(list);//用Json序列化存储
            File.WriteAllText("1.txt",json,Encoding.UTF8);
            MessageBox.Show(json);
        }

        private void button4_Click(object sender, EventArgs e)
        {//用JSON提取txt内信息，并解压成对象
            string text = File.ReadAllText(@"1.txt", System.Text.Encoding.UTF8);
            List<SEnode> list = JsonConvert.DeserializeObject<List<SEnode>>(text);
            //string str = null;
            //str = "";
            
        }
    }
}
