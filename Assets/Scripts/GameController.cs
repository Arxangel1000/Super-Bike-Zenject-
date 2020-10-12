using System;
using UnityEditor;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public bool CanMove;
    [Inject]
    private TimeController _timeController;

    [Inject]
    private UnitPositionController _positionController;
    
    [Inject]
    private UIController _uiController;

    [Inject] 
    private GameObject _finishPrefab;

    [Inject]
    private GameConfig _gameConfig;

    [Inject]
    private OpponentController.OpponentFabrik _opponentFabrik;

    [Inject] 
    private PlayerController.PlayerFabrik _playerFabrik;

    [Inject]
    private PlayerWonSignal _playerWonSignal;

    [Inject]
    private OpponentWonSignal _opponentWonSignal;
    private void Start()
    {
        _uiController.HideGamePanel();
        _playerWonSignal.Subscribe<PlayerWonSignal>(EventMy);
        _opponentWonSignal.Subscribe<OpponentWonSignal>(EventOpponent);
        
    }

    public void EventMy(PlayerWonSignal signalData)
    {
        Debug.Log("Player signal!");
    }
    public void EventOpponent()
    {
        Debug.Log("Enemy signal!");
    }
    public void Play()
    {
        _uiController.HideMenuPanel();
        _uiController.ShowGamePanel();
        // создать игрока и противников
        CreateFinish();
        CreatePlayers();
        CreateOpponent();

        // создать финиш
    }
    
    public void CreateFinish()
    {
        GameObject.Instantiate(_finishPrefab, _gameConfig.finishPos, Quaternion.identity);
    }

    private void CreateOpponent()
    {
        for (int i = 0; i < _gameConfig.opponentsCount; i++)
        {
            var opponent = _opponentFabrik.Create(Random.Range(
                _gameConfig.OpponentMinSpeed, _gameConfig.OpponentMaxSpeed),
                _gameConfig.finishPos.y, this);

            opponent.transform.position = _positionController.GetNewPos();
        }
    }

    private void CreatePlayers()
    {
        var player = _playerFabrik.Create(
            _gameConfig.playerSpeed, _gameConfig.finishPos.y, this);
        
        player.transform.position = _positionController.GetNewPos();
    }

    public void Restart()
    {
        _uiController.ShowMenuPanel();
        _uiController.HideGamePanel();
    }
    
    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
           Application.Quit();
        #endif
    }
    
    
}
