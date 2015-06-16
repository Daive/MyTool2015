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
        public ActionResult Index(string strUrl)
        {
            string content= GetGeneralContent(strUrl);
            ViewBag.content = content;
            ViewBag.length = content.Length;
            ViewBag.strUrl = strUrl;
            // 获取所有股票代码
            //遍历sina股票代码，抓取历史数据，存入数据库
            //遍历baidu 股票代码，比对，返回错误率
            //遍历其他股票代码，返回错误率

            //定时 下午4点，判断今日是否开市，抓取当日股票信息
            // 遍历股票代码，查询是否新股
            // 股票信息表，股票成交信息表，股票指标信息表
            return View();
        }

        public ActionResult Run(string strUrl)
        {

            ViewBag.tempText = GetGeneralContent(strUrl);
            string tempText = GetGeneralContent("http://hq.sinajs.cn/list=sh601006");
            // 获取所有股票代码
            //遍历sina股票代码，抓取历史数据，存入数据库
            //遍历baidu 股票代码，比对，返回错误率
            //遍历其他股票代码，返回错误率

            //定时 下午4点，判断今日是否开市，抓取当日股票信息
            // 遍历股票代码，查询是否新股
            // 股票信息表，股票成交信息表，股票指标信息表
            return View();
        }

        public void Insert()
        {

        }

        //抓取页面
        private string GetGeneralContent(string strUrl)

        {
            string strMsg = string.Empty;
            try
            {
                WebResponse response = GetResponse(strUrl,Login("http://xueqiu.com/user/login", "http://xueqiu.com/user/login?username=243627986@qq.com&password=wbp243627986", null)); ;
                /*try
                { response = (HttpWebResponse)request.GetResponse(); }
                catch (WebException ex)
                { response = (HttpWebResponse)ex.Response; }*/
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                strMsg = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                response.Close();

            }
            catch
            { strMsg = "error"; }
            return strMsg;
        }

        //sPostData，待提交的数据串，如http://www.test.com/login.aspx?user=admin&pwd=123456  
        public static CookieContainer Login(string url, string sPostData, CookieContainer cc)
        {
            //创建cookie
            CookieContainer container = (cc == null) ? new CookieContainer() : cc;
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(sPostData);

            HttpWebRequest resquest = ResquestInit(url);
            resquest.Method = "POST";
            resquest.ContentLength = data.Length;
            resquest.CookieContainer = container;

            Stream newStream = resquest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)resquest.GetResponse();
                response.Cookies = container.GetCookies(resquest.RequestUri);
            }
            catch { }

            return container;
        }
        //这个函数的作用就是统一Request的格式，使得每次访问目标网站都用相同的口径。如果参数不同的话，可能造成COOKIE无效，因而登录无效  
        public static HttpWebRequest ResquestInit(string url)
        {
            Uri target = new Uri(url);
            HttpWebRequest resquest = (HttpWebRequest)WebRequest.Create(target);
            resquest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; zh-CN; rv:1.9.2.2) Gecko/20100316 Firefox/3.6.2 (.NET CLR 3.5.30729)";
            resquest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            resquest.AllowAutoRedirect = true;
            resquest.KeepAlive = true;
            resquest.ReadWriteTimeout = 120000;
            resquest.ContentType = "application/x-www-form-urlencoded";
            resquest.Referer = url;

            return resquest;
        }

        public static HttpWebResponse GetResponse(string url, CookieContainer cc)
        {
            try
            {
                CookieContainer container = (cc == null) ? new CookieContainer() : cc;
                HttpWebRequest resquest = ResquestInit(url);
                resquest.CookieContainer = container;
                HttpWebResponse response = (HttpWebResponse)resquest.GetResponse();
                response.Cookies = container.GetCookies(resquest.RequestUri);
                return response;
            }
            catch
            {
                return null;
            }
        }

    }
}