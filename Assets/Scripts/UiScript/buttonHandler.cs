using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonHandler : MonoBehaviour
{

    [SerializeField] Button Start;
    [SerializeField] Button Config;
    [SerializeField] Button Leave;


    private void Awake()
    {
        Start.onClick.AddListener(onClickStart);
        Leave.onClick.AddListener(onClickLeave);

    }
    void onClickStart()
    {
        SceneManager.LoadScene("Apartameto");
        
    }
    void onClickLeave()
    {
        Application.Quit();
        Debug.Log("pressed");
    }

}
