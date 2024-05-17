using UnityEngine;

public class Plane : MonoBehaviour
{
    private Color _color;

    public Color Color => _color;

    private void Awake()
    {
        _color = Random.ColorHSV();
    }
}
