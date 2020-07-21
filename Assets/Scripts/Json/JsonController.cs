
public class JsonController : Singleton<JsonController>
{
    // Start is called before the first frame update

    public object GetJsonObj(string jsonTag) 
    {
        object jsonObj = null;
        switch (jsonTag)
        {
            case "enemy":
                EnemyJson enemyJson = new EnemyJson();
                jsonObj = enemyJson.GetEnemyJson(); 
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



