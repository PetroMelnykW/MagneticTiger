using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/LevelData", fileName = "LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeReference]
    private GameObject _badBigZonePrefab;
    [SerializeReference]
    private GameObject _badMiddleZonePrefab;
    [SerializeReference]
    private GameObject _badSmallZonePrefab;
    [SerializeReference]
    private GameObject _goodBigZonePrefab;
    [SerializeReference]
    private GameObject _goodMiddleZonePrefab;
    [SerializeReference]
    private GameObject _goodSmallZonePrefab;

    [Space(10)]
    [SerializeField]
    private float _bigZoneLength;
    [SerializeField]
    private float _middleZoneLength;
    [SerializeField]
    private float _smallZoneLength;

    [Space(10)]
    [SerializeField]
    private List<GameObject> _badBigZoneCollectablesPrefabs;
    [SerializeField]
    private List<GameObject> _badMiddleZoneCollectablesPrefabs;
    [SerializeField]
    private List<GameObject> _badSmallZoneCollectablesPrefabs;
    [SerializeField]
    private List<GameObject> _goodBigZoneCollectablesPrefabs;
    [SerializeField]
    private List<GameObject> _goodMiddleZoneCollectablesPrefabs;
    [SerializeField]
    private List<GameObject> _goodSmallZoneCollectablesPrefabs;

    public float GetZoneLength(string size)
    {
        switch (size) {
            case "Small":   return _smallZoneLength;
            case "Middle":  return _middleZoneLength;
            case "Big":     return _bigZoneLength;
        }
        return 0;
    }

    public GameObject GetZonePrefab(string godness, string size)
    {
        switch (godness) {
            case "Good":
                switch (size) {
                    case "Small":   return _goodSmallZonePrefab;
                    case "Middle":  return _goodMiddleZonePrefab;
                    case "Big":     return _goodBigZonePrefab;
                }
                break;
            case "Bad":
                switch (size) {
                    case "Small":   return _badSmallZonePrefab;
                    case "Middle":  return _badMiddleZonePrefab;
                    case "Big":     return _badBigZonePrefab;
                }
                break;
        }
        return null;
    }

    public GameObject GetRandomCollectablesPrefab(string godness, string size)
    {
        List<GameObject> zoneCollectablesPrefabsList = null;
        switch (godness) {
            case "Good":
                switch (size) {
                    case "Small":   zoneCollectablesPrefabsList = _goodSmallZoneCollectablesPrefabs;    break;
                    case "Middle":  zoneCollectablesPrefabsList = _goodMiddleZoneCollectablesPrefabs;   break;
                    case "Big":     zoneCollectablesPrefabsList = _goodBigZoneCollectablesPrefabs;      break;
                } break;
            case "Bad":
                switch (size) {
                    case "Small":   zoneCollectablesPrefabsList = _badSmallZoneCollectablesPrefabs;     break;
                    case "Middle":  zoneCollectablesPrefabsList = _badMiddleZoneCollectablesPrefabs;    break;
                    case "Big":     zoneCollectablesPrefabsList = _badBigZoneCollectablesPrefabs;       break;
                }
                break;
        }

        if (zoneCollectablesPrefabsList.Count > 0) {
            return zoneCollectablesPrefabsList[Random.Range(0, zoneCollectablesPrefabsList.Count)];
        }
        return null;
    }
}
