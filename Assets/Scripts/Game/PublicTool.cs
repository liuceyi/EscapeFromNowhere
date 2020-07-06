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

}
