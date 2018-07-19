using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


public class NPCGuanData   //NPC关卡数据类
{
    public int ID;          //NPC关卡序号
    public int[] npcID = new int[NPCGuanDataManager.NPCNumMax];


    public NPCGuanData(ArrayList ar)
    {
        ID = (int)ar[0];
        for (int i = 0; i < npcID.Length; i++)
        {
            npcID[i] = (int)ar[1 + i];
        }
    }
}

public class NPCGuanDataManager//管理
{
    static NPCGuanDataManager _instance;
    public static NPCGuanDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new NPCGuanDataManager();
            }
            return _instance;
        }
    }
    //public NPCGuanDataManager() {  }
    //~NPCGuanDataManager(){ _instance = null; }

    public List<NPCGuanData> dataList = new List<NPCGuanData>();

    public const int NPCNumMax = 4;//美观NPC最大数量
    public void LoadFile(string fileName)
    {
        MyLoad file = new MyLoad();
        file.LoadFile(fileName);
        for(int i = 0; i < file.dataList.Count; i++)
        {
            NPCGuanData data = new NPCGuanData((ArrayList)file.dataList[i]);
            dataList.Add(data);
        }
    }

    public NPCGuanData GetNPCGuanData(int id)
    {
        for(int i = 0; i < dataList.Count; i++)
        {
            if (dataList[i].ID == id) { return dataList[i]; }
        }
        return null;
    }
}
