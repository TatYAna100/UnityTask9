using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Filling _filling;

    private float _duration;
    private float _runningTime;
    private int _distanceMoving;
    private bool _isMove;
    private Vector3 _currentPosition;
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _filling.MovementChanged += OnMovementChanged;
    }

    private void OnDisable()
    {
        _filling.MovementChanged -= OnMovementChanged;
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
        StartCoroutine(Move());
    }

    public void ResetMarshmallowCat()
    {
        _currentPosition = transform.position;
    }

    private void OnMovementChanged()
    {
        _isMove = true;
    }

    private IEnumerator Move()
    {
        var waitForSeconds = new WaitForSeconds(_runningTime);

        while (_isMove)
        {
            if (_duration <= _runningTime)
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

            yield return waitForSeconds;
        }
    }
}