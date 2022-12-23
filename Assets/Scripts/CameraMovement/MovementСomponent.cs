using UnityEngine;

public class MovementСomponent : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private DetectСomponent _detectСomponent;

    private float _duration;
    private int _distanceX;
    private int _distanceY;
    private int _distanceZ;
    private bool _isMove;
    private Vector3 _currentPosition;
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _detectСomponent.MovementChanged += StartMove;
    }

    private void OnDisable()
    {
        _detectСomponent.MovementChanged -= StartMove;
    }

    private void Start()
    {
        _distanceX = 0;
        _distanceY = 3;
        _distanceZ = 0;
        _rigidbody2D = GetComponent<Rigidbody2D>();

        ResetMarshmallowCat();
    }

    private void Update()
    {
        if(_isMove)
        {
            Movement();
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

    private void Movement()
    {
        if(_duration <= 1)
        {
            _duration += Time.deltaTime;
            _rigidbody2D.MovePosition(Vector3.Lerp(_currentPosition, _target.position, _duration));
        }
        else
        {
            _currentPosition = transform.position;
            _target.position += new Vector3(_distanceX, _distanceY, _distanceZ);
            _isMove = false;
            _duration = 0;
        }
    }
}