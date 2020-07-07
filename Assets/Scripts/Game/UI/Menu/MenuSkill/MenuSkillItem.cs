using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuSkillItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image skillItemImg;
    public Image skillItemMask;
    private Skill skill;
    private MenuSkillManager menuSkillManager;
    private List<LineRenderer> lineBelongs = new List<LineRenderer>();
    public bool isActive = false;
    public void Init(Skill skillInit, MenuSkillManager father) 
    {
        skill = skillInit;
        
        menuSkillManager = father;
        LoadAssets();
        if (skill.ParentID[0] == "-1") isActive = true;
        
        skillItemMask.enabled = false;
    }
    void LoadAssets() 
    {
        string assetPath = "UI/Image/SkillIcon/";
        
        Sprite skillImg = Resources.Load<Sprite>(assetPath + skill.ID);
        if (skillImg) 
        {
            skillItemImg.sprite = skillImg;
        }
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        //当鼠标光标移入该对象时触发

        skillItemMask.enabled = true;
    }

    
    bool CheckParentActive()
    {
        List<string> parentList = skill.ParentID;
        for (int i = 0; i < parentList.Count; i++)
        {
            if (!menuSkillManager.GetNode(parentList[i]).GetComponent<MenuSkillItem>().isActive) return false;
        }
        return true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        skillItemMask.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        lineBelongs = menuSkillManager.GetLineBelongs(skill.ID);
        
        if (!isActive && lineBelongs != null && CheckParentActive())
        {
            for (int i = 0; i < lineBelongs.Count; i++)
            {
                isActive = true;
                lineBelongs[i].startColor = Color.blue;
                lineBelongs[i].endColor = Color.blue;
            }
            
        }
        else 
        {
            Debug.Log(CheckParentActive());
            return;
        }
    }
}
