using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class ColoredCube : MonoBehaviour
{
    private ObjectsPool _pool;
    private Renderer _renderer;

    private readonly float _minCubeLifeTime = 2;
    private readonly float _maxCubeLifeTime = 5;

    private bool _isColored = false;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        _pool = GetComponent<ObjectsPool>();
    }

    private void OnEnable()
    {
        _renderer.material.color = Color.white;

        _isColored = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Plane plane) && _isColored == false)
        {
            _renderer.material.color = plane.Color;

            _isColored = true;

            SetTimeRealease();
        }
    }

    private void SetTimeRealease()
    {
        float randomLifeTime = Random.Range(_minCubeLifeTime, _maxCubeLifeTime);

        StartCoroutine(Release(randomLifeTime));
    }

    private IEnumerator Release(float randomLifeTime)
    {
        WaitForSeconds seconds = new WaitForSeconds(randomLifeTime);

        yield return seconds;

        _pool.Release(this);
    }
}
