using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    public float BulletSpeed=5f;
    public GameObject gProjectile;
    public Transform tFirePoint;

    private float fBulletDestroy=5f;

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            BulletShoot();
        }
        
    }

    void BulletShoot()
    {
        GameObject Bullet =  Instantiate(gProjectile,tFirePoint.position,Quaternion.identity);

        Rigidbody2D rb= Bullet.GetComponent<Rigidbody2D>();
        rb.velocity = tFirePoint.right*BulletSpeed;

        Destroy(Bullet,fBulletDestroy);
    }
}
