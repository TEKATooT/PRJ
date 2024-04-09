using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    public void CubeSpawn()
    {
        Instantiate(_cube, transform.position, Quaternion.identity);
    }
}