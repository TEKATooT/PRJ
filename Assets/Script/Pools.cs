using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Events;
using System.Collections;

public class Pools : MonoBehaviour
{
    [SerializeField] private ColoredCube _coloredCube;
    [SerializeField] private Bomb _bomb;
    private ObjectPool<ColoredCube> _cubePool;
    private ObjectPool<Bomb> _bombsPool;

    private int _minPoolSize = 50;
    private int _maxPoolSize = 100;

    private readonly float _minCubeLifeTime = 2;
    private readonly float _maxCubeLifeTime = 5;

    public event UnityAction CubeCreated;
    public event UnityAction<Transform> TurnedOff;
    public event UnityAction BombCreated;

    public float CountCubesActive => _cubePool.CountActive;
    public float CountBombsActive => _bombsPool.CountActive;

    private void Awake()
    {
        _cubePool = CreatePool(_coloredCube);
        _bombsPool = CreatePool(_bomb);
    }

    public ObjectPool<T> CreatePool<T>(T prefab) where T : MonoBehaviour
    {
        return new ObjectPool<T>(() =>
        {
            return Instantiate(prefab);
        }, pollObject =>
        {
            pollObject.gameObject.SetActive(true);
        }, pollObject =>
        {
            pollObject.gameObject.SetActive(false);
        }, pollObject =>
        {
            Destroy(pollObject.gameObject);
        }, false, _minPoolSize, _maxPoolSize);
    }

    public ColoredCube GetCube()
    {
        var newColoredCube = _cubePool.Get();

        CubeCreated.Invoke();

        StartCoroutine(Release(newColoredCube));

        return newColoredCube;
    }

    public Bomb GetBomb()
    {
        Bomb newBomb = _bombsPool.Get();

        BombCreated.Invoke();

        StartCoroutine(Release(newBomb));

        return newBomb;
    }

    public IEnumerator Release(ColoredCube coloredCube)
    {
        float randomlifeTime = Random.Range(_minCubeLifeTime, _maxCubeLifeTime);

        yield return new WaitForSeconds(randomlifeTime);

        _cubePool.Release(coloredCube);

        TurnedOff.Invoke(coloredCube.transform);
    }

    public IEnumerator Release(Bomb newBomb)
    {
        float randomlifeTime = Random.Range(_minCubeLifeTime, _maxCubeLifeTime);

        yield return new WaitForSeconds(randomlifeTime);

        _bombsPool.Release(newBomb);
    }
}
