using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Collectible", menuName ="Collectible")]
public class CollectibleScriptableObject : ScriptableObject
{
    public new string name;

    public int minScore;
    public int maxScore;

    public int GetScore()
    {
        return Random.Range(minScore, maxScore + 1);
    }
}
