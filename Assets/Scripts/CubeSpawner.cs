using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private float _repeatRate = 0.5f;
    [SerializeField] private float _spawnAreaSize = 5f;

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (currentObject) => ActionOnGet(currentObject));         
    }

    private void ActionOnGet(GameObject currentObject)
    {
        currentObject.transform.position = _startPoint.transform.position + new Vector3(Random.Range(-_spawnAreaSize, _spawnAreaSize + 1),0, Random.Range(-_spawnAreaSize, _spawnAreaSize + 1));
        currentObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        currentObject.SetActive(true);
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetCube), 0.0f, _repeatRate);
    }

    private void GetCube()
    {
        _pool.Get();
    }
}
