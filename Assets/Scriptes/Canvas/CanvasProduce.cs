using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasProduce : MonoBehaviour {
    public Text textName;  //关卡名称
    public Text textShuoming;//关卡说明
    public Text[] textNum;//关卡产出数量

    int guanID;//关卡ID
    public void OnClickCancel()
    {
        gameObject.SetActive(false);
    }

    public void OnClickOK()
    {
        PlayerData.Instance.GuanNow = guanID;
        ResManager.Instance.MyLoadSceneAsync("Battle");
    }

    public void SetID(int id)
    {
        guanID = id;
        XuanGuanData data = XuanGuanDataManager.Instance.GetXuanGuanData(id);
        textName.text = data.name;
        textShuoming.text = data.shuoming;
        for (int i = 0; i < textNum.Length; i++)
        {
            textNum[i].text = data.num[i].ToString();
        }
    }
}
