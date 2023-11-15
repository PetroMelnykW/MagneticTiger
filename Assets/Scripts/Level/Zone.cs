using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public List<Collectable> Collectables {
        get {
            _collectables.RemoveAll(item => item == null);
            return _collectables;
        }
        set => _collectables = value;
    }

    private List<Collectable> _collectables = new List<Collectable>();

    public void SetCollectables(GameObject collectablesParentPrefab)
    {
        foreach (Transform collectable in collectablesParentPrefab.transform) {
            _collectables.Add(collectable.GetComponent<Collectable>());
        }

        foreach (Collectable collectable in _collectables) {
            collectable.transform.SetParent(transform);
        }

        Destroy(collectablesParentPrefab);
    }
}
