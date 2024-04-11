using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private HingeJoint _joint;
    [SerializeField] private float _targetPosition;
    [SerializeField] private float _delayToRepating;

    private JointSpring _jointSpring;
    private float _delayToStart = 0;

    public void StartPump()
    {
        InvokeRepeating(nameof(Pump), _delayToStart, _delayToRepating);
    }

    private void Pump()
    {
        if (_jointSpring.targetPosition != _targetPosition)
        {
            ChangeTargetPosition(_targetPosition);
        }
        else
        {
            ChangeTargetPosition(-_targetPosition);
        }
    }

    private void ChangeTargetPosition(float targetPosition)
    {
        _jointSpring = _joint.spring;
        _jointSpring.targetPosition = targetPosition;
        _joint.spring = _jointSpring;
    }
}