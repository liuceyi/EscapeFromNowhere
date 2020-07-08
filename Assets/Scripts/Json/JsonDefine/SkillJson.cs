using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using LitJson;

public class SkillJson
{
    public object GetSkillJson()
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/Resources/Data/Skill.json");
        SkillUser skillObject = JsonMapper.ToObject<SkillUser>(jsonString);
        return skillObject;
    }
}
[Serializable]
public class Skill
{
    public string ID;
    public string Name;
    public List<string> ParentID;
    public int[] Pos = new int[2];
    public string Info;
}

[Serializable]
public class SkillUser
{
    public List<Skill> Character01;
}
