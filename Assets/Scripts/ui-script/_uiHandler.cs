using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _uiHandler : MonoBehaviour
{


    [SerializeField] Canvas ingameUI;
    [SerializeField] Canvas Pause;
    [SerializeField] Canvas Inventory;

    [SerializeField] Button Continue;
    [SerializeField] Button Config;
    [SerializeField] Button Menu;

    private void Awake()
    {
        Pause.enabled = false;
        Inventory.enabled = false;
        ingameUI.enabled = true;
        Continue.onClick.AddListener(isPausedFalse);
        Menu.onClick.AddListener(StartMenu);
        
    }

    private void Update()
    {
        PauseInteract();
    }

    public void PauseInteract()
    {
        

        if(Input.GetKeyDown(KeyCode.Escape) &&  Pause.enabled != true)
        {
            isPausedTrue();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Pause.enabled != false)
        {
            isPausedFalse();
        }

        if (Input.GetKeyDown(KeyCode.Tab) && Pause.enabled != true && Inventory.enabled != true)
        {
            Inventory.enabled = true;
            IsPaused(true);
            ingameUI.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && Pause.enabled != true && Inventory.enabled != false)
        {
            Inventory.enabled = false;
            IsPaused(false);
            ingameUI.enabled = true;
        }

    }

    public void IsPaused(bool paused)
    {
        if(paused!)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    void isPausedTrue()
    {
        Pause.enabled = true;
        IsPaused(true);
        ingameUI.enabled = false;
    }
    void isPausedFalse()
    {
        IsPaused(false);
        Pause.enabled = false;
        ingameUI.enabled = true;
    }
    void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }


}
