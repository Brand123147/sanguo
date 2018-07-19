using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGeneral : MonoBehaviour {
    public GameObject yiShangZhen;//已上阵标志
    public Image zhenYing;//阵营图片
    public Image heroIcon;//人物图片
    public Text textLevel;//等级
    public Text textName;//姓名    
    int hID;//人物ID
    public GameObject objChoise;//选中标记

    public void SetID(int id)
    {
        //设置图片
        hID = id;
        GeneralData data = GeneralDataManager.Instance.GetGeneralData(id);//获取武将数据   
        heroIcon.sprite = ImageManager.Instance.GetImage(data.imName).sprite;//设置武将图片
        zhenYing.sprite = ImageManager.Instance.GetImage(data.zhenYingPic).sprite;//设置阵营图片
        textName.text = data.name;

        int shang = PlayerData.Instance.GetGeneralShangZhen(id);
        SetShangzhen(shang);
        int level = PlayerData.Instance.GetGeneralLevel(id);
        textLevel.text = "LV:" + level;
    }

    public void SetShangzhen(int s)
    {     
        yiShangZhen.SetActive(s == 1 ? true : false);
    }

    public int GetID()
    {
        return hID;
    }


    public void SetChoise(bool choise)
    {
        objChoise.SetActive(choise);
    }


    public void OnClickItem()
    {
        Debug.Log("OnClickItem" + heroIcon.sprite.name);
        Transform trGeneral = CanvasManager.Instance.FindCanvasName("RawImage_selecthero");
        if (trGeneral == null)
        {
            Debug.LogError("资源未找到：canvasGerneral");
            return;
        }
        CanvasGeneral ge = trGeneral.GetComponent<CanvasGeneral>();
        ge.SetGeneralItem(this);
    }
    //public void OnClickGeneral()
    //{
    //    Debug.Log("点击:" + heroIcon.sprite.name);
    //    Transform trCanvas = CanvasManager.Instance.FindCanvasName("RawImage_bag");
    //    if (trCanvas == null)
    //    {
    //        Debug.Log("没有找到：cancasbag");
    //        return;
    //    }
    //    CanvasGeneral can = trCanvas.GetComponent<CanvasGeneral>();
    //    can.SetHeroCard(this);
    //}


}
