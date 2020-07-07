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
    private Dictionary<string, GameObject> nodeDict = new Dictionary<string,GameObject>();
    private Dictionary<string, List<string>> childDict = new Dictionary<string, List<string>>();
    private Dictionary<string, int[]> posDict = new Dictionary<string, int[]>();
    public Dictionary<string, List<LineRenderer>> lineDict = new Dictionary<string, List<LineRenderer>>();

    
    public override void Init()
    {
        Debug.Log("InitMenuSkillManager");
        skillList = ((SkillUser)JsonController.Instance.GetJsonObj("skill")).Character01;
        SpawnItemSkill();
        
    }
    void SpawnItemSkill() 
    {
        
        for (int i = 0; i < skillList.Count; i++)
        {
            GameObject itemSkillUnit = Instantiate(itemSkillPrefab, skillContent);
            itemSkillUnit.GetComponent<MenuSkillItem>().Init(skillList[i],this);
            itemSkillUnit.transform.localPosition = new Vector2(skillList[i].Pos[0] * deltaIndex, skillList[i].Pos[1] * deltaIndex);
            nodeDict.Add(skillList[i].ID,itemSkillUnit);
            for (int j = 0; j < skillList[i].ParentID.Count; j++)
            {
                string parentKey = skillList[i].ParentID[j];
                string newChild = skillList[i].ID;
                SaveStringListInDict(childDict,parentKey,newChild);          
            }
            posDict.Add(skillList[i].ID,skillList[i].Pos);
            
        }
        SpawnItemLine();
    }
    void SpawnItemLine() 
    {
        List<string> val;
        Color lineColor1 = new Color(0, 205, 205);
        Color lineColor2 = Color.white;
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
                        string childID = childDict[skillList[i].ID][0];
                        
                        
                        Vector2 childPos = new Vector2(posDict[childID][0] * deltaIndex, posDict[childID][1] * deltaIndex);
                        LineRenderer line = DrawLine(parentPos, childPos, lineColor1, Color.white);
                        SaveLineListInDict(lineDict, childID, line);
                        break;
                    case 2:

                        string child1ID = childDict[skillList[i].ID][0];
                        string child2ID = childDict[skillList[i].ID][1];

                        Vector2 child1Pos = new Vector2(posDict[child1ID][0] * deltaIndex, posDict[child1ID][1] * deltaIndex);
                        Vector2 child2Pos = new Vector2(posDict[child2ID][0] * deltaIndex, posDict[child2ID][1] * deltaIndex);
                        Vector2 node = new Vector2((parentPos.x + child1Pos.x) / 2, parentPos.y);
                        Vector2 nodeToChild1 = new Vector2(node.x, child1Pos.y);
                        Vector2 nodeToChild2 = new Vector2(node.x, child2Pos.y);
                        LineRenderer line1 = DrawLine(parentPos, node, lineColor1, lineColor2);
                        LineRenderer line101 = DrawLine(node, nodeToChild1, lineColor2, lineColor1);
                        LineRenderer line201 = DrawLine(node, nodeToChild2, lineColor2, lineColor1);
                        LineRenderer line102 = DrawLine(new Vector2(node.x - 10, child1Pos.y), child1Pos, lineColor1, lineColor2);
                        LineRenderer line202 = DrawLine(new Vector2(node.x - 10, child2Pos.y), child2Pos, lineColor1, lineColor2);
                        SaveLineListInDict(lineDict,child1ID,line1);
                        SaveLineListInDict(lineDict, child1ID, line101);
                        SaveLineListInDict(lineDict, child1ID, line102);
                        SaveLineListInDict(lineDict, child2ID, line1);
                        SaveLineListInDict(lineDict, child2ID, line201);
                        SaveLineListInDict(lineDict, child2ID, line202);


                        break;
                }
            }

            
        }
    }
    public List<LineRenderer> GetLineBelongs(string ID) 
    {

        List<LineRenderer> val;
        if (lineDict.TryGetValue(ID, out val))
        {
            //如果指定的字典的键存在
            
            return lineDict[ID];
        }
        else 
        {
            return null;
        }
        
    }
    public GameObject GetNode(string ID) 
    {
        GameObject val;
        if (nodeDict.TryGetValue(ID, out val))
        {
            //如果指定的字典的键存在

            return nodeDict[ID];
        }
        else
        {
            return null;
        }
    }
    //两点画直线
    LineRenderer DrawLine(Vector2 startPoint, Vector2 endPoint,Color startColor,Color endColor) 
    {
        
        GameObject lineObj = Instantiate(itemSkillLinePrefab, lineContent);
        lineObj.transform.localPosition = new Vector2(0,0);
        //获得该物体上的LineRender组件  
        LineRenderer line = lineObj.GetComponent<LineRenderer>();
        //设置起始和结束的颜色  
        line.startColor = startColor;
        line.endColor = endColor;
        
        //设置起始和结束的宽度  
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;

        line.SetPosition(0, startPoint);
        line.SetPosition(1, endPoint);
        return line;
    }
    //封装string字典增加字段方法
    private void SaveStringListInDict(Dictionary<string, List<string>> stringDict, string dictKey, string newVal)
    {
        List<string> val;
        if (stringDict.TryGetValue(dictKey, out val))
        {
            //如果指定的字典的键存在
            List<string> tempChildList = new List<string>(stringDict[dictKey]);
            tempChildList.Add(newVal);
            stringDict[dictKey] = tempChildList;
        }
        else
        {
            List<string> tempChildList = new List<string>();
            tempChildList.Add(newVal);
            //不存在，则添加
            stringDict.Add(dictKey, tempChildList);
        }
    }
    private void SaveLineListInDict(Dictionary<string, List<LineRenderer>> lineDict, string dictKey, LineRenderer newVal)
    {
        List<LineRenderer> val;
        if (lineDict.TryGetValue(dictKey, out val))
        {
            //如果指定的字典的键存在
            List<LineRenderer> tempChildList = new List<LineRenderer>(lineDict[dictKey]);
            tempChildList.Add(newVal);
            lineDict[dictKey] = tempChildList;
        }
        else
        {
            List<LineRenderer> tempChildList = new List<LineRenderer>();
            tempChildList.Add(newVal);
            //不存在，则添加
            lineDict.Add(dictKey, tempChildList);
        }
    }
}
