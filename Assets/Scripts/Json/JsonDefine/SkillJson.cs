using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SkillJson
{
    public object getSkillJson()
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/Resources/Data/Skill.json");
        SkillType skillObject = JsonUtility.FromJson<SkillType>(jsonString);
        Dictionary<string, List<Skill>> skillType = new Dictionary<string, List<Skill>>();
        List<Skill> Attack = new List<Skill>();
        List<Skill> Support = new List<Skill>();
        List<Skill> Movement = new List<Skill>();
        Debug.Log(skillObject.Attack[0].CD);
        Attack.AddRange(skillObject.Attack);
        Support.AddRange(skillObject.Support);
        Movement.AddRange(skillObject.Movement);
        //Type
        skillType.Add("Attack", Attack);
        skillType.Add("Support", Support);
        skillType.Add("Movement", Movement);
        
        return skillType;
    }
}
[Serializable]
public class Skill
{
    public string Name;
    public string Type;
    public float ATK;
    public float HP;
    public string Buff;
    public float Speed;
    public float Rate;
    public float Length;
    public float Duration;
    public float CD;

}

[Serializable]
public class SkillType
{
    public List<Skill> Attack;
    public List<Skill> Support;
    public List<Skill> Movement;
}
