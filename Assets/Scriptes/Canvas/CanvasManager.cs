using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {
    static CanvasManager _instance;

    public static CanvasManager Instance
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
    public Transform FindCanvasName(string canvasName)
    {
        return transform.Find(canvasName);
    }
    public void SetCanvasShow(string canvasName,bool show)
    {
        Transform child = FindCanvasName(canvasName);
        if (child != null)
        {
            child.gameObject.SetActive(show);

        }
    }

}
