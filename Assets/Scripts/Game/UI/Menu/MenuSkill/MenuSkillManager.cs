using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSkillManager : MenuChildManager
{
    private List<Skill> skillList;
    public GameObject itemSkillPrefab;
    public RectTransform skillContent;
    public override void Init()
    {
        Debug.Log("InitMenuSkillManager");
        skillList = ((SkillUser)JsonController.Instance.getJsonObj("skill")).Character01;
        spawnItemSkill();
    }
    void spawnItemSkill() 
    {            
        GameObject itemSkillUnit = Instantiate(itemSkillPrefab, skillContent);
        itemSkillUnit.transform.position = new Vector2(0,0);
        
       
    }

}
