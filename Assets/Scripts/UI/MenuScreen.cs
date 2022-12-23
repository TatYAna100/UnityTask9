using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class MenuScreen : MonoBehaviour
{
    [SerializeField] private Button _playButtom;
    [SerializeField] private Button _exitButtom;

    private CanvasGroup _menuGroup;

    private void OnEnable()
    {
        _playButtom.onClick.AddListener(OnPlayButtonClick);
        _exitButtom.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _playButtom.onClick.RemoveListener(OnPlayButtonClick);
        _exitButtom.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _menuGroup = GetComponent<CanvasGroup>();
        _menuGroup.alpha = 1;
    }

    private void OnPlayButtonClick()
    {
        _menuGroup.alpha = 0;
        Time.timeScale = 1;
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}