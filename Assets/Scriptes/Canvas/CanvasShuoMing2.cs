using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasShuoMing2 : MonoBehaviour {

    public Text textName;//名称
    public Text[] textNum;
    public Image[] imIcon;
    int guanID;//关卡ID

    public void OnClickBack()
    {
        gameObject.SetActive(false);
    }
    public void OnClickFight()
    {
        ResManager.Instance.MyLoadSceneAsync("Fight");
    }

    void InitShuoming2()
    {
        guanID = PlayerData.Instance.GuanNow;
        XuanGuanData data = XuanGuanDataManager.Instance.GetXuanGuanData(guanID);
        textName.text = data.name;
        for (int i = 0; i < textNum.Length; i++)
        {
            textNum[i].text = data.num[i] + "";
        }
        int begin = 0;
        int[][] generalList = PlayerData.Instance.generalList;
        for (int i = 0; i < imIcon.Length; i++)
        {
            imIcon[i].gameObject.SetActive(false);
            for (int j =begin; j < generalList.Length; j++)
            {
                if (generalList[j][1]==0)
                {
                    continue;
                }
                if (generalList[j][2]==0)
                {
                    continue;
                }
                begin = j + 1;
                imIcon[i].gameObject.SetActive(true);
                GeneralData wujaingData = GeneralDataManager.Instance.GetGeneralData(generalList[j][0]);
                Image im = ImageManager.Instance.GetImage(wujaingData.imName);
                imIcon[i].sprite = im.sprite;
                break;
            }
        }
    }
	// Use this for initialization
	void Start () {
        InitShuoming2();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
