using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AvatarCollection : ScriptableObject
{
    #region Private Serialize Fields
    // Avatar's pool for the game
    [Tooltip("Avaiable avatar for the game")]
    [SerializeField]
    private List<Sprite> avatars = new List<Sprite>();

    #endregion

    #region Public Methods
    // Get random avatar from the pool
    public Sprite GetRandomAvatar(){
        return avatars[Random.Range(0, avatars.Count)];
    }

    #endregion
}
