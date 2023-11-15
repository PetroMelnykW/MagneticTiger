using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public List<Collectable> Collectables => _collectables;

    private List<Collectable> _collectables = new List<Collectable>();

    public void SetCollectables(GameObject collectablesParentPrefab)
    {
        foreach (GameObject collectable in collectablesParentPrefab.transform) {
            collectable.transform.SetParent(transform);
            _collectables.Add(collectable.GetComponent<Collectable>());
        }
        Destroy(collectablesParentPrefab);
    }
}
