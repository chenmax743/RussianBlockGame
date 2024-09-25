using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text tUIText;
    private float fDuration;

    private void Start()
    {
        tUIText.gameObject.SetActive(false);
    }

    public void ShowMessage()
    {
        
        tUIText.gameObject.SetActive(true);

    }
}
