using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class EnemyController : MonoBehaviour
{
    protected Rigidbody2D thisBody = null;
    public float movingSpeed = 2.8f;
    public GameObject dragonBonesObj;
    private UnityArmatureComponent unityArmature;//UnityArmatureComponent对象

    public GameObject bulletPrefab;

    //敌人状态
    public const int STATE_STAND = 0;//站立
    public const int STATE_WALK = 1;//行走
    public const int STATE_RUN = 2;//奔跑

    //记录敌人的当前状态
    private int enemyState;

    //主角对象
    private GameObject player;
    //备份上一次的敌人思考时间
    private float backUptime;
    //敌人思考下一次行为的时间
    public const int AI_THINK_TIME = 2;
    //敌人的巡逻范围
    public const int AI_ATTACK_DISTANCE = 10;
    
    private void Awake()
    {
        thisBody = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("TestPlayer");
        //unityArmature = dragonBonesObj.GetComponent<UnityArmatureComponent>();//获得UnityArmatureComponent对象

    }
    public void Init(GameObject playerObj)  
    {
        //得到主角对象
        player = playerObj;
        //设置敌人的默认状态站立
        enemyState = STATE_STAND;
    }
    void Update()
    {
        //CheckAI();
        if (Input.GetKeyDown(KeyCode.T))
        {
            EnemyAttack(); 
        }

        
        
    }
    void EnemyAttack() 
    {
        //定时？判定？
        Debug.Log(BulletController.Instance);
        //发射子弹
        BulletController.Instance.SpawnBullet(0,6,3,0.5f,1,100,bulletPrefab,gameObject,player);
    }

    void CheckAI()
    {
        //判断敌人与主角的距离
        if (Vector3.Distance(transform.position, player.transform.position) <
        (AI_ATTACK_DISTANCE))
        {
            //敌人进入奔跑状态
            unityArmature.animation.Play("Run");
            enemyState = STATE_RUN;
            //设计敌人面朝主角方向
            transform.LookAt(player.transform);
        }
        //敌人进入巡逻状态
        else
        {
            //计算敌人的思考时间
            if (Time.time - backUptime >= AI_THINK_TIME)
            {
                //敌人开始思考
                backUptime = Time.time;

                //取得0~2之间的随机数
                int rand = Random.Range(0, 2);

                if (rand == 0)
                {
                    //敌人进入站立状态
                    unityArmature.animation.Play("Idle");
                    enemyState = STATE_STAND;
                }

                else if (rand == 1)
                {
                    //敌人进入站立状态
                    //敌人随机旋转角度
                    Quaternion rotate = Quaternion.Euler(0, Random.Range(1, 5) * 90, 0);
                    //1秒内完成敌人旋转
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * 1000);
                    //播放行走动画    
                    unityArmature.animation.Play("Walk");
                    enemyState = STATE_WALK;
                }
            }
        }
        switch (enemyState)
        {
            case STATE_STAND:
                break;
            case STATE_WALK:
                //敌人行走
                transform.Translate(Vector3.forward * Time.deltaTime);
                break;
            case STATE_RUN:
                //敌人朝向主角奔跑
                if (Vector3.Distance(transform.position, player.transform.position) > 3)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * 3);
                }
                break;

        }
    }
}
