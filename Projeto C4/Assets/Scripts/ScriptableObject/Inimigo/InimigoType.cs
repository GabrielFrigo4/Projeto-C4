using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "ScriptableObjects/EnemyType")]
public class InimigoType : ScriptableObject
{
	public Texture2D texture;
    public Vector2 size;
    public int startInd, total, pixelPerUnity;
    public float time;
    public int hp, damage;
	public int moneyInDie;
    public float speed, sizeLifeBar, rangeLifeBar, heightLifeBar;
	public GameObject dead;
}