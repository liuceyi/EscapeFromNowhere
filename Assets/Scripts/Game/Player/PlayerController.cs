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
    private bool isRun = false;
    private bool isIdle = false;
    private void Awake()
    {
        thisBody = this.GetComponent<Rigidbody2D>();
        unityArmature = dragonBonesObj.GetComponent<UnityArmatureComponent>();//获得UnityArmatureComponent对象
        
    }

    void Update()
    {
        float horz = Input.GetAxis(GameGlobal.horzAxis);

        if (horz < 0f || horz > 0f)
        {
            isIdle = false;
            if (!isRun) 
            {
                isRun = true;
                unityArmature.animation.Play("Run");//播放动画
            }

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
            isRun = false;
            //unityArmature.animation.Stop("Run");//停止动画
            if (!isIdle) 
            {
                isIdle = true;
                unityArmature.animation.Play("Idle");//播放动画
            }
            
          
        }

            CheckJump();
    }
}
