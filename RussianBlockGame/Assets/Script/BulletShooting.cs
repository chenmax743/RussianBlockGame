using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BulletShooting : MonoBehaviour
{
    public float BulletSpeed=5f;
    public GameObject gProjectile;
    public Transform tFirePoint;

    public KeyCode kShootKey;

    private float fBulletDestroy=3.3f;

    
    void Update()
    {
        if(Input.GetKeyDown(kShootKey))
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
