using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


public class ServerData   //服务器数据类
{
    public int ID;          //服务器ID
    public string qu;       //服务器区
    public string name;     //服务器名称
    public int state;       //服务器状态
    public float test;      //测试数据
    public ServerData(ArrayList ar)
    {
        ID = (int)ar[0];
        qu = (string)ar[1];
        name = (string)ar[2];
        state = (int)ar[3];
        test = (float)ar[4];
    }
}

public class ServerDataManager//管理
{
    static ServerDataManager _instance;

    public static ServerDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ServerDataManager();
            }
            return _instance;
        }
    }

    public List<ServerData> dataList = new List<ServerData>();
    public void LoadFile(string fileName)
    {
        MyLoad file = new MyLoad();
        file.LoadFile(fileName);
        for(int i = 0; i < file.dataList.Count; i++)
        {
            ServerData data = new ServerData((ArrayList)file.dataList[i]);
            dataList.Add(data);
        }
    }
}
