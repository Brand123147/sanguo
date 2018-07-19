using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
class MyLoad
{
    ArrayList typeList = new ArrayList();//数据类型数组
    public ArrayList dataList = new ArrayList();//数据数组
    
    public MyLoad()
    {

    }
    public void LoadFile(string fileName)//读取文件数据
    {
        TextAsset serverData = Resources.Load<TextAsset>("FileData/"+fileName);
        if (serverData == null)
        {
            Debug.Log("资源未加上FileData / " + fileName);
            return;
        }
        ProcessFile(serverData.text);
    }

    void ProcessFile(string str)
    {
        int line = 0;//行数
        int begin = 0;//字符串开始位置
        int endl = 0;//字符串结束位置
        while(endl != -1)
        {
            endl = str.IndexOf("\r\n",begin);//查找换行字符，如果找到空返回-1,参数1：搜索字符按大小写区分，参数2：搜索位置从begin开始
            if(endl!=-1)//找到换行符
            {
                string lineStr = str.Substring(begin, endl - begin);//截取字符串，参数1：从begin位置开始，参数2：结束位置为endl-begin;
                //Debug.Log("第" + line + "行：" + lineStr);
                begin = endl + 2; //扣除\r\n换行符
                ProcessLine(line, lineStr);
                line++;
               
            }
        }
    }

    void ProcessLine(int line,string lineStr)//解析每一行
    {
        int lie = 0;
        int begin = 0;
        int end = 0;
        string lieStr;
        if (line >= 2)
        {
            ArrayList lineList = new ArrayList();//每行数据
            dataList.Add(lineList);
        }
        while (end != -1)
        {
            end = lineStr.IndexOf("\t", begin);  //查找切列字符
            
            if (end != -1)
            {
                lieStr = lineStr.Substring(begin, end - begin);
            }
            else
            {
                lieStr = lineStr.Substring(begin, lineStr.Length - begin);
            }
            ProcessLieData(line, lie, lieStr);
            begin = end + 1;
            //Debug.Log("第" + line + "行第" + lie + "列" + lieStr);
            lie++;
        }

    }

    void ProcessLieData(int line,int lie,string str)//解析每个数据
    {
        if (line == 0)
        {
            typeList.Add(str);
        }
        else if(line>=2)
        {
            ArrayList lineList = (ArrayList)dataList[line - 2];//获得每行数据数组
            string typeStr = (string)typeList[lie];
            if (typeStr == "INT")
            {
                lineList.Add(int.Parse(str));
            }else if (typeStr == "FLOAT")
            {
                lineList.Add(float.Parse(str));
            }else if (typeStr == "STRING")
            {
                lineList.Add(str);
            }
        }
    }
}

