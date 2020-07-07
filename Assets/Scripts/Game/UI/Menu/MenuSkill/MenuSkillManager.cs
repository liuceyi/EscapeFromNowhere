using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSkillManager : MenuChildManager
{
    private List<Skill> skillList;
    public GameObject itemSkillPrefab;
    public GameObject itemSkillLinePrefab;
    public RectTransform skillContent;
    public RectTransform lineContent;
    private int deltaIndex = 100;
    private Dictionary<string, List<string>> childDict = new Dictionary<string, List<string>>();
    private Dictionary<string, int[]> posDict = new Dictionary<string, int[]>();
    List<string> val;
    public override void Init()
    {
        Debug.Log("InitMenuSkillManager");
        skillList = ((SkillUser)JsonController.Instance.getJsonObj("skill")).Character01;
        spawnItemSkill();
        
    }
    void spawnItemSkill() 
    {
        for (int i = 0; i < skillList.Count; i++)
        {
            GameObject itemSkillUnit = Instantiate(itemSkillPrefab, skillContent);
            itemSkillUnit.transform.localPosition = new Vector2(skillList[i].Pos[0] * deltaIndex, skillList[i].Pos[1] * deltaIndex);
            for (int j = 0; j < skillList[i].ParentID.Count; j++)
            {
                string parentKey = skillList[i].ParentID[j];
                string newChild = skillList[i].ID;
                if (childDict.TryGetValue(parentKey, out val))
                {
                    //如果指定的字典的键存在
                    List<string> tempChildList = new List<string>(childDict[parentKey]);
                    tempChildList.Add(newChild);
                    childDict[parentKey] = tempChildList;
                }
                else
                {
                    List<string> tempChildList = new List<string>();
                    tempChildList.Add(newChild);
                    //不存在，则添加
                    childDict.Add(parentKey, tempChildList);
                }
            }
            posDict.Add(skillList[i].ID,skillList[i].Pos);
            
        }
        spawnItemLine();
    }
    void spawnItemLine() 
    {
        for (int i = 0; i < skillList.Count; i++)
        {
            
            Vector2 parentPos = new Vector2(skillList[i].Pos[0] * deltaIndex, skillList[i].Pos[1] * deltaIndex);
            if (childDict.TryGetValue(skillList[i].ID, out val)) 
            {
                
                switch (childDict[skillList[i].ID].Count)
                {
                    case 0:
                        break;
                    case 1:
                        Debug.Log("here");
                        string childID = childDict[skillList[i].ID][0];

                        Vector2 childPos = new Vector2(posDict[childID][0] * deltaIndex, posDict[childID][1] * deltaIndex);
                        drawLine(parentPos, childPos);
                        break;
                    case 2:
                        string child1ID = childDict[skillList[i].ID][0];
                        break;
                }
            }

            
        }
    }
    void drawLine(Vector2 startPoint, Vector2 endPoint) 
    {
        GameObject lineObj = Instantiate(itemSkillLinePrefab, lineContent);
        lineObj.transform.localPosition = new Vector2(0,0);
        //获得该物体上的LineRender组件  
        LineRenderer line = lineObj.GetComponent<LineRenderer>();
        //设置起始和结束的颜色  
        line.startColor = Color.red;
        line.endColor = Color.blue;
        
        //设置起始和结束的宽度  
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;

        line.SetPosition(0, startPoint);
        line.SetPosition(1, endPoint);
    }
}
