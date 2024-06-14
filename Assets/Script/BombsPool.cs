using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Events;
using System.Collections;

public class BombsPool : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;

    private ObjectPool<Bomb> _bombsPool;

    private int _minPoolSize = 50;
    private int _maxPoolSize = 100;

    private readonly float _minCubeLifeTime = 2;
    private readonly float _maxCubeLifeTime = 5;

    public event UnityAction Created;

    public float CountActive => _bombsPool.CountActive;
    public float CountAll => _bombsPool.CountAll;

    private void Awake()
    {
        _bombsPool = new ObjectPool<Bomb>(() =>
        {
            return Instantiate(_bomb);
        }, _bomb =>
        {
            _bomb.gameObject.SetActive(true);
        }, _bomb =>
        {
            _bomb.gameObject.SetActive(false);
        }, _bomb =>
        {
            Destroy(_bomb.gameObject);
        }, false, _minPoolSize, _maxPoolSize);
    }

    public Bomb Get()
    {
        Bomb newBomb = _bombsPool.Get();

        Created.Invoke();

        StartCoroutine(Release(newBomb));

        return newBomb;
    }

    public IEnumerator Release(Bomb newBomb)
    {
        float randomlifeTime = Random.Range(_minCubeLifeTime, _maxCubeLifeTime);

        yield return new WaitForSeconds(randomlifeTime);

        _bombsPool.Release(newBomb);
    }
}
