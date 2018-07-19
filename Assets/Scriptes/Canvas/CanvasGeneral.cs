using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanvasGeneral : MonoBehaviour {
    public GameObject heroCard;//英雄卡牌
    public Transform heroContent;//放置scorllview卡牌的容器
    ItemGeneral mhero;//选中英雄对象
    ItemGeneral generalItem;//当前选中武将对象
    
    void Start()
    { 
        InitGeneral();
    }

    void InitGeneral()
    { 
        List<GeneralData> dataList = GeneralDataManager.Instance.dataList;//获取武将数据
   
        for(int i=0;i<dataList.Count;i++)
        {
           
            int level = PlayerData.Instance.GetGeneralLevel(dataList[i].ID);
            if (level==0)
            {
                continue;
            }
            GameObject objGeneral = Instantiate(heroCard);
            objGeneral.transform.parent = heroContent;//设置父节点
            objGeneral.transform.localScale = Vector3.one;//设置缩放

            ItemGeneral item = objGeneral.GetComponent<ItemGeneral>();
            item.SetID(dataList[i].ID);//设置武将数据
            if (i == 0)
            {
                SetGeneralItem(item);//默认选中第一个武将
            }
        }
    }

    //public void SetHeroCard(ItemGeneral _item)
    //{
    //    if (mhero != null)
    //    {
    //        mhero.Selected(false);
    //    }
    //    mhero = _item;
    //    mhero.Selected(true);
    //}
    public void OnClickBack()//返回按钮
    {
        gameObject.SetActive(false);
    }
    public void OnClickShuXing()//查看属性
    {
        CanvasManager.Instance.SetCanvasShow("RawImage_renwushuxing", true);
        //试一下直接通过脚本查找能不能直接找到
        Transform trShuxing = CanvasManager.Instance.FindCanvasName("RawImage_renwushuxing");
        CanvasShuXing can = trShuxing.GetComponent<CanvasShuXing>();
        can.SetID(generalItem.GetID());
    }
    public void OnClickQun(GameObject wujiaoxing)//群按钮
    {
        Debug.Log("qun");
        SetShangzhen(3, wujiaoxing);
    }
    public void OnClickWei(GameObject wujiaoxing)//魏按钮
    {
        Debug.Log("wei");
        SetShangzhen(0, wujiaoxing);
    }
    public void OnClickShu(GameObject wujiaoxing)//蜀按钮
    {
        Debug.Log("shu");
        SetShangzhen(1, wujiaoxing);
    }
    public void OnClickWu(GameObject wujiaoxing)//吴按钮
    {
        Debug.Log("wu");
        SetShangzhen(2, wujiaoxing);
    }

    //设置武将选择魏蜀吴群
    public void SetShangzhen(int zhenYing,GameObject objwujiaoxing)
    {
        bool show = !objwujiaoxing.activeSelf;
        objwujiaoxing.SetActive(show);
        for (int i = 0; i < heroContent.childCount; i++)
        {
            Transform child = heroContent.transform.GetChild(i);
            ItemGeneral item = child.GetComponent<ItemGeneral>();
            int id = item.GetID();
            GeneralData data = GeneralDataManager.Instance.GetGeneralData(id);

            if (data.zhenYing!=zhenYing)
            {
                continue;
            }
            int s = show == true ? 1 : 0;
            PlayerData.Instance.SetGeneralShangZhen(id,s);
            item.SetShangzhen(s);
        }
    }

    public void SetGeneralItem(ItemGeneral item)//设置显示选中
    {
        if (generalItem == item)
        {
            int id = item.GetID();
            int shang = PlayerData.Instance.GetGeneralShangZhen(id);
            PlayerData.Instance.SetGeneralShangZhen(id,1-shang);
            item.SetShangzhen(1-shang);
            return;
        }
        if (generalItem != null)
        {
            generalItem.SetChoise(false);
        }
        generalItem = item;
        generalItem.SetChoise(true);
    }
}
