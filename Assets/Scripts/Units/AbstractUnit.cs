using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

public abstract class AbstractUnit : MonoBehaviour
{
    [Inject]
    protected float _speed;
    [Inject]
    protected float _finishPos;
    [Inject]
    protected GameController _gameController;
    
    void Update()
    {
        if (_gameController.CanMove)
        {
            Move();
        }
    }

    protected virtual void Move() { }
}
