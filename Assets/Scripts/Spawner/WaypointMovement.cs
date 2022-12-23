using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _lengthOfPath;
    private float _locationOfPathOnCoordinateAxis;

    private void Start()
    {
        _lengthOfPath = 4f;
        _locationOfPathOnCoordinateAxis = 2f;
    }

    private void Update()
    {
        Vector3 newPosition = transform.position;

        newPosition.x = Mathf.PingPong(Time.time * _speed, _lengthOfPath) - _locationOfPathOnCoordinateAxis;

        transform.position = newPosition;
    }
}