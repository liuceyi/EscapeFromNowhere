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
        //List<string> val;
        Color lineColor1 = new Color(0, 205, 205);
        Color lineColor2 = Color.white;
        for (int i = 0; i < skillList.Count; i++)
        {
            for (int j = 0; j < skillList[i].ParentID.Count; j++)
            {
                List<string> parentID = skillList[i].ParentID;
                if (parentID[0] == "-1") {
                    //根节点
                }
                else 
                {
                    string childID = skillList[i].ID;
                    Vector2 childPos = new Vector2(posDict[childID][0] * deltaIndex, posDict[childID][1] * deltaIndex);
                    Vector2 parentPos = new Vector2(posDict[parentID[j]][0] * deltaIndex, posDict[parentID[j]][1] * deltaIndex); 
                    Vector2 node1 = new Vector2((parentPos.x + childPos.x) / 2, childPos.y);
                    Vector2 node2 = new Vector2((parentPos.x + childPos.x) / 2, parentPos.y);
                    LineRenderer point1 = DrawPoint(node1, lineColor2);
                    LineRenderer point2 = DrawPoint(node2, lineColor1);
                    LineRenderer Line1 = DrawLine(childPos, node1, lineColor1, lineColor2);
                    LineRenderer Line2 = DrawLine(node1, node2, lineColor2, lineColor1);
                    LineRenderer Line3 = DrawLine(node2, parentPos, lineColor1, lineColor2);
                    SaveLineListInDict(lineDict, childID, Line1);
                    SaveLineListInDict(lineDict, childID, Line2);
                    SaveLineListInDict(lineDict, childID, Line3);
                    SaveLineListInDict(lineDict, childID, point1);
                    SaveLineListInDict(lineDict, childID, point2);
                }
            }
            
                //Vector2 parentPos = new Vector2(skillList[i].Pos[0] * deltaIndex, skillList[i].Pos[1] * deltaIndex);
                //if (childDict.TryGetValue(skillList[i].ID, out val)) //检索子节点数量
                //{
                
                //    switch (childDict[skillList[i].ID].Count)
                //    {
                //        case 0:
                //            //末端节点
                //            break;
                //        case 1:
                //        //单向节点
                //        string childID = childDict[skillList[i].ID][0];
                //        Vector2 childPos = new Vector2(posDict[childID][0] * deltaIndex, posDict[childID][1] * deltaIndex);
                //        Debug.Log(skillList[i].ID);
                //        if (skillList[i].ParentID.Count == 2) //存在多个父节点，子节点只有一个
                //        {
                //            Debug.Log("here");
                //            string parent1ID = skillList[i].ParentID[0];
                //            string parent2ID = skillList[i].ParentID[1];
                //            Vector2 parent1Pos = new Vector2(posDict[parent1ID][0] * deltaIndex, posDict[parent1ID][1] * deltaIndex); 
                //            Vector2 parent2Pos = new Vector2(posDict[parent2ID][0] * deltaIndex, posDict[parent2ID][1] * deltaIndex);
                //            if (parent1Pos.x > parent2Pos.x) 
                //            {
                //                Vector2 node2Parents = new Vector2((parent1Pos.x + childPos.x) / 2,childPos.y);
                //                Vector2 nodeToParent1 = new Vector2(node2Parents.x,parent1Pos.y);
                //                Vector2 nodeToParent2 = new Vector2(node2Parents.x,parent2Pos.y);
                //                LineRenderer parentLine1 = DrawLine(childPos, node2Parents, lineColor1, lineColor2);
                //                LineRenderer parentPoint1 = DrawPoint(node2Parents, lineColor1);
                //                LineRenderer parentLine101 = DrawLine(node2Parents, nodeToParent1, lineColor1, lineColor2);
                //                LineRenderer parentPoint101 = DrawPoint(nodeToParent1, lineColor1);
                //                LineRenderer parentLine102 = DrawLine(nodeToParent1, parent1Pos, lineColor1, lineColor2);
                //                LineRenderer parentLine201 = DrawLine(node2Parents, nodeToParent2, lineColor1, lineColor2);
                //                LineRenderer parentPoint201 = DrawPoint(nodeToParent2, lineColor1);
                //                LineRenderer parentLine202 = DrawLine(nodeToParent2, parent2Pos, lineColor1, lineColor2);
                //                SaveLineListInDict(lineDict, childID, parentLine1);
                //                SaveLineListInDict(lineDict, childID, parentPoint1);
                //                SaveLineListInDict(lineDict, childID, parentLine101);
                //                SaveLineListInDict(lineDict, childID, parentPoint101);
                //                SaveLineListInDict(lineDict, childID, parentLine102);
                //                SaveLineListInDict(lineDict, childID, parentLine201);
                //                SaveLineListInDict(lineDict, childID, parentPoint201);
                //                SaveLineListInDict(lineDict, childID, parentLine202);
                //            }
                //        }
                //        else 
                //        {
                            
                //            LineRenderer line = DrawLine(parentPos, childPos, lineColor1, Color.white);
                //            SaveLineListInDict(lineDict, childID, line);
                //        }
                        
                //            break;
                //        case 2:
                        
                //            string child1ID = childDict[skillList[i].ID][0];
                //            string child2ID = childDict[skillList[i].ID][1];

                //            Vector2 child1Pos = new Vector2(posDict[child1ID][0] * deltaIndex, posDict[child1ID][1] * deltaIndex);
                //            Vector2 child2Pos = new Vector2(posDict[child2ID][0] * deltaIndex, posDict[child2ID][1] * deltaIndex);
                //            Vector2 node = new Vector2((parentPos.x + child1Pos.x) / 2, parentPos.y);
                //            Vector2 nodeToChild1 = new Vector2(node.x, child1Pos.y);
                //            Vector2 nodeToChild2 = new Vector2(node.x, child2Pos.y);
                //            LineRenderer line1 = DrawLine(parentPos, node, lineColor1, lineColor2);//根节点发出的短直线
                //            LineRenderer point1 = DrawPoint(node, lineColor1);//根节点和其他直线的交汇处
                //            LineRenderer line101 = DrawLine(node, nodeToChild1, lineColor2, lineColor1);//交汇处向第一个子节点发出的直线
                //            LineRenderer point101 = DrawPoint(nodeToChild1, lineColor1);//通往子节点直线的拐弯点
                //            LineRenderer line102 = DrawLine(nodeToChild1, child1Pos, lineColor1, lineColor2);//拐弯处到子节点的直线
                //            LineRenderer line201 = DrawLine(node, nodeToChild2, lineColor2, lineColor1);//交汇处向第二个子节点发出的直线
                //            LineRenderer point201 = DrawPoint(nodeToChild2, lineColor1);//通往子节点直线的拐弯点
                //            LineRenderer line202 = DrawLine(nodeToChild2, child2Pos, lineColor1, lineColor2);//拐弯处到子节点的直线

                //            SaveLineListInDict(lineDict,child1ID,line1);
                //            SaveLineListInDict(lineDict, child1ID, point1);
                //            SaveLineListInDict(lineDict, child1ID, line101);
                //            SaveLineListInDict(lineDict, child1ID, point101);
                //            SaveLineListInDict(lineDict, child1ID, line102);
                //            SaveLineListInDict(lineDict, child2ID, line1);
                //            SaveLineListInDict(lineDict, child2ID, point1);
                //            SaveLineListInDict(lineDict, child2ID, line201);
                //            SaveLineListInDict(lineDict, child2ID, point201);
                //            SaveLineListInDict(lineDict, child2ID, line202);


                //            break;
                //    }
                //}
            


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
    private LineRenderer DrawPoint(Vector2 point, Color Color) 
    {
        Vector2 startPoint = new Vector2(point.x - 10, point.y);
        Vector2 endPoint = new Vector2(point.x + 10, point.y);
        LineRenderer pointOfLine = DrawLine(startPoint,endPoint, Color, Color);
        return pointOfLine;
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
