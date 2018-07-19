using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirControl : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    Vector2 dir;//方向
    int dirNum = 0;//当前朝向
    public GameObject objUp;
    public GameObject objDown;
    public GameObject objLeft;
    public GameObject objRight;
    // Use this for initialization
    void Start()
    {
        SetDir(0);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        SetDir(0);
    }


    // 移动圆盘拖拽函数
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 mouseDown = eventData.position;//获取鼠标点位
        Vector2 vecBtn = new Vector2(Screen.width / 2 + transform.localPosition.x,
            Screen.height / 2 + transform.localPosition.y);
        dir = mouseDown - vecBtn;

        //圆盘右半边
        if (dir.x > 0)
        {
           
            if (dir.y > dir.x)//上
            {
                SetDir(1);
            }
            else if (dir.y < -dir.x)
            {
                SetDir(2);
            }
            else
            {
                SetDir(4);
            }
        }
        //圆盘左半边
        if (dir.x < 0)
        {
            if (dir.y > -dir.x)//上
            {
                SetDir(1);
            }
            else if (dir.y < dir.x)
            {
                SetDir(2);
            }
            else
            {
                SetDir(3);
            }
        }
    }

    void SetDir(int dir)
    {
        if (dirNum==dir)
        {
            return;
        }
        dirNum = dir;
        objUp.SetActive(dir == 1 ? true : false);//面板移动
        objDown.SetActive(dir == 2 ? true : false);
        objLeft.SetActive(dir == 3 ? true : false);
        objRight.SetActive(dir == 4 ? true : false);
        Player.Instance.DoEvent(dir);//人物移动
    }

}
