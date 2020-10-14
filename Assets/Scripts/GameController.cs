using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Signals;
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
    private SignalBus _signalBus;

    private bool stopSignal;

    private void Start()
    {
        _uiController.HideGamePanel();
      
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

    public void OnPlayerWanSignal()
    {
        if(!stopSignal)
        {
            Debug.Log("Hi i am a Player signal");
            _timeController.SetPauseOn();
            stopSignal = true;
            OnGameEnd();
        }
    }
    
    public void OnEnemyWanSignal()
    {
        if (!stopSignal)
        {
            Debug.Log("Hi i am a Enemy signal");
            _timeController.SetPauseOn();
            stopSignal = true;
            OnGameEnd();
        }
    }

    private void OnGameEnd()
    {
        _uiController.ShowMenuPanel();
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
