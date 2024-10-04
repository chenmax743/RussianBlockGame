using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScence : MonoBehaviour
{
    public string TargetScence;
    public Button ScenceButton;

    void Start()
    {
        ScenceButton.onClick.AddListener(JumpToScence);
    }

    
    void JumpToScence()
    {
        SceneManager.LoadScene(TargetScence);
    }
}
