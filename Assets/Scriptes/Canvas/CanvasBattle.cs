using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBattle : MonoBehaviour {

	public void OnClickBack()
    {
        ResManager.Instance.MyLoadSceneAsync("Menu");
    }

    public void OnClickFight()
    {
        Player.Instance.DoEvent(5);
    }
}
