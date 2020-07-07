using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameMainController : MonoSingleton<GameMainController>
{
    public PlayerModel playerModel;

    // Start is called before the first frame update
    private void Awake()
    {
        playerModel = new PlayerModel();
        playerModel = PlayerSave.Instance.playerModel;
        DontDestroyOnLoad(this);
        PlayerSave.Instance.GameRead();//读档
    }
}
