using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PublicTool
{

    public static void ClearAllChildren(Transform tf)
    {
        foreach(Transform item in tf)
        {
            GameObject.Destroy(item.gameObject);
        }
    }
    public static void changeAttribute(PlayerAttribute attribute, int num)
    {
        switch (attribute)
        {
            case PlayerAttribute.HP:
                GameMainController.Instance.playerModel.playerHP += num;
                break;

        }

        MsgCenter.Instance.Publish("UpdateHPBar");
    }
}
