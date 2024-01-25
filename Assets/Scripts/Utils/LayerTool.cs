using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class LayerTool : MonoBehaviour
{
    [field: SerializeField] public LevelSection LevelSection { get; private set; }

    [Button]
    private void SortLayers()
    {
        LevelSection.LoadRenderers();
        
        for (int i = 0; i < LevelSection.SpriteRenderers.Count; i++)
        {
            SpriteRenderer renderer = LevelSection.SpriteRenderers[i];
            renderer.sortingOrder = i;
        }
    }
}
