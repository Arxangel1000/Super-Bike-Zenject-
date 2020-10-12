using UnityEngine;
using Zenject;

public class UnitPositionController 
{
    [Inject]
    private GameConfig _config;
    
    private int _posCounter;

    public Vector3 GetNewPos()
    {
        _posCounter++;
        return _config.startPos + new Vector3(
            _posCounter * _config.distanceBetweenOpponents, 0 ,0 );
    }

    public void Reset()
    {
        _posCounter = 0;
    }
}
