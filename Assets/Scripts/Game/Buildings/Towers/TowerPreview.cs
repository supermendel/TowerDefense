using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPreview : MonoBehaviour
{
    public Color unavaiableColor = Color.red;
    public Renderer[] childRenderers;
    public Color[] originalColors;
    void Start()
    {
        childRenderers = GetComponentsInChildren<Renderer>();

        originalColors = new Color[childRenderers.Length];

        for(int i = 0; i < childRenderers.Length; i++)
        {
            originalColors[i] = childRenderers[i].material.color;
        }

        Debug.Log($"{childRenderers.Length},{originalColors.Length}");
    }

    public void ChangeColorBad(Color color)
    {
        foreach(Renderer renderer in childRenderers)
        {
            if(renderer == null) continue;
            renderer.material.color = color;
        }
    }
    public void ReturnColor()
    {
        for(int i = 0;i < childRenderers.Length; i++)
        {
            if (childRenderers[i] == null) continue;
            childRenderers[i].material.color = originalColors[i];
        }
    }
}
