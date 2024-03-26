using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RankIndex : ScriptableObject
{
    #region Public Struct
    // Use to store displaying index and color for the top 3 player
    [Serializable]
    public struct RankDetails{
        public Sprite rankIndexSprite;
        public Color32 rankColor;
    }

    #endregion

    #region Private Serialize Fields
    // Rank's details for the top 3 players
    [Tooltip("Rank's details for the top 3 players")]
    [SerializeField]
    private List<RankDetails> rankSprites = new List<RankDetails>();

    #endregion

    #region Public Methods
    // Get the sprite for rank's texture
    public Sprite GetRankSprite(int index){
        return rankSprites[index - 1].rankIndexSprite;
    }

    // Get the color for rank's display
    public Color32 GetRankColor(int index){
        return rankSprites[index - 1].rankColor;
    }

    #endregion
}
