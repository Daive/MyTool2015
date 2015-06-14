using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyTool2015.Controllers
{
    public class ProgramController : Controller
    {
        // GET: Program
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Run()
        {
            ViewBag.tempText=  GetGeneralContent("http://hq.sinajs.cn/list=sh601006");
            string tempText= GetGeneralContent("http://hq.sinajs.cn/list=sh601006");
            // 获取所有股票代码
            //遍历sina股票代码，抓取历史数据，存入数据库
            //遍历baidu 股票代码，比对，返回错误率
            //遍历其他股票代码，返回错误率

            //定时 下午4点，判断今日是否开市，抓取当日股票信息
            // 遍历股票代码，查询是否新股
            // 股票信息表，股票成交信息表，股票指标信息表
            return View();
        }

        public void  Insert()
        {

        }

        //抓取页面
        private string GetGeneralContent(string strUrl)

        {
            string strMsg = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(strUrl);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
                strMsg = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                response.Close();
            }
            catch
            { }
            return strMsg;
        }
    }
}