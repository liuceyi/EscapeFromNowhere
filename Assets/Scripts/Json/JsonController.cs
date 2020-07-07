﻿
public class JsonController : Singleton<JsonController>
{
    // Start is called before the first frame update

    public object GetJsonObj(string jsonTag) 
    {
        object jsonObj = null;
        switch (jsonTag)
        {
            case "monster":
                MonsterJson monsterJson = new MonsterJson();
                jsonObj = monsterJson.getMonsterJson(); 
                break;
            case "skill":
                SkillJson skillJson = new SkillJson();
                jsonObj = skillJson.GetSkillJson();
                break;
            case "buff":
                BuffJson buffJson = new BuffJson();
                jsonObj = buffJson.getBuffJson();
                break;
        }
        return jsonObj;
    }
    
}



