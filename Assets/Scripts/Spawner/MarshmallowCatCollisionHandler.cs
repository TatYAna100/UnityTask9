using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MarshmallowCat))]
[RequireComponent(typeof(Animator))]
public class MarshmallowCatCollisionHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;

    private const string _collision = "Collision";
    private MarshmallowCat _marshmallowCat;
    private Animator _animator;

    private void Start()
    {
        _marshmallowCat = GetComponent<MarshmallowCat>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZone scoreZone))
        {
            _reached?.Invoke();
            scoreZone.Increase();
            _animator.SetTrigger(_collision);
        }
        else if (collision.TryGetComponent(out GameOverZone gameOverZone))
        {
            gameOverZone.Fell();
        }
    }
}
