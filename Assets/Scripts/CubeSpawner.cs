using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubesPool _cubesPool;
    [SerializeField] private float _valueAxis = 8f;
    [SerializeField] private float _yValue = 10f;

    private float _spawnInterval = 0.5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCube), 0.0f, _spawnInterval);
    }

    private void SpawnCube()
    {
        Cube cube = _cubesPool.GetCube();

        cube.transform.position = DetermineSpawnPoints();
    }

    private Vector3 DetermineSpawnPoints()
    {
        return new Vector3(Random.Range(-_valueAxis, _valueAxis + 1), _yValue, Random.Range(-_valueAxis, _valueAxis + 1));
    }
}
