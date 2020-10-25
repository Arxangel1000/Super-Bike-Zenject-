using System.Collections;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using Zenject;

public class OpponentController : AbstractUnit
{
    [Inject] 
    private SignalBus _signalBus;
    
    protected override void Move()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if (transform.position.y > _finishPos)
        {
            _signalBus.Fire<EnemyWanSignal>();
        }
        
    }

    public class OpponentFabrik : Factory<float, float, GameController, OpponentController>
    {
        
    }
}
