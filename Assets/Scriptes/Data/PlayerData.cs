using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlayerData
{
    public const int PowerMax = 100;//体力上限
    string playName;
    public string PlayName
    {
        get
        {
            return playName;
        }

        set
        {
            playName = value;
        }
    }
    int yuanbao;
    public int Yuanbao
    {
        get
        {
            return yuanbao;
        }

        set
        {
            yuanbao = value;
        }
    }
    int power;
    public int Power
    {
        get
        {
            return power;
        }

        set
        {
            power = value;
        }
    }

    //单例
    static PlayerData _instance;
    public static PlayerData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerData();
            }
            return _instance;
        }
    }
    public PlayerData() { _instance = this; }//构造
    ~PlayerData()//脚本销毁不用时候清空
    {
        _instance = null;
    }


    public bool bInit = false;//判断是否加载过数据，放置返回时重新加载

    //材料topbar
    public const int MaterialTypeMax = 4;
    int[] materialList = new int[MaterialTypeMax];
    public void AddMaterialNum(int type, int num)
    {
        materialList[type] += num;
    }
    public int GetMaterialNum(int type)
    {
        return materialList[type];
    }

    //物品bag
    public int[][] ItemList;//物品数组0表示ID  1表示数量
    public int GetItemNum(int id)//获取物品数量函数方便调用
    {
        if (ItemList == null)
        {
            return 0;
        }
        for (int i = 0; i < ItemList.Length; i++)
        {
            if (ItemList[i][0] == id)
            {
                return ItemList[i][1];
            }

        }
        return 0;
    }

    public void AddItemNum(int id, int num)//添加物品数量函数方便调用
    {
        if (ItemList == null)
        {
            return;
        }
        for (int i = 0; i < ItemList.Length; i++)
        {
            if (ItemList[i][0] == id)
            {
                ItemList[i][1] += num;
            }
        }
    }

    //武将

        //等级
    public int[][] generalList;//武将数组 0武将ID 1武将等级 2是否上阵
    public void SetGeneralLevel(int _id, int _level)
    {
        if (generalList==null)
        {
            return;
        }
        for (int i = 0; i < generalList.Length; i++)
        {
            if (generalList[i][0] == _id)
            {
                generalList[i][1] = _level;
                return;
            }
        }
    }
    public int GetGeneralLevel(int _id)
    {
        if (generalList == null)
        {
            return 0;
        }
        for (int i = 0; i < generalList.Length; i++)
        {
            if (generalList[i][0] == _id)
            {
                return generalList[i][1];
            }
        }
        return 0;
    }


    //上阵
    public void SetGeneralShangZhen(int _id, int _sz)
    {
        if (generalList == null)
        {
            return;
        }
        for (int i = 0; i < generalList.Length; i++)
        {
            if (generalList[i][0] == _id)
            {
                generalList[i][2] = _sz;
                return;
            }
        }
    }
    public int GetGeneralShangZhen(int _id)
    {
        if (generalList == null)
        {
            return 0;
        }
        for (int i = 0; i < generalList.Length; i++)
        {
            if (generalList[i][0] == _id)
            {
                return generalList[i][2];
            }
        }
        return 0;
    }

    //选关   0关卡ID  1是否过关
    int openGuan = 4;//默认一开始开启4个关卡
    public int OpenGuan
    {
        get
        {
            return openGuan;
        }

        set
        {
            openGuan = value;
        }
    }

    public int GuanNow
    {
        get
        {
            return guanNow;
        }

        set
        {
            guanNow = value;
        }
    }

    int guanNow;
  

    //动作定义
    public const int Action_Stand = 0;
    public const int Action_Run = 1;
    public const int Action_Dead = 2;
    public const int Action_Combat = 3;
    public const int Action_Attack1= 4;
    public const int Action_Attack2 = 5;
    public const int Action_Attack3 = 6;
    public const int Action_Attack4 = 7;

}
