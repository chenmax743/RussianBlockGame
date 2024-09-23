using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) //����I������
    {
        if (collider.CompareTag("Player"))
        {
            //Debug.Log("touch");
            PlayerLife cPlayer = collider.GetComponent<PlayerLife>();

            if (cPlayer != null)
            {
                cPlayer.RemoveImage();
            }
        }
    }
}
