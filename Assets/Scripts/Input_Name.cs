using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Input_Name : MonoBehaviour
{
    public InputField field;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputText();
    }
    public void InputText()
    {
        string text;

        text = field.text;
        if(text == "Jeff" && Input.GetKey(KeyCode.KeypadEnter)|| text == "jeff" && Input.GetKey(KeyCode.KeypadEnter) 
            || text == "JEFF" && Input.GetKey(KeyCode.KeypadEnter))
        {
            
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Jeff");
        }

    }
}
