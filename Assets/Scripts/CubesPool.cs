using UnityEngine;
using UnityEngine.Pool;

public class CubesPool : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private int _poolCapacity = 10;
    [SerializeField] private int _poolMaxSize = 20;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>
        (
            createFunc: CreateCube,
            actionOnGet: ActivateCube,
            actionOnRelease: DeactivateCube,
            actionOnDestroy: DestroyCube,
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }

    public void ReleaseCube(Cube cube)
    {
        cube.Release -= ReleaseCube;

        _pool.Release(cube);
    }

    public Cube GetCube()
    {
        return _pool.Get();
    }

    private Cube CreateCube()
    {
        return Instantiate(_cube);
    }

    private void ActivateCube(Cube cube)
    {
        cube.Release += ReleaseCube;

        cube.gameObject.SetActive(true);
    }

    private void DeactivateCube(Cube cube)
    {
        cube.gameObject.SetActive(false);
    }

    private void DestroyCube(Cube cube)
    {
        Destroy(cube);
    }
}
