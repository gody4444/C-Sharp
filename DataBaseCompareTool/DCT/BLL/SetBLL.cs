using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BLL
{
    public class SetBLL
    {

        /// <summary>
        /// 获取数据库设置列表
        /// </summary>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        public List<DataBaseModel> GetDBSetList()
        {
            try
            {
                var XmlDoc = new XmlDocument();
                XmlDoc.Load(CommonConfig.SettingPath);
                XElement xelem = XElement.Parse(XmlDoc.SelectSingleNode("//Settings//DataBaseList").OuterXml);
                List<DataBaseModel> dblist = (from o in xelem.Descendants()
                                              select new DataBaseModel
                                              {
                                                  ID = o.Attribute("Id").Value,
                                                  NAME = o.Attribute("Name").Value,
                                                  DB = o.Attribute("DB").Value,
                                                  USER = o.Attribute("User").Value,
                                                  PWD = o.Attribute("Password").Value,
                                                  ISCACHED = o.Attribute("IsCached").Value == "1" ? "已缓存" : "未缓存",
                                                  PATH = o.Attribute("Path").Value
                                              }).ToList();
                return dblist;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 获取数据库设置详情
        /// </summary>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        public DataBaseModel GetDBSetDetail(string id)
        {
            try
            {
                var XmlDoc = new XmlDocument();
                XmlDoc.Load(CommonConfig.SettingPath);
                XElement xelem = XElement.Parse(XmlDoc.SelectSingleNode("//Settings//DataBaseList").OuterXml);
                DataBaseModel db = (from o in xelem.Descendants()
                                    where o.Attribute("Id").Value == id
                                    select new DataBaseModel
                                    {
                                        ID = o.Attribute("Id").Value,
                                        NAME = o.Attribute("Name").Value,
                                        DB = o.Attribute("DB").Value,
                                        USER = o.Attribute("User").Value,
                                        PWD = o.Attribute("Password").Value,
                                        ISCACHED = o.Attribute("IsCached").Value,
                                        PATH = o.Attribute("Path").Value
                                    }).ToList()[0];
                return db;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 保存数据库设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Boolean SaveDBSet(DataBaseModel model, out string msg)
        {
            try
            {
                XElement rootNode = XElement.Load(CommonConfig.SettingPath);
                if (string.IsNullOrEmpty(model.ID))//新增
                {
                    model.ID = rootNode.Element("DataBaseList").Attribute("MaxId").Value;//获取id
                    rootNode.Element("DataBaseList").SetAttributeValue("MaxId", Convert.ToInt32(model.ID) + 1);//生成下一个id

                    IEnumerable<XElement> dblist = from target in rootNode.Descendants("DataBaseList") select target as XElement;
                    XElement db = new XElement("DataBaseModel");
                    db.SetAttributeValue("Id", model.ID);
                    db.SetAttributeValue("Name", model.NAME);
                    db.SetAttributeValue("DB", model.DB);
                    db.SetAttributeValue("User", model.USER);
                    db.SetAttributeValue("Password", model.PWD);
                    db.SetAttributeValue("IsCached", "0");
                    db.SetAttributeValue("Path", "");
                    foreach (XElement ele in dblist)
                    {
                        ele.Add(db);
                    }
                }
                else//修改
                {
                    IEnumerable<XElement> dblist = from target in rootNode.Descendants("DataBaseModel")
                                                   where target.Attribute("Id").Value == model.ID
                                                   select target as XElement;
                    foreach (XElement db in dblist)
                    {
                        db.SetAttributeValue("Name", model.NAME);
                        db.SetAttributeValue("DB", model.DB);
                        db.SetAttributeValue("User", model.USER);
                        db.SetAttributeValue("Password", model.PWD);
                    }
                }
                rootNode.Save(CommonConfig.SettingPath);
                msg = "保存成功";
                return true;
            }
            catch (Exception ex)
            {
                //throw ex;
                msg = ex.Message;
                return false;
            }

        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Boolean DeleteDBSet(string id, out string msg)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    XElement rootNode = XElement.Load(CommonConfig.SettingPath);
                    IEnumerable<XElement> dblist = from target in rootNode.Descendants("DataBaseModel")
                                                   where target.Attribute("Id").Value == id
                                                   select target as XElement;
                    foreach (XElement db in dblist)
                    {
                        db.Remove();
                        break;
                    }
                    rootNode.Save(CommonConfig.SettingPath);
                    msg = "删除成功";
                    return true;
                }
                msg = "id不能为空";
                return false;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 设置缓存对应的路径
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Boolean SetCache(DataBaseModel model, out string msg)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.ID))
                {

                    XElement rootNode = XElement.Load(CommonConfig.SettingPath);
                    IEnumerable<XElement> dblist = from target in rootNode.Descendants("DataBaseModel")
                                                   where target.Attribute("Id").Value == model.ID
                                                   select target as XElement;
                    foreach (XElement db in dblist)
                    {
                        db.SetAttributeValue("IsCached", "1");
                        db.SetAttributeValue("Path", model.PATH);
                        break;
                    }

                    rootNode.Save(CommonConfig.SettingPath);
                    msg = "缓存成功";
                    return true;
                }
                msg = "id不能为空";
                return false;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 拼接缓存文件名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetFilePath(string id, string name)
        {
            return id + "_" + name + ".xml";
        }


    }


}
