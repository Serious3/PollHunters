using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayCredits : MonoBehaviour
{
    private TMP_Text creditText;
    private CustomizationManager cm;
    
    void Start()
    {
        creditText = GetComponent<TMP_Text>();
        cm = FindObjectOfType<CustomizationManager>();
    }

    void Update()
    {
        creditText.text = cm.currency.ToString();
    }
}
