using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainUI : MonoBehaviour
{
    public Image imgHPBar;
    private PlayerModel userData;

    private void Awake()
    {
        
        MsgCenter.Instance.SubscribeMessage("UpdateHPBar", UpdateHPBar);
        UpdateHPBar();
    }

    private void OnDestroy()
    {
        MsgCenter.Instance.RemoveMessage("UpdateHPBar");
    }

    //需要信号
    private void UpdateHPBar()
    {
        if (userData == null)
        {
            userData = GameMainController.Instance.playerModel;
        }

        imgHPBar.fillAmount = (float)userData.playerHP / userData.playerMaxHP;

        //imgHPBar.fillAmount = currentHP/MAXHP
    }
}
