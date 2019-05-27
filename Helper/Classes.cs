using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using System.Text;

using System.Data.Sql;
using Helper;

/// <summary>
/// Classes 的摘要说明
/// </summary>
public class Classes
{
    #region 查

    /// <summary>
    /// 找上一个元素(true)或下一个元素
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="upDown"></param>
    /// <returns></returns>
    public DataTable GetUpDown(int classId, bool upDown)
    {
        DataTable dt = GetByClassId(classId);
        StringBuilder sb = new StringBuilder();
        sb.Append("select * from classes where parentId=@parentId and sortId=@sortId");
        if (upDown)
            sb.Append("-1");
        else
            sb.Append("+1");
        SqlParameter[] param =  { 
            SQLHelper2.GetParameter("@parentId", SqlDbType.Int, 4, "[parentId]", Convert.ToInt32( dt.Rows[0]["parentId"].ToString())),
            SQLHelper2.GetParameter("@sortId", SqlDbType.Int, 4, "[sortId]",Convert.ToInt32( dt.Rows[0]["sortId"].ToString()))
        };
        return SQLHelper2.ExecuteDt(sb.ToString(), param);
    }

    /// <summary>
    /// 根据当前编号，返回父级全部信息
    /// </summary>
    /// <param name="classId"></param>
    /// <returns></returns>
    public DataTable GetParent(int classId)
    {
        DataTable dt = GetByClassId(classId);
        StringBuilder sb = new StringBuilder();
        sb.Append("select * from classes where classId=@classId");
        SqlParameter[] param =  { 
            SQLHelper2.GetParameter("@classId", SqlDbType.Int, 4, "[classId]", dt.Rows[0]["parentId"].ToString())
        };
        return SQLHelper2.ExecuteDt(sb.ToString(), param);
    }

