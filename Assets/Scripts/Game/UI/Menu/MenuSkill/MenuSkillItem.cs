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
    public GameObject popOverPrefab;
    private GameObject popOver;
    private Skill skill;
    private MenuSkillManager menuSkillManager;
    private List<LineRenderer> lineBelongs = new List<LineRenderer>();
    public bool isActive = false;
    public void Init(Skill skillInit, MenuSkillManager father) 
    {
        skill = skillInit;
        
        menuSkillManager = father;
        LoadAssets();
        spawnPopOver();
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

    void spawnPopOver() 
    {
        popOver = Instantiate(popOverPrefab, transform);
        popOver.GetComponent<MenuSkillPopOver>().Init(skill.Name,skill.Info);
        popOver.transform.localPosition = new Vector2(60,130);
        popOver.SetActive(false);
    }
    
    bool CheckParentActive()
    {
        List<string> parentList = skill.ParentID;
        if (parentList[0] == "-1") { return true; }
            for (int i = 0; i < parentList.Count; i++)
        {
            
            if (!menuSkillManager.GetNode(parentList[i]).GetComponent<MenuSkillItem>().isActive) return false;
        }
        return true;
    }
    #region 鼠标事件
    public void OnPointerEnter(PointerEventData eventData)
    {
        //当鼠标光标移入该对象时触发

        skillItemMask.enabled = true;
        popOver.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        skillItemMask.enabled = false;
        popOver.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        lineBelongs = menuSkillManager.GetLineBelongs(skill.ID);
        
        if (!isActive && lineBelongs != null && CheckParentActive())
        {
            for (int i = 0; i < lineBelongs.Count; i++)
            {
                isActive = true;
                lineBelongs[i].startColor = new Color(132/255f,112/255f,255/255f);
                lineBelongs[i].endColor = new Color(72 / 255f, 61 / 255f, 139 / 255f);
            }
            
        }
        else 
        {
            Debug.Log(CheckParentActive());
            return;
        }
    }
    #endregion
}
