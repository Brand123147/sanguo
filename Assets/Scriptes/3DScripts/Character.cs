using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    int generalID;//角色ID
    int country;//阵营0我方 1npc
    public int life;//生命
    public int attack;
    public int def;
    public float crit;
    public int attackMax;//攻击最大值

    const float AttackArea = 3;//攻击范围

    int nState = 0;//角色状态 0追踪  1攻击
    //追踪
    public GameObject objTarget;//目标
    float fMoveSpeed = 1;


    //动作
    Animator mAni;
    // Use this for initialization
    void Start()
    {
        mAni = GetComponent<Animator>();
        SetAction(PlayerData.Action_Stand);
        FindTarget();
    }
    void SetAction(int actionID)
    {
        mAni.SetInteger("action", actionID);
    }
    // Update is called once per frame
    void Update()
    {
        if (nState == 0)//追踪
        {
            UpdateZhuiZong();
        }
    }

    public void SetCharactorData(int id, int _country)
    {
        generalID = id;
        country = _country;
        if (country == 0)
        {
            GeneralData data = GeneralDataManager.Instance.GetGeneralData(id);//获取武将
            int level = PlayerData.Instance.GetGeneralLevel(id);//获取武将等级
            life = data.lifeBase + level * data.lifeRate;
            attack = data.attBase + level * data.attRate;
            def = data.defBase + level * data.defRate;
            crit = data.criBase + level * data.criRate;
            attackMax = data.attackMax;
        }
        else  //敌方角色
        {
            NPCData npcdata = NPCDataManager.Instance.GetNPCData(id);
            life = npcdata.life;
            attack = npcdata.attack;
            def = npcdata.def;
            crit = npcdata.crit;
            attackMax = npcdata.attackMax;
        }

    }


    public void FindTarget()
    {
        StopAction();
        List<GameObject> targetList;
        if (country == 0)
        {
            targetList = CharacterManager.Instance.npcList;
        }
        else
        {
            targetList = CharacterManager.Instance.playerList;
        }
        if (targetList.Count == 0)//目标数为0
        {
            CharacterManager.Instance.FightOver(country);
            return;
        }
        int r = Random.Range(0, targetList.Count);
        objTarget = targetList[r];//赋值攻击目标
        SetAction(PlayerData.Action_Run);
        nState = 0;
    }

    void UpdateZhuiZong()
    {
        transform.position = Vector3.MoveTowards(transform.position, objTarget.transform.position, fMoveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, objTarget.transform.position) <= AttackArea)
        {
            nState = 1;//进入攻击状态
            Debug.Log("fighting");
            StartCoroutine(attackTaget());
        }
    }

    public void StopAction()
    {
        StopCoroutine(attackTaget());
    }

    IEnumerator attackTaget()
    {
        int r = Random.Range(PlayerData.Action_Attack1, attackMax);
        SetAction(r);
        yield return new WaitForSeconds(0.5f);
        if (CharacterManager.Instance.nFightState == 0)
        {
            Character targetCha = objTarget.GetComponent<Character>();
            int demage = attack - targetCha.def;
            int baoji = Random.Range(0, 100);
            if (baoji < crit)
            {
                demage *= 2;
            }

            targetCha.life -= demage;
            if (targetCha.life <= 0)
            {
                //目标死亡，所有的攻击目标为ongTarget的角色，重置攻击目标
                Debug.Log("目标死亡");
                targetCha.StopAction();
                CharacterManager.Instance.ResetTarget(objTarget, country);
            }
            else//没死
            {
                Debug.Log(targetCha.name + "剩余血量：" + targetCha.life);
                SetAction(PlayerData.Action_Stand);
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(attackTaget());

            }
        }

    }

}
