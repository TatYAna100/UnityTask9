using UnityEngine;

public class MovementСomponents : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Detect _detect;

    private float _duration;
    private int _distanceMoving;
    private bool _isMove;
    private Vector3 _currentPosition;
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _detect.MovementChanged += StartMove;
    }

    private void OnDisable()
    {
        _detect.MovementChanged -= StartMove;
    }

    private void Start()
    {
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
        else
        {
            return;
        }
    }

    public void ResetMarshmallowCat()
    {
        _currentPosition = transform.position;
    }

    private void StartMove()
    {
        _isMove = true;
    }

    private void Move()
    {
        if(_duration <= 1)
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