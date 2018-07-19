using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemGuan : MonoBehaviour {
    public Image imIcon;
    public Text textName;
    int guanID;//关卡ID
    
    public void SetID(int id)
    {
        guanID = id;
        XuanGuanData data = XuanGuanDataManager.Instance.GetXuanGuanData(id);
        textName.text = data.name;

        //判断是否过关开启
        Image imGuan;
        Button btn = imIcon.transform.Find("Button").GetComponent<Button>();
        if (data.ID <= PlayerData.Instance.OpenGuan)
        {
           imGuan = ImageManager.Instance.GetImage("WarInfo1_1L");
            btn.enabled=true;
        }
        else {
            imGuan = ImageManager.Instance.GetImage("WarInfo1_1D");
            btn.enabled = false;
        }
        imIcon.sprite = imGuan.sprite;
    }


    //点击关卡按钮
    public void OnClickGuan()
    {
        CanvasManager.Instance.SetCanvasShow("RawImage_Produce", true);
        Transform trShuoming1 = CanvasManager.Instance.FindCanvasName("RawImage_Produce");
        CanvasProduce  can = trShuoming1.GetComponent<CanvasProduce>();
        can.SetID(guanID);
        
    }

}
