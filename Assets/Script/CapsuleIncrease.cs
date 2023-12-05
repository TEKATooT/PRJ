using UnityEngine;

public class CapsuleIncrease : MonoBehaviour
{
    [SerializeField] float _increaseSpeed;
    [SerializeField] Vector3 _needSize;

    private void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, _needSize, _increaseSpeed * Time.deltaTime);
    }
}
