using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonClicks : MonoBehaviour
{
    public GameObject MenuIMG;
    public GameObject SettingsIMG;
    public GameObject MenuBTN;
    void Start()
    {
        MenuIMG.SetActive(false);
        SettingsIMG.SetActive(false);
        MenuBTN.SetActive(true);
    }
    public void Main_Menu_BTN()
    {
        MenuIMG.SetActive(true);
        SettingsIMG.SetActive(false);
        MenuBTN.SetActive(false);
    }
    public void quitGame()
    {
        MenuIMG.SetActive(false);
        SettingsIMG.SetActive(false);
        MenuBTN.SetActive(true);
        Application.Quit();
    }
    public void MenuClose()
    {
        MenuIMG.SetActive(false);
        SettingsIMG.SetActive(false);
        MenuBTN.SetActive(true);
    }
    public void Settings()
    {
        SettingsIMG.SetActive(true);
        MenuIMG.SetActive(true);
    }
    public void RTNGame()
    {
        MenuIMG.SetActive(false);
        SettingsIMG.SetActive(false);
        MenuBTN.SetActive(true);
    }
    public void LoginClick()
    {
        SceneManager.LoadScene(0);
    }
}
