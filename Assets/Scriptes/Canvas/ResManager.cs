using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResManager : MonoBehaviour {
    private static ResManager _instance;
    public static ResManager Instance
    {
        get
        {
            return _instance;
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

    public string mSceneName;
    MyLoad Load = new MyLoad();
    private void Start()
    {  
        InitData();
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadSceneAsync("Login");
    }

    public void MyLoadSceneAsync(string sceneName)
    {
        mSceneName = sceneName;
        SceneManager.LoadSceneAsync("Loading");
    }
    void InitData()//加载全局资源，初始化数据
    {
        PlayerData play = PlayerData.Instance;
        ServerDataManager.Instance.LoadFile("ServerData");//加载服务器数据
        ItemDataManager.Instance.LoadFile("ItemData");//加载物品背包数据
        GeneralDataManager.Instance.LoadFile("GeneralData");//加载武将数据
        XuanGuanDataManager.Instance.LoadFile("XuanGuanData");//加载关卡数据
        NPCDataManager.Instance.LoadFile("NPCData");//NPC数据
        NPCGuanDataManager.Instance.LoadFile("NPCGuanData");//NPC关卡数据
    }
}
