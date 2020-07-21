using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    protected Rigidbody2D thisBody = null;
    public float movingSpeed = 2.8f;
    public GameObject dragonBonesObj;
    private UnityArmatureComponent unityArmature;//UnityArmatureComponent对象
    private AnimState animState;
    private void Awake()
    {


        

        thisBody = this.GetComponent<Rigidbody2D>();
        //unityArmature = dragonBonesObj.GetComponent<UnityArmatureComponent>();//获得UnityArmatureComponent对象
        
    }
    private void Start()
    {
        animState = new AnimState(gameObject);
        IdleState idleState = new IdleState();
        animState.RegisterState(idleState);
        animState.SetDefaultState(idleState);
        animState.RegisterState(new RunState());
        animState.RegisterState(new AttackState());
        animState.SwitchState(PlayerState.Idle);//初始化进入待机状态
    }
    void Update()
    {
        if (animState != null)
        {
            animState.Update(Time.deltaTime);
        }
        if (animState.GetState() == PlayerState.Attack) 
        {
            return;
        }
        float horz = Input.GetAxis(GameGlobal.horzAxis);

        if (horz < 0f || horz > 0f)
        {

            animState.SwitchState(PlayerState.Run);

            //之后增加翻转角色功能的话就都right
            if (horz > 0f)
            {
                transform.localScale = new Vector2(1,1);
                transform.Translate(Vector2.right * movingSpeed * Time.deltaTime);
            }

            if (horz < 0f) 
            {
                transform.localScale = new Vector2(-1, 1);
                transform.Translate(Vector2.left * movingSpeed * Time.deltaTime);
            }
               
        }
        else {

            if (animState.GetState() == PlayerState.Run) { animState.StopState(); }


        }

        CheckJump();
        CheckFall();
        CheckAttack(); 
    }
    private void LateUpdate()
    {
        if (animState != null)
        {
            animState.LateUpdate(Time.deltaTime);
        }
    }
    private void CheckFall() 
    {
        if (transform.position.y < -7f) 
        {
            Debug.Log("fall off");
            transform.position = new Vector2(-6,0);
            //-hp
            PublicTool.changeAttribute(PlayerAttribute.HP, -1);
        }
    }


}
