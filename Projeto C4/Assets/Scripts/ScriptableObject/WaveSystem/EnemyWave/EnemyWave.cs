using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "ScriptableObjects/WaveSystem/EnemyWave")]
public class EnemyWave : ScriptableObject
{
    public InimigoType inimigoType;
    public int count;
    public float time;
}