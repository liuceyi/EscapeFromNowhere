using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoSingleton<BulletController>
{
    private Transform fireTransform;
    private GameObject bulletObj;
    private float bulletSpeed;
    private int bulletDamage;
    public void SpawnBullet(int bulletMode, int bulletNum, int wave, float waveWait, int damage, float speed, GameObject bulletPrefab,GameObject enemy,GameObject player)
    {
        //Vector3 playerPos = player.transform.position;
        bulletObj = bulletPrefab;
        fireTransform = enemy.transform;
        bulletSpeed = speed;
        Vector3 playerPos = new Vector3(0,0,0);
        
        switch (bulletMode)
        {
            case 0:

                StartCoroutine(FireInCircle(bulletNum, wave, waveWait)); 
                break;
            case 1:
                StartCoroutine(FireInSector(bulletNum, wave, waveWait));
                break;
        }
    }
    IEnumerator FireInCircle(int bulletNum,int wave,float waveWait) 
    {
        
        Vector3 fireDirection = fireTransform.up;
        Quaternion startQuaternion = Quaternion.AngleAxis(10,Vector3.forward);
        for (int i = 0; i < wave; i++)
        {
            for (int j = 0; j < bulletNum; j++)
            {
                GameObject bullet = Instantiate(bulletObj);
                bullet.GetComponent<EnemyBulletController>().Init(bulletDamage,bulletSpeed);
                bullet.transform.position = fireTransform.position;
                bullet.transform.rotation = Quaternion.Euler(fireDirection);
                fireDirection = startQuaternion * fireDirection;
            }
            yield return new WaitForSeconds(waveWait);
        }
        yield return null; 
    }
    IEnumerator FireInSector(int bulletNum, int wave, float waveWait)
    {
        Vector3 fireDirection = -fireTransform.up;

        Quaternion startQuaternion = Quaternion.AngleAxis(45, Vector3.forward);
        Quaternion endQuaternion = Quaternion.AngleAxis(-45, Vector3.forward);
        for (int i = 0; i < wave; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject bullet = Instantiate(bulletObj);
                bullet.GetComponent<EnemyBulletController>().Init(bulletDamage, bulletSpeed);
                bullet.transform.position = fireTransform.position;
                switch (j)
                {
                    case 0:
                        fireDirection = -fireTransform.up;
                        bullet.transform.rotation = Quaternion.Euler(fireDirection);
                        break;
                    case 1:
                        fireDirection = startQuaternion*fireDirection;
                        bullet.transform.rotation = Quaternion.Euler(fireDirection);
                        fireDirection = -fireTransform.up;
                        break;
                    case 2:
                        fireDirection = endQuaternion * fireDirection;
                        bullet.transform.rotation = Quaternion.Euler(fireDirection);
                        fireDirection = -fireTransform.up;
                        break;
                }

            }
            yield return new WaitForSeconds(waveWait);
        }
        yield return null;
    }
}
