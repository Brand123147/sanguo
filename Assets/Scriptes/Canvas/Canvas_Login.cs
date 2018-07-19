using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Login : MonoBehaviour {
    public Dropdown mDropdown;
    public Text mTextState;

    List<string> serverName = new List<string>();
    
	void Start () {
        List<Dropdown.OptionData> optionList = new List<Dropdown.OptionData>();
        List<ServerData> dataList = ServerDataManager.Instance.dataList;
        for (int i = 0; i < dataList.Count; i++)
        {
            Dropdown.OptionData data = new Dropdown.OptionData(dataList[i].qu+":"+dataList[i].name);
            optionList.Add(data);
        }
        mDropdown.AddOptions(optionList);
        SetServerState();
    }

	void Update () {
      
	}

    public void OnClickBegin()
    {
        int id = mDropdown.value;
        List<ServerData> datalist = ServerDataManager.Instance.dataList;
        int state = datalist[id].state;
        if (state == 0)
        {

            return;
        }
        ResManager.Instance.MyLoadSceneAsync("Menu");
    }
    public void OnClickRegister()
    {

    }
    public void OnDropDownChange()
    {
        SetServerState();
    }
    void SetServerState()
    {
        int id = mDropdown.value;
        List<ServerData> datalist = ServerDataManager.Instance.dataList;
        int state = datalist[id].state;

        if(state==0)//维护
        {
            mTextState.text = "维护";
            mTextState.color = Color.gray;
        }
        else if (state == 1)//维护
        {
            mTextState.text = "良好";
            mTextState.color = Color.green;
        }
        else if (state == 2)//维护
        {
            mTextState.text = "爆满";
            mTextState.color = Color.red;
        }

    }
}
