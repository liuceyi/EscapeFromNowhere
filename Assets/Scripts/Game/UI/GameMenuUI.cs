using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameMenuUI : MonoBehaviour
{
    public GameObject objPopups;

    public RectTransform rtLine;




    private void ShowPopups()
    {
        rtLine.localScale = Vector2.right;
        objPopups.SetActive(true);
        rtLine.DOScaleY(1, 1f);
    }

    private void HidePopups()
    {
        objPopups.SetActive(false);
    }
    //esc

    //暂用 后有MainManager之后 把这个改成信号相关的
    private void Update()
    {
        if (Input.GetButtonDown(GameGlobal.esc))
        {
            if (objPopups.activeSelf)
            {
                HidePopups();
            }
            else
            {
                ShowPopups();
            }
        }
    }
}
