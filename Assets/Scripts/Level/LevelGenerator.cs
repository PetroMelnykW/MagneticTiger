using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const int StartZoneCount = 4;
    private const int ZoneAmountLimit = 6;

    [Header("Properties")]
    [SerializeField, Range(0f, 1f)]
    private float _badZoneSpawnRate = 0.2f;
    [SerializeField, Range(0f, 1f)]
    private float _bigZoneSpawnRate = 0.2f;
    [SerializeField, Range(0f, 1f)]
    private float _middleZoneSpawnRate = 0.6f;
    [SerializeField, Range(0f, 1f)]
    private float _smallZoneSpawnRate = 0.2f;

    [Header("Dependencies")]
    [SerializeReference]
    private LevelData _levelData;
    [SerializeReference]
    private Player _player;

    private List<Zone> _zones = new List<Zone>();
    private string _lastSize = "";

    private void Start()
    {
        while (_zones.Count < StartZoneCount) {
            SpawnNewZone(true);
        }
        _player.MovedToNextZone += OnPlayerMovedToNextZone;
    }

    private void SpawnNewZone(bool alwaysGood = false)
    {
        string goodness;
        if (alwaysGood) {
            goodness = "Good";
        }
        else {
            goodness = Random.Range(0f, 1f) <= _badZoneSpawnRate ? "Bad" : "Good";
        }
        
        float sizeRate = Random.Range(0f, 1f);
        string size;
        if (sizeRate <= _smallZoneSpawnRate)                                
            size = "Small";
        else if (sizeRate <= _smallZoneSpawnRate + _middleZoneSpawnRate)    
            size = "Middle";
        else                                                   
            size = "Big";

        //Create zone
        GameObject zoneObject = Instantiate(_levelData.GetZonePrefab(goodness, size));
        float yPos = _zones.Count == 0 ? 0 : 
            _zones[_zones.Count - 1].transform.position.y + _levelData.GetZoneLength(_lastSize) + _levelData.GetZoneLength(size) + 0.2f;
        
        zoneObject.transform.position = new Vector3(0, yPos, 0);

        _lastSize = size;

        Zone zone = zoneObject.GetComponent<Zone>();

        //Try create collectables objects 
        GameObject collectablesPrefab = _levelData.GetRandomCollectablesPrefab(goodness, size);
        if (collectablesPrefab != null) {
            GameObject collectables = Instantiate(collectablesPrefab);
            zone.SetCollectables(collectables);
        }

        _zones.Add(zone);
    }

    private void OnPlayerMovedToNextZone()
    {
        SpawnNewZone();
        
        if (_zones.Count > ZoneAmountLimit) {
            Zone zone = _zones[0];
            _zones.Remove(zone);
            Destroy(zone.gameObject);
        }
    }

    #region Editor
    private void OnValidate()
    {
        float total = _bigZoneSpawnRate + _middleZoneSpawnRate + _smallZoneSpawnRate;

        if (total != 1f) {
            float correctionFactor = 1f / total;
            _bigZoneSpawnRate *= correctionFactor;
            _middleZoneSpawnRate *= correctionFactor;
            _smallZoneSpawnRate *= correctionFactor;
        }
    }
    #endregion
}
