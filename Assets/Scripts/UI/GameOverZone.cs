using UnityEngine;
using UnityEngine.Events;

public class GameOverZone : MonoBehaviour
{
    public event UnityAction GameOver;

    public void Fell()
    {
        GameOver?.Invoke();
    }
}