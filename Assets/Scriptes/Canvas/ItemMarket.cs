using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMarket : MonoBehaviour {
    public Image imIcon;//物品图片
    public Text textName;//物品名
    public Text textIntroduce;//物品说明
    public Text textPrice;//物品价格

    int itemID;//物品ID

    public void SetID(int id)
    {
        //设置图片
        itemID = id;
        ItemData data = ItemDataManager.Instance.GetItemData(id);//获取物品数据
        string iconName = data.imName;//获取图片名称
        Image im = ImageManager.Instance.GetImage(iconName);//获取图片对象
        imIcon.sprite = im.sprite;//设置图片

        //设置物品名称
        textName.text = data.name;
        textIntroduce.text = data.shuoMing;
        textPrice.text = data.buy.ToString();
    }
    public void OnClickBuy()
    {

    }
}
