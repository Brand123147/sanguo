using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {
    public PlayerData data = PlayerData.Instance;
    public void AddDiamonds()
    {

        AddMaterials(0);
    }
    public void AddCoin()
    {
        AddMaterials(1);
    }
    public void AddWood()
    {
        AddMaterials(2);
    }
    public void AddStone()
    {
        AddMaterials(3);
    }
    public void OnClickBag()
    {
        CanvasManager.Instance.SetCanvasShow("RawImage_bag",true);
    }
    public void OnClickMarket()
    {
        CanvasManager.Instance.SetCanvasShow("RawImage_market", true);
    }
    public void OnClickHero()
    {
        CanvasManager.Instance.SetCanvasShow("RawImage_selecthero", true);
    }
    public void OnClickBattle()
    {
        CanvasManager.Instance.SetCanvasShow("RawImage_guanka", true);
    }

    // Use this for initialization
    void Start () {
        XuanGuanData data = XuanGuanDataManager.Instance.GetXuanGuanData(4);
        if (!PlayerData.Instance.bInit)
        {
            PlayerData.Instance.bInit = true;
            InitPlayData();
        }
             
	}
	void InitPlayData()
    {
        data.PlayName = "曹操";
        data.Yuanbao =  Random.Range(100, 10000);
        data.Power = Random.Range(0,101);
        for(int i = 0; i < PlayerData.MaterialTypeMax; i++)
        {
            data.AddMaterialNum(i,Random.Range(0, 10000));
        }

        //背包物品
        List<ItemData> dataList = ItemDataManager.Instance.dataList;
        PlayerData.Instance.ItemList = new int[dataList.Count][];
        for(int i = 0; i < dataList.Count; i++)
        {
            PlayerData.Instance.ItemList[i] = new int[2];//0物品ID
            PlayerData.Instance.ItemList[i][0] = dataList[i].ID;
            PlayerData.Instance.ItemList[i][1] = Random.Range(0, 100);
        }


        //武将
        List<GeneralData> wujiangDataList = GeneralDataManager.Instance.dataList;//获取武将数据表数据
        PlayerData.Instance.generalList = new int[wujiangDataList.Count][];
        for (int i = 0; i < wujiangDataList.Count; i++)
        {
            PlayerData.Instance.generalList[i] = new int[3];
            PlayerData.Instance.generalList[i][0] = wujiangDataList[i].ID;//武将ID
            if (i==2||i==4)
            {
                PlayerData.Instance.generalList[i][1] = 0;
            }
            else { PlayerData.Instance.generalList[i][1] = Random.Range(1,100); }//武将等级
            PlayerData.Instance.generalList[i][2] = 1;//默认全部上阵
            if (i == 1)
            {
                PlayerData.Instance.generalList[i][2] = 0;
            }
        }


        //初始化商店

        
    }

    void AddMaterials(int type)
    {            
        if (data.Yuanbao <= 0)
        {
            Debug.Log("没钱了，别贪心了！！");           
            data.Yuanbao = 0;
            return;
        }
        data.Yuanbao--;
        data.AddMaterialNum(type, 10);
        TopBar.Instance.Show();

    }
	
}
