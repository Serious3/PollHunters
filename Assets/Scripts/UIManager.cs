using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject pauseMenu;
    public GameObject pollUI;

    public void ReturnToGame()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        inGameUI.SetActive(true);
    }

    public void ShowPoll(PollStop pollStop)
    {
        pollUI.SetActive(true);
        inGameUI.SetActive(false);
    }

    public void ShowOptions()
    {
        pauseMenu.SetActive(true);
        inGameUI.SetActive(false);
    }
}
