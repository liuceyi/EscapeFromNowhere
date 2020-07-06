using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStatusManager : MenuChildManager
{
    public Text codeMaxHP;
    public Text codeSTR;
    public Text codeDEF;
    public Text codeINT;

    private PlayerModel userdata;

    public override void Init()
    {
        Debug.Log("InitMenuStatusManager");
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (userdata == null)
        {
            userdata = GameMainController.Instance.playerModel;
        }

        codeMaxHP.text = userdata.playerMaxHP.ToString();
        codeSTR.text = userdata.playerSTR.ToString();
        codeDEF.text = userdata.playerDEF.ToString();
        codeINT.text = userdata.playerINT.ToString();
    }


}
