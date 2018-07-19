using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour {

    static ImageManager _instance;

    public static ImageManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake() { _instance = this;}
    private void OnDestroy(){ _instance = null;}
    public Image GetImage(string imName)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Image im = child.GetComponent<Image>();
            if (im.name == imName)
            {
                return im;
            }
        }
        Debug.LogError("没找到该图片" + imName);
        return null;
    }
}
