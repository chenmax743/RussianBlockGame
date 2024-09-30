using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public List<GameObject> LPlayerLife;
    public GameManager GameManager;
    
    public void RemoveImage() //§R°£¹Ï¤ù
    {
        if(LPlayerLife.Count>0)
        {
            GameObject gImageMove = LPlayerLife[LPlayerLife.Count - 1];

            if(gImageMove != null ) 
            {
                gImageMove.SetActive(false);
            }

            LPlayerLife.RemoveAt(LPlayerLife.Count - 1);
        }

        if(LPlayerLife.Count ==0 && GameManager!=null)
        {
            GameManager.ShowMessage();
        }

    }
}
