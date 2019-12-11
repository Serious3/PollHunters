using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class ColorCustomization
{
    public bool purchased;
    public Material material;
    public int cost;
}

public class CustomizationManager : MonoBehaviour
{
    public int currency = 3;
    
    public SkinnedMeshRenderer WorldModel;
    public SkinnedMeshRenderer PreviewModel;
    
    public Transform WorldHatLoc;
    public Transform PreviewHatLoc;

    public GameObject BuyPrompt;

    public List<ColorCustomization> colors;

    public int prevSkin;
    public GameObject veil;

    public void SetVeil(GameObject veil)
    {
        this.veil = veil;
    }
    
    public void SetColor(int colorIndex)
    {
        if (colors[colorIndex].purchased)
        {
            SetSkinColor(WorldModel, colors[colorIndex].material);
            SetSkinColor(PreviewModel, colors[colorIndex].material);
        }
        else
        {
            prevSkin = colorIndex;
            BuyPrompt.SetActive(true);
            SetSkinColor(PreviewModel, colors[colorIndex].material);
            StartCoroutine(StopPreview());
        }
    }

    private void SetSkinColor(SkinnedMeshRenderer smr, Material mat)
    {
        var currentlyAssignedMaterials = smr.materials;
 
        currentlyAssignedMaterials[3] = mat;
        smr.materials = currentlyAssignedMaterials;
    }
    
    public void BuySkin()
    {
        if (currency >= colors[prevSkin].cost)
        {
            currency -= colors[prevSkin].cost;
            colors[prevSkin].purchased = true;
            veil.SetActive(false);
            SetColor(prevSkin);
        }
    }
    
    private IEnumerator StopPreview()
    {
        yield return new WaitForSeconds(5);
        SetSkinColor(PreviewModel, WorldModel.materials[3]);
    }
}
