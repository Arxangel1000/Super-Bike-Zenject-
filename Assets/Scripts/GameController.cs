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

    public GameObject _player;
    public GameObject[] _opponents;

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
        _positionController.Reset();
        CreatePlayers();
        CreateOpponent();
        _timeController.SetPauseOff();
        stopSignal = false;
        // создать финиш
    }

    public void OnPlayerWanSignal()
    {
        if(!stopSignal)
        {
            Debug.Log("Player is win");
            _timeController.SetPauseOn();
            stopSignal = true;
            OnGameEnd();
        }
    }
    
    public void OnEnemyWanSignal()
    {
        if (!stopSignal)
        {
            Debug.Log("Enemy is win");
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
        if (_opponents.Length == 0)
        {
            _opponents = new GameObject[_gameConfig.opponentsCount];
            for (int i = 0; i < _gameConfig.opponentsCount; i++)
            {
                _opponents[i] = _opponentFabrik.Create(Random.Range(
                        _gameConfig.OpponentMinSpeed, _gameConfig.OpponentMaxSpeed),
                    _gameConfig.finishPos.y, this).gameObject;
            }
        }

        for (int i = 0; i < _gameConfig.opponentsCount; i++)
        {
            _opponents[i].transform.position = _positionController.GetNewPos();
        }
    }

    private void CreatePlayers()
    {

        if (_player == null)
        {
            _player = _playerFabrik.Create(
                _gameConfig.playerSpeed, _gameConfig.finishPos.y, this).gameObject;
        }
            _player.transform.position = _positionController.GetNewPos();


        
      
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
