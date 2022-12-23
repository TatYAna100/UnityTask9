using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _menuButtom;
    [SerializeField] private Button _exitButtom;
    [SerializeField] private GameOverZone _gameOverZone;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _gameOverZone.GameOver += OnGameOver;
        _menuButtom.onClick.AddListener(OnMenuButtonClick);
        _exitButtom.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _gameOverZone.GameOver -= OnGameOver;
        _menuButtom.onClick.RemoveListener(OnMenuButtonClick);
        _exitButtom.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    private void OnGameOver()
    {
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void  OnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}