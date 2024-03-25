using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRankInfoController : MonoBehaviour
{
    [SerializeField]
    private Image rankTexture;

    [SerializeField]
    private TMP_Text rankText;

    [SerializeField]
    private Image avatarTexture;

    [SerializeField]
    private TMP_Text nameText;

    [SerializeField]
    private TMP_Text levelText;

    [SerializeField]
    private TMP_Text powerText;

    [SerializeField]
    private RankIndex rankIndexTexture;

    [SerializeField]
    private AvatarCollection avatarCollection;

    public void SetInfo(int rank, string name, int level, int power){
        if (rank <= 3){
            rankText.gameObject.SetActive(false);
            rankTexture.sprite = rankIndexTexture.GetRankSprite(rank);
        } else {
            rankTexture.gameObject.SetActive(false);
            rankText.text = "";

            while (rank != 0){
                int rankChar = rank % 10;
                rankText.text = "<sprite index=" + rankChar + ">" + rankText.text;
                rank = rank / 10;
            }
        }

        nameText.text = name;
        levelText.text = level.ToString();

        powerText.text = "";
        while (power != 0) {
            int powerChar = power % 10;
            powerText.text = "<sprite index=" + powerChar + ">" + powerText.text;
            power = power / 10;
        }

        avatarTexture.sprite = avatarCollection.GetRandomAvatar();
    }
}
