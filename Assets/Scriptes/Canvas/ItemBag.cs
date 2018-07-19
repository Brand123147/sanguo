using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBag : MonoBehaviour {
    public GameObject objKuang;
    public Image imIcon;
    public Text textNum;
    int nID;//物品ID

    private void Start()
    {
        if (imIcon.sprite.name == "1001")
        {
            Debug.Log(imIcon.sprite.name + ":" + nID);
        }
    }

    public void SetID(int id)
    {
        //设置图片
        nID = id;
        ItemData data = ItemDataManager.Instance.GetItemData(id);
        string iconName = data.imName;//获取图片名称
        Image im = ImageManager.Instance.GetImage(iconName);//获取图片对象
        imIcon.sprite = im.sprite;//设置图片
        gameObject.SetActive(true);
        //设置数量
        int num = PlayerData.Instance.GetItemNum(nID);
        textNum.text = num.ToString();
    }

    public int GetID()
    {
        return nID;
    }

    public void OnClickItem()
    {
        Debug.Log("点击:" + imIcon.sprite.name);
        Transform trCanvas = CanvasManager.Instance.FindCanvasName("RawImage_bag");
        if (trCanvas == null)
        {
            Debug.Log("没有找到：cancasbag");
            return;
        }
        CanvasBag can = trCanvas.GetComponent<CanvasBag>();
        can.SetItemBag(this);
    }

    public void Selected(bool show)//调用选中框
    {
        objKuang.SetActive(show);
    }

    public void SetNum(int num)//背包数目
    {
        textNum.text = num.ToString();
    }
}
