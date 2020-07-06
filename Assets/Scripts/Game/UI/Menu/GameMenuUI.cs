using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameMenuUI : MonoBehaviour
{
    public GameObject objPopups;
    public RectTransform rtLine;

    public CanvasGroup canvasGroupIcon;
    public List<ItemMenuIcon> listIcon;
    public List<GameObject> listContent;
    public RectTransform rtContent;

    private int beHavorIndex = 0;
    private int beSelectedIndex = 0;

    private Sequence seq;

    #region 基本的显示与隐藏

    private void Awake()
    {
        seq = DOTween.Sequence();

        Tween t1 = rtLine.DOScaleY(1, 0.5f);
        Tween t2 = rtLine.GetComponent<Image>().DOFade(1, 0.5f);
        Tween t3 = canvasGroupIcon.DOFade(1, 0.5f);

        seq.Append(t1);
        seq.Join(t2);
        seq.Join(t3);
        seq.SetAutoKill(false);
        seq.Pause();
    }


    private void ShowPopups()
    {
        //动效初始化
        rtLine.localScale = Vector2.right;
        rtLine.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        canvasGroupIcon.alpha = 0;

        objPopups.SetActive(true);
        seq.Restart();
        UpdateHavorUI();
        SelectedIcon();
        
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

        if (Input.GetButtonDown(GameGlobal.vertAxis))
        {
            float vert = Input.GetAxis(GameGlobal.vertAxis);
            if (vert > 0)
            {
                LastIcon();
            }
            else if(vert < 0)
            {
                NextIcon();
            }
            UpdateHavorUI();
        }

        if (Input.GetButtonDown(GameGlobal.yes))
        {
            SelectedIcon();
        }

    }

    #endregion

    #region Icon相关

    public void LastIcon()
    {
        if(beHavorIndex > 0)
        {
            beHavorIndex--;
        }
    }

    public void NextIcon()
    {
        if(beHavorIndex < listIcon.Count - 1)
        {
            beHavorIndex++;
        }
    }

    public void UpdateHavorUI()
    {
        for(int i = 0;i < listIcon.Count; i++)
        {
            if(i == beHavorIndex)
            {
                listIcon[i].BeHavor();
            }
            else
            {
                listIcon[i].UnHavor();
            }
        }
    }

    public void SelectedIcon()
    {
        listIcon[beSelectedIndex].UnSelect();
        //rtContent.
        PublicTool.ClearAllChildren(rtContent);

        beSelectedIndex = beHavorIndex;

        listIcon[beHavorIndex].BeSelect();
        if (beSelectedIndex < listContent.Count && listContent[beSelectedIndex] != null)
        {
            GameObject obj = GameObject.Instantiate(listContent[beSelectedIndex], rtContent);
        }
    }

    #endregion
}
