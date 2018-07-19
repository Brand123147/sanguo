using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBag : MonoBehaviour
{
    //右边数据
    public GameObject BagGrid;//背包对象
    public Transform trContent;//content对象
    ItemBag mitem;//选中的物品的对象


    //左边数据
    public Image imIcon;
    public Text textName;
    public Text textShuoming;
    public Text textSell;
    
    private void Start()
    {
        InitItem();
    }
    void InitItem()
    {
        List<ItemData> dataList = ItemDataManager.Instance.dataList;
        for (int i = 0; i < dataList.Count; i++)
        {
            GameObject objBag = Instantiate(BagGrid);
            //objBag.SetActive(true);
            objBag.transform.parent = trContent;
            ItemBag item = objBag.GetComponent<ItemBag>();
            item.SetID(dataList[i].ID);
            if (i == 0)
            {
                SetItemBag(item);
            }
        }
    }
    public void OnClickClose()
    {
        gameObject.SetActive(false);
    }

    public void SetItemBag(ItemBag _item)
    {
        if (mitem != null)
        {
            mitem.Selected(false);
        }
        mitem = _item;
        mitem.Selected(true);
        SetItemData();
    }


    //左边
    void SetItemData()
    {
        int id = mitem.GetID();
        ItemData data = ItemDataManager.Instance.GetItemData(id);//获取物品数据
    //设置图片
        string iconName = data.imName;//获取图片名称
        Image im = ImageManager.Instance.GetImage(iconName);//获取图片对象
        imIcon.sprite = im.sprite;//设置图片
                                
        textName.text = data.name;
        textShuoming.text = data.shuoMing;
        textSell.text = data.sell.ToString();
    }
    public void OnClickUse()
    {
        Debug.Log("点击使用");
        int id = mitem.GetID();
       
        int num = PlayerData.Instance.GetItemNum(id);
        if (num <= 0) return;
        ItemData data = ItemDataManager.Instance.GetItemData(id);
        //数据更改
        PlayerData.Instance.AddItemNum(id, -1);
        PlayerData.Instance.AddMaterialNum(data.useType,10);
        
        //界面显示       
        mitem.SetNum(PlayerData.Instance.GetItemNum(id));//更新背包界面显示
        TopBar.Instance.Show();//更新显示元宝（和menu界面的4中材料） 
    }
    public void OnClickSell()
    {
        Debug.Log("点击出售");
        int id = mitem.GetID();
        int num = PlayerData.Instance.GetItemNum(id);
        if (num <= 0) return;
        ItemData data = ItemDataManager.Instance.GetItemData(id);
        //数据更改
        PlayerData.Instance.AddItemNum(id, -1);
        PlayerData.Instance.Yuanbao += data.sell;
        //界面显示       
        mitem.SetNum(PlayerData.Instance.GetItemNum(id));//更新背包界面显示
        TopBar.Instance.Show();//更新显示元宝（和menu界面的4中材料）        
    }
}
