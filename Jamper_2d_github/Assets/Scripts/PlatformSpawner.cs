using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private float _verticalOffset = 0.5f;

  

    [Header("complexity")]
    [SerializeField] private float _baseSpeed = 1.5f;                 // initial speed
    [SerializeField] private float _speedIncreaseStep = 0.2f;         // how much to increase
    [SerializeField] private int _platformsPerStep = 150;             // platform per step
    [SerializeField] private float _maxSpeed = 4f;                    // limit

    private float? _lastPointPositionY = null;
    private int _platformCount = 0;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        float spawnPointPositionY = _lastPointPositionY == null ? randomSpawnPoint.position.y : (float)_lastPointPositionY + _verticalOffset;

        randomSpawnPoint.position = new Vector3(randomSpawnPoint.position.x, spawnPointPositionY, randomSpawnPoint.position.z);
        _lastPointPositionY = spawnPointPositionY;

        GameObject newPlatform = Instantiate(_platformPrefab, randomSpawnPoint.position, Quaternion.identity);
        _platformCount++;

 
        float newSpeed = _baseSpeed + (_platformCount / _platformsPerStep) * _speedIncreaseStep;
        newSpeed = Mathf.Min(newSpeed, _maxSpeed);

      
        Platform platformScript = newPlatform.GetComponent<Platform>();
        if (platformScript != null)
        {
            platformScript.SetMoveSpeed(newSpeed);
        }

     
 
    }
}






