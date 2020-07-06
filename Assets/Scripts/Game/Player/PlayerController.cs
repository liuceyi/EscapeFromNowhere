using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    protected Rigidbody2D thisBody = null;
    public float movingSpeed = 2.8f;
    
    private void Awake()
    {
        thisBody = this.GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        float horz = Input.GetAxis(GameGlobal.horzAxis);

        if (horz < 0f || horz > 0f)
        {
            //之后增加翻转角色功能的话就都right
            if (horz > 0f)
                this.transform.Translate(Vector2.right * movingSpeed * Time.deltaTime);
            if (horz < 0f)
                this.transform.Translate(Vector2.left * movingSpeed * Time.deltaTime);
        }

        CheckJump();
    }
}
