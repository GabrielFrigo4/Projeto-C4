using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/WaveSystem/Wave")]
public class Wave : ScriptableObject
{
    public EnemyWave[] enemyWaves;
    public int[] paths;
    public int money;
}