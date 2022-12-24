using UnityEngine;
using UnityEngine.Events;

public class Filling : MonoBehaviour
{
    [SerializeField] private float _distanceLowPoint;

    public event UnityAction MovementChanged;

    private RaycastHit2D[] _hits;
    private int _numberOfCapacityComponents = 3;

    private void Update()
    {
        _hits = Physics2D.RaycastAll(transform.position, Vector3.up, _distanceLowPoint);

        if(_hits.Length <= _numberOfCapacityComponents)
        {
            return;
        }
        else
        {
            MovementChanged?.Invoke();
        }
    }
}