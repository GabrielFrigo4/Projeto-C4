using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "ScriptableObjects/WaveSystem/EnemyWave")]
public class EnemyWave : ScriptableObject
{
    public InimigoType InimigoType;
    public int count;
    public float time;
}