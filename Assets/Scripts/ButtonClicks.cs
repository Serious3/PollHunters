using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonClicks : MonoBehaviour
{
    private string GUIName;
    
    public void SetGUIName(string GUIName)
    {
        this.GUIName = GUIName;
    }
    
    public void ShowGUI(bool visible)
    {
        transform.Find(GUIName).gameObject.SetActive(visible);
    }
}
