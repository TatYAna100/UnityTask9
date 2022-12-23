using UnityEngine;
using UnityEngine.Events;

public class DetectСomponent : MonoBehaviour
{
    [SerializeField] private float _distanceLowPoint;

    public event UnityAction MovementChanged;

    private RaycastHit2D[] _hits;

    private void Update()
    {
        _hits = Physics2D.RaycastAll(transform.position, Vector3.up, _distanceLowPoint);

        if(_hits.Length <= 3)
        {
            return;
        }
        else
        {
            MovementChanged?.Invoke();
        }
    }
}