using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _joint;
    [SerializeField] private float _springPower;

    public void Launch()
    {
        _joint.spring = _springPower;
    }

    public void Reload()
    {
        _joint.spring = 0;
    }
}