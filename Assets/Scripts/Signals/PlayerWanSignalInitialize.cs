using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using Zenject;

public class PlayerWanSignalInitialize : IInitializable, IDisposable
{
    private readonly SignalBus _signalBus;

    [Inject] private GameController _controller;

    public PlayerWanSignalInitialize(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void Initialize()
    {
        _signalBus.Subscribe<PlayerWanSignal>(_controller.OnPlayerWanSignal);
        _signalBus.Subscribe<EnemyWanSignal>(_controller.OnEnemyWanSignal);
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<PlayerWanSignal>(_controller.OnPlayerWanSignal);
        _signalBus.Unsubscribe<EnemyWanSignal>(_controller.OnEnemyWanSignal);
    }
}
