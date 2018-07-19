using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMarket : MonoBehaviour
{
    public Transform itemMarketContent;//商品滑块的父节点
    const int itemMarketNum = 5;
    List<ItemData> dataList = ItemDataManager.Instance.dataList;


    private void Start()
    {
        RandomCreate();
    }
    public void OnClickClose()//关闭按钮
    {
        gameObject.SetActive(false);
    }

    void RandomCreate()//随机生成5个物品
    {
        GameObject prefab = (GameObject)Resources.Load("Prefab/Image_Market");//预设只需要加载一次，之后的5次都用它来渲染
        if (prefab == null)
        {
            Debug.Log("没加商品滑块预设");
            return;
        }
        
        for (int i = 0; i < itemMarketNum; i++)
        {
            int id = Random.Range(1, dataList.Count);  //根据物品数量随机生成一个物品            
            GameObject objMarket = Instantiate(prefab);//克隆      
            objMarket.transform.parent = itemMarketContent;
            ItemMarket item = objMarket.GetComponent<ItemMarket>();
            item.SetID(dataList[id].ID);
        }
    }

 
    public void OnClickUpdate()//刷新按钮
    {
        for (int i = 0; i < itemMarketNum; i++)
        {
            int id = Random.Range(1, dataList.Count);
            GameObject item = itemMarketContent.GetChild(i).gameObject;
            ItemMarket it = item.GetComponent<ItemMarket>();
            it.SetID(dataList[id].ID);
        }

    }
}
