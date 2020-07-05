using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class BuffJson
{
    public object getBuffJson()
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/Resources/Data/Buff.json");
        BuffType buffObject = JsonUtility.FromJson<BuffType>(jsonString);
        Dictionary<string, List<BuffUnit>> buffType = new Dictionary<string, List<BuffUnit>>();
        List<BuffUnit> buff = new List<BuffUnit>();
        List<BuffUnit> debuff = new List<BuffUnit>();


        //Type
        buffType.Add("buff", buff);
        buffType.Add("debuff", debuff);
        return buffType;
    }
}
[Serializable]
public class BuffUnit
{
    public string Name;
    public string Type;
    public float HP;
    public float Rate;
    public float Duration;

}
[Serializable]
public class Buff
{
    public List<BuffUnit> buff;
}
//[Serializable]
//public class SupportSkill
//{
//    public string Name;
//    public string Type;
//    public float HP;
//    public string Buff;
//    public float Duration;
//    public float CD;

//}
[Serializable]
public class Debuff
{

    public List<BuffUnit> debuff;
}
//[Serializable]
//public class MovementSkill
//{
//    public string Name;
//    public string Type;
//    public float Rate;
//    public float Duration;
//    public float Length;
//    public float CD;

//}

[Serializable]
public class BuffType
{
    public Buff buff;
    public Debuff debuff;
}
