using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    static CharacterManager _instance;
    public static CharacterManager Instance
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
    public List<GameObject> playerList = new List<GameObject>();
    public List<GameObject> npcList = new List<GameObject>();
    public int nFightState = 0;//战斗状态 0正在战斗 1我方胜利   2敌方胜利

    // Use this for initialization
    void Start()
    {
        InitCharactor();

    }

    // Update is called once per frame
    void Update()
    {
        if (nFightState == 1)//我方胜利
        {
            nFightState = 3;
            //弹出胜利结算界面
            if (PlayerData.Instance.OpenGuan == PlayerData.Instance.GuanNow)
            {
                PlayerData.Instance.OpenGuan++;
            }
            ResManager.Instance.MyLoadSceneAsync("Menu");
        }
        else if (nFightState == 2)//敌方胜利
        {
            //弹出失败结算界面
            nFightState = 3;
            ResManager.Instance.MyLoadSceneAsync("Menu");
        }
    }

    void InitCharactor()
    {
        InitNPC();
        InitPlayer();
    }
    void InitPlayer()//武将加载
    {
        int[][] generalList = PlayerData.Instance.generalList;
        float num = 0;//我方角色数量
        for (int i = 0; i < generalList.Length; i++)
        {
            if (generalList[i][1] == 0)//没有该武将
            {
                continue;
            }
            if (generalList[i][2] == 0)//该武将为上阵
            {
                continue;
            }
            GeneralData data = GeneralDataManager.Instance.GetGeneralData(generalList[i][0]);
            GameObject prefab = (GameObject)Resources.Load("Prefab/Animator/" + data.prefabName);
            GameObject objPlayer = Instantiate(prefab);
            objPlayer.transform.parent = transform;
            objPlayer.transform.position = new Vector3(num * 1.5f, 0, -3f);
            num++;

            Character cha = objPlayer.AddComponent<Character>();
            cha.SetCharactorData(data.ID, 0);
            playerList.Add(objPlayer);

        }
    }

    void InitNPC()//敌人加载
    {
        int NPCNum = 0;//NPC数量
        int guanID = PlayerData.Instance.GuanNow;
        XuanGuanData data = XuanGuanDataManager.Instance.GetXuanGuanData(guanID);//获取关卡数据
        NPCGuanData NPCGuanData = NPCGuanDataManager.Instance.GetNPCGuanData(data.npcGuanID);
        for (int i = 0; i < NPCGuanDataManager.NPCNumMax; i++)
        {
            if (NPCGuanData.npcID[i] == 0)
            {
                continue;
            }
            NPCData npcData = NPCDataManager.Instance.GetNPCData(NPCGuanData.npcID[i]);
            GameObject prefab = (GameObject)Resources.Load("Prefab/Animator/" + npcData.prefabName);
            GameObject objNPC = Instantiate(prefab);
            objNPC.transform.parent = transform;
            objNPC.transform.Rotate(0, 180, 0);
            objNPC.transform.position = new Vector3(NPCNum * 1.5f, 0, 5);
            NPCNum++;

            Character cha = objNPC.AddComponent<Character>();
            cha.SetCharactorData(npcData.ID, 1);
            npcList.Add(objNPC);
        }
    }

    public void FightOver(int zhenying)
    {
        if (zhenying == 0)
        {
            Debug.Log("vectory");
            nFightState = 1;
        }
        else
        {
            Debug.Log("Lose");
            nFightState = 2;
        }
    }

    public void ResetTarget(GameObject objTarget, int zhenying)
    {
        List<GameObject> objList;
        if (zhenying == 0)
        {
            objList = playerList;
            npcList.Remove(objTarget);

        }
        else
        {
            objList = npcList;
            playerList.Remove(objTarget);

        }
        for (int i = 0; i < objList.Count; i++)
        {
            Character cha = objList[i].GetComponent<Character>();
            if (cha.objTarget == objTarget)//角色目标已经死亡对象
            {
                cha.FindTarget();
            }
        }
        Destroy(objTarget);//死亡消失
    }
}
