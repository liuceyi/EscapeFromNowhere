using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using LitJson;

public class EnemyJson
{
    public object GetEnemyJson()
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/Resources/Data/Enemy.json");
        EnemyList skillObject = JsonMapper.ToObject<EnemyList>(jsonString);
        return skillObject;
    }
}
[Serializable]
public class Enemy
{
    public float HP;
    public float STR;
    public float AGI;
    public int[] Pos = new int[2];
}
[Serializable]
public class EnemyList
{
    public List<Enemy> Enemies;
}
