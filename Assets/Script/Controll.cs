using UnityEngine;

public class Controll : MonoBehaviour
{
    [SerializeField] Swing _swing;
    [SerializeField] Catapult _catapult;
    [SerializeField] Spawner _spawner;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _swing.StartPump();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _catapult.Launch();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _catapult.Reload();
            _spawner.CubeSpawned();
        }
    }
}
