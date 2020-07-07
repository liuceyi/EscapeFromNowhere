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
    private string skillName;

    public void Init(string name) 
    {
        skillName = name;
        LoadAssets();
        skillItemMask.enabled = false;
    }
    void LoadAssets() 
    {
        string assetPath = "UI/Image/SkillIcon/";
        
        Sprite skillImg = Resources.Load<Sprite>(assetPath + skillName);
        if (skillImg) 
        {
            skillItemImg.sprite = skillImg;
        }
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        //当鼠标光标移入该对象时触发
        Debug.Log("come in");
        skillItemMask.enabled = true;
    }

    
    void Update()
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("go out");
        skillItemMask.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
