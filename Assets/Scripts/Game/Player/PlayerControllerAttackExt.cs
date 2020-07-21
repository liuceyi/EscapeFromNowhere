using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController
{
    
    private void CheckAttack()
    {
        
        if (Input.GetButtonDown(GameGlobal.attackButton))
        {
            animState.SwitchState(PlayerState.Attack);
        }

    }


}
