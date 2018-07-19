using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


public class XuanGuanData   //物品数据类
{
    public int ID;          //关卡ID
    public string name;//关卡名称
    public int x;
    public int y;
    public string shuoming;  //产出说明
    public int[] num = new int[PlayerData.MaterialTypeMax];//产出数量
    public int npcGuanID;//关卡数据ID

    public XuanGuanData(ArrayList ar)
    {
        ID = (int)ar[0];
        name = (string)ar[1];
        x = (int)ar[2];
        y = (int)ar[3];
        shuoming = (string)ar[4];
        for (int i = 0; i < PlayerData.MaterialTypeMax; i++)
        {
            num[i] = (int)ar[5 + i];
        }
        npcGuanID = (int)ar[9];
    }
}

public class XuanGuanDataManager//管理
{
    static XuanGuanDataManager _instance;
    public static XuanGuanDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new XuanGuanDataManager();
            }
            return _instance;
        }
    }
    //public XuanGuanDataManager() {  }
    //~XuanGuanDataManager(){ _instance = null; }

    public List<XuanGuanData> dataList = new List<XuanGuanData>();
    public void LoadFile(string fileName)
    {
        MyLoad file = new MyLoad();
        file.LoadFile(fileName);
        for(int i = 0; i < file.dataList.Count; i++)
        {
            XuanGuanData data = new XuanGuanData((ArrayList)file.dataList[i]);
            dataList.Add(data);
        }
    }

    public XuanGuanData GetXuanGuanData(int id)
    {
        for(int i = 0; i < dataList.Count; i++)
        {
            if (dataList[i].ID == id) { return dataList[i]; }
        }
        return null;
    }
}
