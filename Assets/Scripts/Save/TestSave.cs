using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSave : MonoBehaviour
{
    // Start is called before the first frame update
    public void testGameSave()
    {
        Debug.Log(GameMainController.Instance.playerModel.playerHP);
        PlayerSave.Instance.gameSave();
    }
}
