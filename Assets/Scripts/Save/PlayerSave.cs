using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : Singleton<PlayerSave>
{
    // Start is called before the first frame update


    // Update is called once per frame
    public void gameSave()
    {
        PlayerPrefs.SetInt("player_money", GameController.gameController.playerMoney);
        PlayerPrefs.SetInt("player_xp", GameController.gameController.playerXp);
        PlayerPrefs.SetInt("player_wave", GameController.gameController.wave);

        PlayerPrefs.Save();
    }
    public void gameRead()
    {
        if (PlayerPrefs.HasKey("player_money"))//存档读取的一般方式
            GameController.gameController.playerMoney = PlayerPrefs.GetInt("player_money");
        if (PlayerPrefs.HasKey("player_xp"))
            GameController.gameController.playerXp = PlayerPrefs.GetInt("player_xp");
        if (PlayerPrefs.HasKey("player_wave"))
            GameController.gameController.wave = PlayerPrefs.GetInt("player_wave");

    }
}
