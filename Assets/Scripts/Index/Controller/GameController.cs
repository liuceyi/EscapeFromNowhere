using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private string _playerNickname;
    public string playerNickname 
    {
        get 
        {
            return _playerNickname;
        }

        set 
        {
            _playerNickname = value;
        }
    }
    private int _playerXp;
    public int playerXp
    {
        get
        {
            return  _playerXp;
;
        }
        set
        {
            _playerXp = value;
        }
    }
    private int _playerMoney;
    public int playerMoney
    { 
        get 
        {
            return _playerMoney;
        }
        set 
        {
            _playerMoney = value;
        } 
    }
    private int _wave;
    public int wave
    {
        get
        {
            return _wave;
        }
        set
        {
            _wave = value;
        }
    }
    public int targetWave;

    public string[] skillList = {"Giant Saw" };
    public GameController()
    {
        playerNickname = "sakuyo";
        playerXp = 0;
        playerMoney = 100;
        wave = 0;
    }


    public static GameController _gameController;
    public static GameController gameController
    {
        get 
        {
            if (_gameController == null)
            {
                _gameController = FindObjectOfType(typeof(GameController)) as GameController;
            }
            return _gameController;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
        PlayerSave.Instance.gameRead();//读档
    }

}
