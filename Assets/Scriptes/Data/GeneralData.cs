using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


public class GeneralData   //物品数据类
{
    public int ID;          //武将ID
    public string name;     //武将名称
    public string imName;     //武将图片
    public string zhenYingPic;//阵营图片
    public int zhenYing;//武将阵营
    public string shuoming;//武将说明
    public int lifeBase;//基础生命
    public int lifeRate;
    public int attBase;
    public int attRate;
    public int defBase;
    public int defRate;
    public float criBase;
    public float criRate;
    public string prefabName;//模型预设名称
    public int attackMax;//攻击最大动作




    public GeneralData(ArrayList ar)
    {
        ID = (int)ar[0];
        name = (string)ar[1];
        imName = (string)ar[2];
        zhenYing = (int)ar[3];
        zhenYingPic = (string)ar[4];
        shuoming = (string)ar[5];
        lifeBase = (int)ar[6];
        lifeRate = (int)ar[7];
        attBase = (int)ar[8];
        attRate = (int)ar[9];
        defBase = (int)ar[10];
        defRate = (int)ar[11];
        criBase = (float)ar[12];
        criRate = (float)ar[13];
        prefabName = (string)ar[14];
        attackMax = (int)ar[15];
    }
}

public class GeneralDataManager//管理
{
    static GeneralDataManager _instance;
    public static GeneralDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GeneralDataManager();
            }
            return _instance;
        }
    }
    //public GeneralDataManager() {  }
    //~GeneralDataManager(){ _instance = null; }

    public List<GeneralData> dataList = new List<GeneralData>();
    public void LoadFile(string fileName)
    {
        MyLoad file = new MyLoad();
        file.LoadFile(fileName);
        for(int i = 0; i < file.dataList.Count; i++)
        {
            GeneralData data = new GeneralData((ArrayList)file.dataList[i]);
            dataList.Add(data);
        }
    }

    public GeneralData GetGeneralData(int id)
    {
        for(int i = 0; i < dataList.Count; i++)
        {
            if (dataList[i].ID == id) { return dataList[i]; }
        }
        return null;
    }
}
