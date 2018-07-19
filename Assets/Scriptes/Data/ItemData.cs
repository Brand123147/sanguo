using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


public class ItemData   //物品数据类
{
    public int ID;          //物品类型
    public string name;     //物品名称
    public string imName;     //小图名称
    public string shuoMing;       //物品说明
    public int buy;//购买价格
    public int sell;//出售价格
    public int useType;//使用类型

    public ItemData(ArrayList ar)
    {
        ID = (int)ar[0];
        name = (string)ar[1];
        imName = (string)ar[2];
        shuoMing = (string)ar[3];
        buy = (int)ar[4];
        sell = (int)ar[5];
        useType = (int)ar[6];
    }
}

public class ItemDataManager//管理
{
    static ItemDataManager _instance;
    public static ItemDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ItemDataManager();
            }
            return _instance;
        }
    }

    public List<ItemData> dataList = new List<ItemData>();
    public void LoadFile(string fileName)
    {
        MyLoad file = new MyLoad();
        file.LoadFile(fileName);
        for(int i = 0; i < file.dataList.Count; i++)
        {
            ItemData data = new ItemData((ArrayList)file.dataList[i]);
            dataList.Add(data);
        }
    }

    public ItemData GetItemData(int id)//获取服务器所有物品数据函数方便调用
    {
        for(int i = 0; i < dataList.Count; i++)
        {
            if (dataList[i].ID == id) { return dataList[i]; }
        }
        return null;
    }
}
