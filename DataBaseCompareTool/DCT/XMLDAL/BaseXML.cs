using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLDAL
{
    public class BaseXML
    {

        /// <summary>
        /// xml文件路径
        /// </summary>
        protected string filepath;

        /// <summary>
        /// 获取xml名称
        /// </summary>
        /// <param name="dbtype"></param>
        public virtual void Init(string file)
        {
            filepath = file;
        }

        /// <summary>
        /// 加载XML
        /// </summary>
        /// <returns></returns>
        public XmlDocument LoadXML()
        {
            var XmlDoc = new XmlDocument();
            XmlDoc.Load(filepath);
            return XmlDoc;
        }



    }


}
