using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    static Player _instance;
    public static Player Instance
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


    int nMoveState = 0;//0不移动   1移动
    float fMoveSpeed = 5;//移动速度

    Vector3 mVecDir;//照相机与玩家之间的向量
    public GameObject objNPC;//NPC对象
    const float FightDistance = 10;

    #region 移动
    void KeyEvent()    //W键z轴正方向   S键z轴负方向 A键x轴负方向 D键x轴正方向 
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            DoDir(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            DoDir(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            DoDir(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DoDir(Vector3.right);
        }

        if (Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) )
        {
            nMoveState = 0;
            SetAction(PlayerData.Action_Stand);
        }
    }

    void UpdateMove()   //跟新动作
    {
        if (nMoveState == 1)
        {
            transform.Translate(Vector3.forward * fMoveSpeed * Time.deltaTime);
            Camera.main.transform.position = transform.position + mVecDir;
        }
    }

    void DoDir(Vector3 dir)
    {
        transform.forward = dir;
        nMoveState = 1;
        SetAction(PlayerData.Action_Run);
    }

    #endregion

    #region 动作
    Animator mAni;
    void SetAction(int id)
    {
        mAni.SetInteger("action", id);
    }

    void DoAttack()//进入战斗
    {
        Debug.Log("点击战斗");
        float length = Vector3.Distance(transform.position, objNPC.transform.position);
        if (length <= FightDistance)
        {
            CanvasManager.Instance.SetCanvasShow("Canvas_Battle/Image_Introduce", true);
        }
    }
    #endregion


    private void Start()
    {
        mAni = GetComponent<Animator>();
        SetAction(PlayerData.Action_Stand);
        mVecDir = Camera.main.transform.position - transform.position;
    }
    private void Update()
    {
        KeyEvent();
        UpdateMove();
    }

  public void DoEvent(int eventID)
    {
        if (eventID == 0)
        {
            nMoveState = 0;
            SetAction(PlayerData.Action_Stand);

        }
        else if (eventID == 1)
        {
            DoDir(Vector3.forward);
        }
        else if (eventID == 2)
        {
            DoDir(Vector3.back);
        }
        else if (eventID == 3)
        {
            DoDir(Vector3.left);
        }
        else if (eventID == 4)
        {
            DoDir(Vector3.right);
        }
        else if (eventID == 5)
        {
            DoAttack();
        }
    }

}