    /// <summary>
    /// 根据id
    /// </summary>
    /// <param name="classId"></param>
    /// <returns></returns>
    public DataTable GetByClassId(int classId)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select * from classes where classId=@classId");
        SqlParameter[] param =  { 
            SQLHelper2.GetParameter("@classId", SqlDbType.Int, 4, "[classId]", classId)
        };
        return SQLHelper2.ExecuteDt(sb.ToString(), param);
    }

    /// <summary>
    /// 根据当前项，找到同级的上一个或下一个。
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="upDown"></param>
    /// <returns></returns>
    //public DataTable GetUpDown(int classId, bool upDown)
    //{
    //    DataTable dt = GetClass("classId=" + classId);
    //    int parentId = Convert.ToInt32(dt.Rows[0]["parentId"].ToString());
    //    int sortId = Convert.ToInt32(dt.Rows[0]["sortId"].ToString());
    //    StringBuilder sb = new StringBuilder();
    //    sb.Append("select * from classes where parentId=@parentId and ");
    //    if (upDown)
    //        sb.Append("sortId=@sortId-1");
    //    else
    //        sb.Append("sortId=@sortId+1");
    //    SqlParameter[] param =  { 
    //        SQLHelper2.GetParameter("@parentId", SqlDbType.Int, 4, "[parentId]", parentId),
    //        SQLHelper2.GetParameter("@sortId", SqlDbType.Int, 4, "[sortId]", sortId)
    //    };
    //    return SQLHelper2.ExecuteDt(sb.ToString(), param);
    //}

    /// <summary>
    /// 判断是否拥有子类
    /// </summary>
    /// <param name="parentId"></param>
    /// <returns></returns>
    public bool HasChild(int parentId)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select 1 from classes where parentId=@parentId");
        SqlParameter[] param =  { SQLHelper2.GetParameter("@parentId", SqlDbType.Int, 4, "[parentId]", parentId) };
        DataTable dt = SQLHelper2.ExecuteDt(sb.ToString(), param);
        if (dt.Rows.Count > 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 1.where classId=1
    /// </summary>
    /// <param name="whereStr"></param>
    /// <returns></returns>
    public DataTable GetClass(string whereStr)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select * from classes where " + whereStr + " order by sortId");
        return SQLHelper2.ExecuteDt(sb.ToString());
    }
    /// <summary>
    /// 根据父级查找最大排序号
    /// </summary>
    /// <param name="parentId"></param>
    /// <returns></returns>
    public string GetMaxSortId(int parentId)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select max(sortId) from classes where parentId=@parentId");
        SqlParameter[] param =  { SQLHelper2.GetParameter("@parentId", SqlDbType.Int, 4, "[parentId]", parentId) };
        DataTable dt = SQLHelper2.ExecuteDt(sb.ToString(), param);

        if (dt.Rows.Count > 0)
        {
            string temp = dt.Rows[0][0].ToString();
            if ("".Equals(temp))
            {
                temp = "-1";
            }
            return temp;
        }          
        else
            return "-1";
    }

    #endregion

    #region 改

    /// <summary>
    /// 修改类别
    /// </summary>
    /// <param name="className"></param>
    /// <param name="classDescrip"></param>
    /// <param name="classId"></param>
    /// <returns></returns>
    public int UpdateClass(string className, string classDescrip, int classId, decimal workhours)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update classes set className=@className,classDescrip=@classDescrip,workhours=@workhours where classId=@classId");
        SqlParameter[] param =  { 
            SQLHelper2.GetParameter("@className", SqlDbType.VarChar, 50, "[className]", className) ,
            SQLHelper2.GetParameter("@classDescrip", SqlDbType.VarChar, 500, "[classDescrip]", classDescrip) ,
            SQLHelper2.GetParameter("@workhours", SqlDbType.Decimal, 18, "[workhours]", workhours) ,
            SQLHelper2.GetParameter("@classId", SqlDbType.Int, 4, "[classId]", classId) 
        };
        return SQLHelper2.ExecuteSql(sb.ToString(), param);
    }

    /// <summary>
    /// 删除项的时候，为false,把父类子类数量减1,增加时，增1
    /// </summary>
    /// <param name="classId"></param>
    /// <returns></returns>
    public int UpdateChildNum(int classId, bool addOrMinus)
    {
        StringBuilder sb = new StringBuilder();
        if (addOrMinus)
            sb.Append("update classes set childNum=childNum+1 where classId=@classId");
        else
            sb.Append("update classes set childNum=childNum-1 where classId=@classId");
        SqlParameter[] param =  { 
            SQLHelper2.GetParameter("@classId", SqlDbType.Int, 4, "[classId]", classId) 
        };
        return SQLHelper2.ExecuteSql(sb.ToString(), param);
    }

    /// <summary>
    /// 删除项的时候，相同父类的项的sortId大于此类的排序编号减1
    /// </summary>
    /// <param name="sortId"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    public int UpdateSort(int sortId, int parentId)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update classes set sortId=sortId-1 where sortId>@sortId and parentId=@parentId");
        SqlParameter[] param =  { 
            SQLHelper2.GetParameter("@sortId", SqlDbType.Int, 4, "[sortId]", sortId) ,
            SQLHelper2.GetParameter("@parentId", SqlDbType.Int, 4, "[parentId]", parentId) 
        };
        return SQLHelper2.ExecuteSql(sb.ToString(), param);
    }

    /// <summary>
    /// 交换数据时,一个sortId减1(true),一个加1
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="addOrMinus"></param>
    /// <returns></returns>
    public int ChangeSort(int classId, bool addOrMinus)
    {
        StringBuilder sb = new StringBuilder();
        if (addOrMinus)
            sb.Append("update classes set sortId=sortId-1 where classId=@classId");
        else
            sb.Append("update classes set sortId=sortId+1 where classId=@classId");
        SqlParameter[] param =  { 
            SQLHelper2.GetParameter("@classId", SqlDbType.Int, 4, "[classId]", classId) 
        };
        return SQLHelper2.ExecuteSql(sb.ToString(), param);
    }

    #endregion

    #region 删

    /// <summary>
    /// 删除的时候，判断是否有子类，parentId!=0则操作父类,sortId,childNum
    /// </summary>
    /// <param name="classId"></param>
    /// <returns></returns>
    public int DeleteClass(int classId)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("delete from classes where classId=@classId");
        SqlParameter[] param =  { SQLHelper2.GetParameter("@classId", SqlDbType.Int, 4, "[classId]", classId) };
        return SQLHelper2.ExecuteSql(sb.ToString(), param);
        
    }

    #endregion

    #region 增

    /// <summary>
    /// 增加一个类别，childNum默认为0
    /// </summary>
    /// <param name="className"></param>
    /// <param name="classDescrip"></param>
    /// <param name="parentId"></param>
    /// <param name="sortId"></param>
    /// <param name="depth"></param>
    /// <returns></returns>
    public int AddClass(string className, string classDescrip, int parentId, int sortId, int depth, decimal workhours)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("insert into classes ([className],[classDescrip],[parentId],[sortId],[depth],[workhours]) values ");
        sb.Append("(@className,@classDescrip,@parentId,@sortId,@depth,@workhours)");
        SqlParameter[] param = 
                                    {
                                        SQLHelper2.GetParameter("@className",SqlDbType.Char,50,"[className]",className),
                                        SQLHelper2.GetParameter("@classDescrip",SqlDbType.Char,5000,"[classDescrip]",classDescrip),
                                        SQLHelper2.GetParameter("@parentId",SqlDbType.Int,4,"[parentId]",parentId),
                                        SQLHelper2.GetParameter("@sortId",SqlDbType.Int,4,"[sortId]",sortId),
                                        SQLHelper2.GetParameter("@depth",SqlDbType.Int,4,"[depth]",depth),
                                        SQLHelper2.GetParameter("@workhours",SqlDbType.Decimal,18,"[workhours]",workhours)
                                    };
        return SQLHelper2.ExecuteSql(sb.ToString(), param);
        
    }

    #endregion

    //取当前类ID所有的经过的父类节点放在string中，中间用,隔开 例如classId=23
    public string GetRoute(string classId)
    {
        string strResult = "";
        GetRouteNode(classId);
        for (int i = listGetRoute.Count - 1; i >= 0; i--)
        {
            strResult += listGetRoute[i] + ".";
        }
        listGetRoute.Clear();

        strResult = strResult.Remove(strResult.LastIndexOf("."), 1);
        return strResult;
    }

    //取当前父类ID所有的最后的节点放在List<string>,例如parentId=0
    public List<string> GetAllEndChild(string parentId)
    {
        List<string> listRet= new List<string>();
        GetAllEndChildNode(parentId);
        for (int i = 0; i < listGetAllEndChildNode.Count; i++)
        {
            listRet.Add(listGetAllEndChildNode[i]);
        }
        listGetAllEndChildNode.Clear();
        return listRet;
    }


    
    private List<string> listGetRoute = new List<string>();
    private void GetRouteNode(string classId)
    {
        DataTable dt = GetClass("classId=" + classId.ToString());
        string className = dt.Rows[0]["className"].ToString();
        string parentId = dt.Rows[0]["parentId"].ToString();

        if (!"0".Equals(parentId))
        {
            listGetRoute.Add(className);
            GetRouteNode(parentId);
        }
        else
        {
            listGetRoute.Add(className);
        }    
    }

    
    private List<string> listGetAllEndChildNode= new List<string>();
    private void GetAllEndChildNode(string parentId)
    {       
        DataTable dt = GetClass("parentId=" + parentId.ToString());

        if (dt.Rows.Count == 0)
        {
            listGetAllEndChildNode.Add(parentId);
        }
        else
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GetAllEndChildNode(dt.Rows[i]["classId"].ToString());
            }
        }      
    }

    public Classes()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
}
