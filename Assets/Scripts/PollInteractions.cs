using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollInteractions : MonoBehaviour
{
    public UIManager uiManager;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (Camera.main == null) return;
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out var hit, 1000, 1 << 9))
        {
            uiManager.ShowPoll(null);
            //hit.collider.gameObject
        }
    }
}
