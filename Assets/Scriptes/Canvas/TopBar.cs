using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TopBar : MonoBehaviour {
    private Text playerNameText;
    private Text moneyText;
    private Text diamondText;
    private Text coinText;
    private Text woodText;
    private Text stoneText;
    private Text powerText;
    private Image powerImage;

    static TopBar _instance;

    public static TopBar Instance
    {
        get
        {
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
    private void Awake()
    {
        _instance = this;

    }
    private void OnDestroy()
    {
        _instance = null;
    }



    private void Start()
    {
        playerNameText = transform.Find("Im_playerbar/Im_namebg/Text").GetComponent<Text>();
        moneyText = transform.Find("Im_playerbar/Im_namebg/Text_icon").GetComponent<Text>();
        diamondText = transform.Find("Im_diamonds_bg/Text").GetComponent<Text>();
        coinText = transform.Find("Im_icon_bg/Text").GetComponent<Text>();
        woodText = transform.Find("Im_wood_bg/Text").GetComponent<Text>();
        stoneText = transform.Find("Im_stone_bg/Text").GetComponent<Text>();
        powerText = transform.Find("Im_playerbar/Im_powerbg/Im_power/Text").GetComponent<Text>();
        powerImage = transform.Find("Im_playerbar/Im_powerbg/Im_power").GetComponent<Image>();
        Show();
    }

    private void Update()
    {
      
    }

    public void Show()
    {
        PlayerData data = PlayerData.Instance;
        playerNameText.text = data.PlayName;
        moneyText.text = data.Yuanbao.ToString();
        powerText.text = data.Power+"/"+PlayerData.PowerMax;
        powerImage.fillAmount = data.Power / 100f;
        diamondText.text = data.GetMaterialNum(0).ToString();
        coinText.text = data.GetMaterialNum(1).ToString();
        woodText.text = data.GetMaterialNum(2).ToString();
        stoneText.text = data.GetMaterialNum(3).ToString();
    }
}
