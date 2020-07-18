using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private int damage = 1;
    private float speed = 100;
    // Start is called before the first frame update
    public void Init(int bulletDamage, float bulletSpeed)
    {
        damage = bulletDamage;
        speed = bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bulletDirection = new Vector2(transform.rotation.x, transform.rotation.y);
        transform.Translate(bulletDirection * speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player") 
        {
            Debug.Log("hit");
        }
    }
}
