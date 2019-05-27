using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Order
{
    public class Config
    {

        private string filePath = HttpContext.Current.Server.MapPath("~/config.xml");

        private XmlDocument xmlDoc; //引入命名空间:using System.Xml;  
        //private string filePath = Environment.CurrentDirectory + @"\config.xml"; //引入命名空间:using System.Windows.Forms;  

        public Config()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
        }
        /// <summary>  
        /// 获取值  
        /// </summary>  
        /// <param name="strKey"></param>  
        /// <returns></returns>  
        public string GetXmlValue(string strKey)
        {
            string strResult = "9999"; //找不到匹配的项;  
            for (int i = 0; i < xmlDoc.DocumentElement.ChildNodes.Count; i++)
            {
                if (xmlDoc.DocumentElement.ChildNodes[i].Attributes[0].Value == strKey)
                {
                    strResult = xmlDoc.DocumentElement.ChildNodes[i].Attributes[1].Value;
                    break;
                }
            }
            return strResult;
        }
        /// <summary>  
        /// 修改值  
        /// </summary>  
        /// <param name="strKey"></param>  
        /// <param name="strValue"></param>  
        /// <returns></returns>  
        public string SetXmlValue(string strKey, string strValue)
        {
            string strResult = "9999"; //找不到匹配的项;  
            for (int i = 0; i < xmlDoc.DocumentElement.ChildNodes.Count; i++)
            {
                if (xmlDoc.DocumentElement.ChildNodes[i].Attributes[0].Value == strKey)
                {
                    xmlDoc.DocumentElement.ChildNodes[i].Attributes[1].Value = strValue;
                    strResult = "0"; //修改成功  
                    xmlDoc.Save(filePath); //修改完后记得保存o(∩_∩)o  
                    break;
                }
            }
            return strResult;
        }
    }
}