using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameMenuUI : MonoBehaviour
{
    public GameObject objPopups;

    public RectTransform rtLine;

    private Sequence seq;

    private void Awake()
    {
        seq = DOTween.Sequence();

        Tween t1 = rtLine.DOScaleY(1, 1f);
        Tween t2 = rtLine.GetComponent<Image>().DOFade(1, 1f);

        seq.Append(t1);
        seq.Join(t2);
        seq.SetAutoKill(false);
        seq.Pause();
    }


    private void ShowPopups()
    {
        rtLine.localScale = Vector2.right;
        rtLine.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        objPopups.SetActive(true);
        seq.Restart();
        
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
