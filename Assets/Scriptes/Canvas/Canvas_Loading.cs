using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas_Loading : MonoBehaviour {
    public Image im_Loading;
    public Text text_Loading;
    float result;
    AsyncOperation asy;//异步加载类
    float fLoadingTime = 0;
    float fLoadingTiemMax = 2;

	void Start () {
        asy = SceneManager.LoadSceneAsync(ResManager.Instance.mSceneName);
        asy.allowSceneActivation = false;
	}
	void Update () {
        fLoadingTime += Time.deltaTime;
        result = fLoadingTime / fLoadingTiemMax;
        im_Loading.fillAmount = result;
        text_Loading.text = (result * 100f).ToString("f0") + "%";

        if (result >= 1)
        {
            result = 1;
            asy.allowSceneActivation = true;
        }
    }
}
