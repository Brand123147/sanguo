using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasXuanGuan : MonoBehaviour {
    public GameObject prefab;//关卡预设对象


    private void Start()
    {
        InitXuanGuanData();
    }
    void InitXuanGuanData()
    {
        List<XuanGuanData> dataList = XuanGuanDataManager.Instance.dataList;
        for (int i = 0; i < dataList.Count; i++)
        {
            GameObject objGuan = Instantiate(prefab);
            objGuan.transform.parent = transform;
            objGuan.transform.localPosition = new Vector3(dataList[i].x, dataList[i].y, 0);

            ItemGuan guan = objGuan.GetComponent<ItemGuan>();//获取每个关卡标志脚本
            guan.SetID(dataList[i].ID);//设置ID即关卡名称
        }
    }
    public void OnClickBack()
    {
        gameObject.SetActive(false);
    }
}
