using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _menuPanel;
    
    [Inject]
    private GameController _gameController;

    [Inject] private TimeController _timeController;
    #if UNITY_EDITOR
    private void OnValidate()
    {
        _menuPanel = transform.Find("MenuPanel").gameObject;
        _gamePanel = transform.Find("GamePanel").gameObject;
    }
    #endif

    private void Start()
    {
        Debug.Log(_gameController); 
        _timeController.SetPauseOff();
    }

    public void ShowGamePanel() { _gamePanel.SetActive(true); }

    public void HideGamePanel() { _gamePanel.SetActive(false); }
    
    public void ShowMenuPanel() { _menuPanel.SetActive(true); }

    public void HideMenuPanel() { _menuPanel.SetActive(false); }

    public void OnExitButtonClicked()
    {
        _gameController.Exit();
    }
    
    public void OnPlayButtonClicked()
    {
        _gameController.Play();
    }
    
    public void OnRestartButtonClicked()
    {
        _gameController.Restart();
    }
}
