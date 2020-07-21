using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MsgCenter : Singleton<MsgCenter>
{

    private Dictionary<string, Delegate> dicMsg = new Dictionary<string, Delegate>();


    public void Init()
    {
        dicMsg.Clear();
    }
    public void ClearMessage() 
    {
        dicMsg.Clear();
    }
    //注册事件
    public void SubscribeMessage(string str, Action call)
    {

        if (dicMsg.ContainsKey(str))
        {
            dicMsg[str] = call;
        }
        else
        {
            dicMsg.Add(str, call);
        }
    }
    //带参
    public void SubscribeMessage<T>(string str, Action<T> call)
    {
        if (dicMsg.ContainsKey(str))
        {
            dicMsg[str] = call;
        }
        else
        {
            dicMsg.Add(str, call);
        }
    }


    public void RemoveMessage(string str)
    {
        if (dicMsg.ContainsKey(str))
        {
            dicMsg.Remove(str);
        }
    }
    //调起事件
    public void Publish(string str)
    {

        if (dicMsg.ContainsKey(str))
        {
            Action func = (Action)dicMsg[str];
            func();

        }

    }
    //带参
    public void Publish<T>(string str, T args)
    {


        if (dicMsg.ContainsKey(str))
        {
            Action<T> func = (Action<T>)dicMsg[str];
            func(args);

        }

    }
}
