using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class IdleState : IState
{

    private UnityArmatureComponent unityArmature;//UnityArmatureComponent对象
    public AnimState animState
    {
        get; set;
    }

    public PlayerState playerState
    {
        get { return PlayerState.Idle; }
    }

    public void EnterState()
    {
        unityArmature = animState.role.GetComponentInChildren<UnityArmatureComponent>();//获得UnityArmatureComponent对象
        unityArmature.animation.Play("Idle");//播放动画
    }

    public void ExitState()
    {
        unityArmature.animation.Stop("Idle");//停止动画
    }

    public void StateLateUpdate(float deltaTime)
    {

    }

    public void StateUpdate(float deltaTime)
    {

    }

}
