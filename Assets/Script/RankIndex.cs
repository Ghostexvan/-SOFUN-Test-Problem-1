using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RankIndex : ScriptableObject
{
    [SerializeField]
    private List<Sprite> rankSprites = new List<Sprite>();

    public Sprite GetRankSprite(int index){
        return rankSprites[index - 1];
    }
}
