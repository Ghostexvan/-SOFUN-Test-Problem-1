using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AvatarCollection : ScriptableObject
{
    [SerializeField]
    private List<Sprite> avatars = new List<Sprite>();

    public Sprite GetRandomAvatar(){
        return avatars[Random.Range(0, avatars.Count)];
    }
}
