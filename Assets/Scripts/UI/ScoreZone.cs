using UnityEngine;
using UnityEngine.Events;

public class ScoreZone : MonoBehaviour 
{
    private int _score;

    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        ResetPlayer();
    }

    public void Increase()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 1;
    }
}