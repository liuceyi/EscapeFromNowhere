using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameMainController : MonoSingleton<GameMainController>
{
    public PlayerModel playerModel;
    public GameObject enemyPrefab;
    public GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        playerModel = new PlayerModel();
        playerModel = PlayerSave.Instance.playerModel;
        DontDestroyOnLoad(this);
        PlayerSave.Instance.GameRead();//读档
        SpawnEnemy();
    }
    private void SpawnEnemy() 
    {
        //读取敌人分布数据
        //List<Enemy> enemyList = ((EnemyList)JsonController.Instance.GetJsonObj("enemy")).Enemies;
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector2(5, 0);
            enemy.GetComponent<EnemyController>().Init(player);
        }
    }
}
