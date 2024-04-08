using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _timeToDestroy = 15;

    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}