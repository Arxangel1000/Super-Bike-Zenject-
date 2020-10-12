using UnityEngine;
using Zenject;

public class PlayerController : AbstractUnit
{
    protected override void Move()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            if (transform.position.y > _finishPos)
            {
                Debug.Log("You Win");
            }
        }
    }
    
    public class PlayerFabrik : Factory<float, float, GameController, PlayerController>
    {
        
    }
}
