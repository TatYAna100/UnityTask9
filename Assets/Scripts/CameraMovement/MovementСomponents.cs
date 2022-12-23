using UnityEngine;

public class MovementСomponents : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private FillingComponents _fillingComponents;

    private float _duration;
    private float _runningTime;
    private int _distanceMoving;
    private bool _isMove;
    private Vector3 _currentPosition;
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _fillingComponents.MovementChanged += OnMovementChanged;
    }

    private void OnDisable()
    {
        _fillingComponents.MovementChanged -= OnMovementChanged;
    }

    private void Start()
    {
        _runningTime = 1;
        _distanceMoving = 3;
        _rigidbody2D = GetComponent<Rigidbody2D>();

        ResetMarshmallowCat();
    }

    private void Update()
    {
        if(_isMove)
        {
            Move();
        }
    }

    public void ResetMarshmallowCat()
    {
        _currentPosition = transform.position;
    }

    private void OnMovementChanged()
    {
        _isMove = true;
    }

    private void Move()
    {
        if(_duration <= _runningTime)
        {
            _duration += Time.deltaTime;
            _rigidbody2D.MovePosition(Vector3.Lerp(_currentPosition, _target.position, _duration));
        }
        else
        {
            _currentPosition = transform.position;
            _target.position += Vector3.up * _distanceMoving;
            _isMove = false;
            _duration = 0;
        }
    }
}