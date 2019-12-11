using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayUserInfo : MonoBehaviour
{
    public TextMeshProUGUI userIdDisplay;
    
    void Update()
    {
        userIdDisplay.text = Auth.Instance.user.DisplayName;
    }
}
