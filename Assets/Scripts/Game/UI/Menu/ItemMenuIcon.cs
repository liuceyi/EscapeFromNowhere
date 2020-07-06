using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemMenuIcon : MonoBehaviour
{
    public Image imgIcon;
    public Image imgHalo;
    public Color colorYellow;
    public Color colorWhite = new Color(1,1,1,0.6f);
    private Sequence seq;

    private void Awake()
    {
        seq = DOTween.Sequence();

        Tween t1 = imgHalo.DOFillAmount(1, 0.5f);

        seq.Append(t1);
        seq.SetAutoKill(false);
        seq.Pause();
    }

    public void BeHavor()
    {
        imgIcon.color = colorYellow;
        imgHalo.color = colorYellow;
    }

    public void UnHavor()
    {
        imgIcon.color = colorWhite;
        imgHalo.color = colorWhite;
    }

    public void BeSelect()
    {
        imgHalo.fillAmount = 0;
        seq.Restart();
    }

    public void UnSelect()
    {
        imgHalo.fillAmount = 0;
    }

}
