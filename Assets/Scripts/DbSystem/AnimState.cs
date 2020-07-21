using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Macros;

public interface IState
{
    AnimState animState { get; set; } //所属的状态机

    PlayerState playerState { get; }  // 状态类型

    void EnterState(); //状态进入

    void StateUpdate(float deltaTime); //状态更新

    void StateLateUpdate(float deltaTime);

    void ExitState(); //状态退出
}

public class AnimState 
{
    private Dictionary<PlayerState, IState> stateDic;
    private IState currentState;
    private IState defaultState;
    private GameObject _role;  //关联对象
    public GameObject role
    {
        get 
        {
            return _role; 
        }
    }

    public AnimState(GameObject target)
    {
        
        _role = target;
        
        stateDic = new Dictionary<PlayerState, IState>();

    }
    //注册状态
    public void RegisterState(IState state)
    {
        IState s;
        stateDic.TryGetValue(state.playerState, out s);
        if (s == null)
        {
            state.animState = this;
            stateDic.Add(state.playerState, state);
        }
        else
        {
            Debug.Log(state.playerState + " Already Registered");
        }

    }
    //设置默认状态
    public void SetDefaultState(IState state) 
    {
        defaultState = state;
    }
    //注销状态
    public void RemoveState(PlayerState playerState)
    {
        if (currentState.playerState != playerState)
        {
            IState s;
            stateDic.TryGetValue(playerState, out s);
            if (s != null)
            {
                stateDic.Remove(playerState);
            }
            else
            {
                Debug.Log(playerState + " Doesnt Exist");
            }
        }
        else
        {
            Debug.Log(playerState + "Is Running, Action Failed");
        }

    }
    //切换状态
    public void SwitchState(PlayerState playerState)
    {
        IState s;
        stateDic.TryGetValue(playerState, out s);
        if (s != null)
        {
            if (currentState != null) 
            {
                if (currentState == s)
                {
                    return;
                }
                else 
                {
                    currentState.ExitState();//退出之前的状态
                }
                
            }
                

            s.EnterState(); //进入状态
            currentState = s;//变更当前状态
        }
        else
        {
            Debug.Log(playerState + "Is Unregistered");
        }
    }
    //停止当前状态
    public void StopState() 
    {
        if (currentState != null)
        {
            currentState.ExitState();
            currentState = null;
        }
    }
    //获取当前状态
    public PlayerState GetState() 
    {
        
        if (currentState != null) 
        {
            return currentState.playerState;
        }
        return PlayerState.Idle;
    }
    public void Update(float deltaTime)
    {
        if (currentState != null)
        {
            currentState.StateUpdate(deltaTime);
        }
        else if(defaultState != null) 
        {
            defaultState.EnterState();
            currentState = defaultState;
        }
    }

    public void LateUpdate(float deltaTime)
    {
        if (currentState != null)
        {
            currentState.StateLateUpdate(deltaTime);
        }
    }


}