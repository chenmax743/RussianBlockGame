using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) //ª«¥ó¸I¼²¨¤¦â
    {
        if (collider.CompareTag("Player"))
        {
            //Debug.Log("touch");
            PlayerLife cPlayer = collider.GetComponent<PlayerLife>();

            if (cPlayer != null)
            {
                cPlayer.RemoveImage();
            }

            Destroy(gameObject);
        }

        if(collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if(collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        
    }
}
