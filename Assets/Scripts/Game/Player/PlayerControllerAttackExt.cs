using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController
{
    private void CheckAttack()
    {
        
        if (Input.GetButtonDown(GameGlobal.attackButton))
        {
            Attack();
        }

    }
    protected void Attack() 
    {
        unityArmature.animation.Play("Attack",1);//播放动画
    }

}
