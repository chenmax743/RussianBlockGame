using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fExploteRadius = 3f;
    public LayerMask lObjectlayer;

    private void Explode()
    {
        Collider2D[] cObjectRange = Physics2D.OverlapCircleAll(transform.position, fExploteRadius, lObjectlayer);

        int iDestroyCount = 0;
        foreach (Collider2D cCollider in cObjectRange)
        {
            if (iDestroyCount < 3)
            {
                Destroy(cCollider.gameObject);
                iDestroyCount++;
            }
            else
            {
                break;
            }
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Explode();
    }

}   
    
