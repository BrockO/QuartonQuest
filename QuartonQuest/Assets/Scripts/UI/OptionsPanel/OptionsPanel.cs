﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsPanel : MonoBehaviour
{
    public static bool OptionsPanelShowing = false;
    public GameObject Panel;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OptionsPanelShowing)
            {
                ClosePanel();
            } 
            else
            {
                OpenPanel();
            }
        }
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Volume", volume);
    }

    // For opening and closing the panels, we might want to 
    // pause game time as well. 
    public void OpenPanel()
    {
        Debug.Log("Opening options panel");
        Panel.SetActive(true);
        // Time.timeScale = 0f;
        OptionsPanelShowing = true;
    }

    public void ClosePanel()
    {
        Debug.Log("Closing options panel");
        Panel.SetActive(false);
        // Time.timeScale = 1f;
        OptionsPanelShowing = false;
    }

    public void QuitMatch()
    {
        Debug.Log("Quitting match...");
        SceneManager.LoadScene("main_Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
