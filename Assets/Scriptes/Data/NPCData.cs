using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


public class NPCData   //物品数据类
{
    public int ID;          //NPCID
    public string name;     //NPC名称
    public string prefabName;     //预设名称
    public int life;
    public int attack;
    public int def;
    public int crit;
    public int attackMax;

    public NPCData(ArrayList ar)
    {
        ID = (int)ar[0];
        name = (string)ar[1];
        prefabName = (string)ar[2];
        life = (int)ar[3];
        attack = (int)ar[4];
        def = (int)ar[5];
        crit = (int)ar[6];
        attackMax = (int)ar[7];
    }
}

public class NPCDataManager//管理
{
    static NPCDataManager _instance;
    public static NPCDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new NPCDataManager();
            }
            return _instance;
        }
    }
    //public NPCDataManager() {  }
    //~NPCDataManager(){ _instance = null; }

    public List<NPCData> dataList = new List<NPCData>();
    public void LoadFile(string fileName)
    {
        MyLoad file = new MyLoad();
        file.LoadFile(fileName);
        for(int i = 0; i < file.dataList.Count; i++)
        {
            NPCData data = new NPCData((ArrayList)file.dataList[i]);
            dataList.Add(data);
        }
    }

    public NPCData GetNPCData(int id)
    {
        for(int i = 0; i < dataList.Count; i++)
        {
            if (dataList[i].ID == id) { return dataList[i]; }
        }
        return null;
    }

    
}
