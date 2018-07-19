using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasShuXing : MonoBehaviour {
    int generalID;//武将ID
    public Image imZhenYing;//阵营图片
    public Text textName;//武将名称
    public Text textLife;//生命
    public Text textAttack;//攻击力
    public Text textDef;//防御
    public Text textCrit;//暴击
    public Text textShuoming;//武将说明
    public Transform model;//模型父节点
    
    public void SetID(int id)
    {
        if (generalID==id)
        {
            return;
        }
        generalID = id;
        GeneralData data = GeneralDataManager.Instance.GetGeneralData(id);//获取武将数据
        Image imZhenying = ImageManager.Instance.GetImage(data.zhenYingPic);
        imZhenYing.sprite = imZhenying.sprite;//设置图片
        textName.text = data.name;//武将名称
        textShuoming.text = data.shuoming;//设置武将说明
        //计算各个属性值
        int level = PlayerData.Instance.GetGeneralLevel(id);
        int life = data.lifeBase + level * data.lifeRate;
        int attack = data.attBase + level * data.attRate;
        int def = data.defBase + level * data.defRate;
        float crit = data.criBase + level * data.criRate;
        //赋值
        textLife.text = life.ToString();
        textAttack.text = attack.ToString();
        textDef.text = def.ToString();
        textCrit.text = crit.ToString();

        //模型
        if (model.childCount > 0)
        {
            Transform child = model.GetChild(0);
            Destroy(child.gameObject);
        }
        GameObject prefab = (GameObject)Resources.Load(@"Prefab/Animator/" + data.prefabName);
        if (prefab == null)
        {
            Debug.Log("找不到预设体"+data.prefabName);
        }
        GameObject person = Instantiate(prefab);
        person.transform.parent = model;
        person.transform.localPosition = Vector3.zero;
        //person.transform.localScale = Vector3.one;
        //person.transform.rotation = new Quaternion(0, 0, 0, 1);//设置角度
    }
    public void OnClickClose()
    {
        gameObject.SetActive(false);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
