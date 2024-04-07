using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Cube _cube;

    public void CubeSpawned()
    {
        Instantiate(_cube, transform.position, Quaternion.identity);
    }
}
