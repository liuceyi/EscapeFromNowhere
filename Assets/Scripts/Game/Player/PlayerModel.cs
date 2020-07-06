using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerModel
{
    public string playerName;
    public int playerMaxHP;
    public int playerHP;
    public int playerSTR;
    public int playerDEF;
    public int playerINT;
    public List<string> playerSkillList;
    public Vector2 playerPosition;
    public PlayerModel()
    {
        playerName = "Sakuyo";
        playerMaxHP = 100;
        playerHP = 100;
        playerSTR = 10;
        playerDEF = 10;
        playerINT = 10;
        playerSkillList = new List<string>();
        playerSkillList.Add("1001");
        playerPosition = new Vector2(0,0);
    }

}

