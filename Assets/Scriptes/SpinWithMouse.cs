using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//public class SpinWithMouse : MonoBehaviour, IDragHandler
//{
//    public Transform target;  //要旋轉的三維物體的Transform組件
//    public float speed = 1f;

//    void Start()
//    {
//        if (target == null) target = transform;
//    }

//    public void OnDrag(PointerEventData eventData)
//    {
//        target.localRotation = Quaternion.Euler(0f, -0.5f * eventData.delta.x * speed, 0f) * target.localRotation;
//    }
//}

public class SpinWithMouse : MonoBehaviour, IDragHandler
{

    public Transform target;  //要旋轉的三維物體的Transform組件
    public float speed = 1f;

    void Start()
    {
        if (target == null) target = transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        target.localRotation = Quaternion.Euler(0f, -0.5f * eventData.delta.x * speed, 0f) * target.localRotation;
    }


}
