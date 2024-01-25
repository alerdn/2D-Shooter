using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class LevelSection : MonoBehaviour
{
    [field: SerializeField] public List<SpriteRenderer> SpriteRenderers { get; private set; } = new();
    [SerializeField] private List<LayerSetup> _layerSetups = new();

    public void LoadRenderers()
    {

        foreach (LayerSetup setup in _layerSetups)
        {
            SpriteRenderer[] renderers = setup.Parent.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer renderer in renderers)
            {
                renderer.sortingLayerID = setup.Layer;
                SpriteRenderers.Add(renderer);
            }
        }
    }
}

[Serializable]
public class LayerSetup
{
    public Transform Parent;
    [SortingLayerAttribute]
    public int Layer;


}