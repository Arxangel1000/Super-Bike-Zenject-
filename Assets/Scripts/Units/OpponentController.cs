using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class OpponentController : AbstractUnit
{
    [Inject] private OpponentWonSignal _opponentWonSignal;
    
    protected override void Move()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        if (transform.position.y > _finishPos)
        {
            _opponentWonSignal.Fire<OpponentWonSignal>();
        }
        
    }

    public class OpponentFabrik : Factory<float, float, GameController, OpponentController>
    {
        
    }
}
