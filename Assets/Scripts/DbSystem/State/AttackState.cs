using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class AttackState : IState
{

    private UnityArmatureComponent unityArmature;//UnityArmatureComponent对象
    public AnimState animState
    {
        get; set;
    }

    public PlayerState playerState
    {
        get { return PlayerState.Attack; }
    }

    public void EnterState()
    {
        unityArmature = animState.role.GetComponentInChildren<UnityArmatureComponent>();//获得UnityArmatureComponent对象
        unityArmature.animation.Play("Attack",1);//播放动画
    }

    public void ExitState()
    {

    }

    public void StateLateUpdate(float deltaTime)
    {

    }

    public void StateUpdate(float deltaTime)
    {
        if (unityArmature.animation.GetState("Attack").isCompleted)
        {
            animState.StopState();
        }
    }

}
