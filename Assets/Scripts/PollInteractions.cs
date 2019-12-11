using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.MeshGeneration.Components;
using UnityEngine;

public class PollInteractions : MonoBehaviour
{
    public UIManager uiManager;
    public Material countedMaterial;
    public CustomizationManager cm;
    
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (Camera.main == null) return;
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out var hit, 1000, 1 << 9))
        {
            //var pollInfo = hit.transform.GetComponentInParent<FeatureBehaviour>();
            //var pollName = (string) pollInfo.VectorEntity.Feature.Properties["Name"];
            //print("Showing " + pollName);
            //uiManager.ShowPoll(pollName);
            //hit.collider.gameObject

            var animator = hit.transform.GetComponent<Animator>();
            var meshRenderer = hit.transform.GetComponentInChildren<SkinnedMeshRenderer>();
            if (!animator) return;
            
            animator.SetTrigger("Wave");
            
            if (!meshRenderer) return;
            if (meshRenderer.material.color == countedMaterial.color) return;
            
            meshRenderer.material = countedMaterial;
            cm.currency += 1;
        }
    }
}
