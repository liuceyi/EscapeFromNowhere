using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainUI : MonoBehaviour
{
    public Image imgHPBar;
    private PlayerModel userdata;


    //需要信号
    private void UpdateHPBar()
    {
        if (userdata == null)
        {
            userdata = GameMainController.Instance.playerModel;
        }

        imgHPBar.fillAmount = (float)userdata.playerHP / userdata.playerMaxHP;

        //imgHPBar.fillAmount = currentHP/MAXHP
    }
}
