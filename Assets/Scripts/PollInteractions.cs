using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.MeshGeneration.Components;
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
            var pollInfo = hit.transform.GetComponentInParent<FeatureBehaviour>();
            var pollName = (string) pollInfo.VectorEntity.Feature.Properties["Name"];
            print("Showing " + pollName);
            uiManager.ShowPoll(pollName);
            //hit.collider.gameObject
        }
    }
}
