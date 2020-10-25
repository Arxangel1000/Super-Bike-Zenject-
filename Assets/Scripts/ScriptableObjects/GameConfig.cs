using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Create game config")]
public class GameConfig : ScriptableObject
{
    public int tankHealth;
    public float playerSpeed;
    public int tankArmor;
    public float OpponentMinSpeed;
    public float OpponentMaxSpeed;
    public Vector3 startPos;
    public Vector3 finishPos;
    public float distanceBetweenOpponents;

    public GameObject playerPrefab;
    public GameObject opponentPrefab;

    public int opponentsCount;
    
}
