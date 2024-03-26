using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRankInfoController : MonoBehaviour
{
    #region Private Serialize Fields
    // The texture for displayer player's rank
    [Tooltip("The texture for displayer player's rank")]
    [SerializeField]
    private Image rankTexture;

    // The text for displaying player's rank
    [Tooltip("The text for displaying player's rank")]
    [SerializeField]
    private TMP_Text rankText;

    // The texture for displaying player's avatar
    [Tooltip("The texture for displaying player's avatar")]
    [SerializeField]
    private Image avatarTexture;

    // The text for displaying player's name
    [Tooltip("The text for displaying player's name")]
    [SerializeField]
    private TMP_Text nameText;

    // The text for displaying player's level
    [Tooltip("The text for displaying player's level")]
    [SerializeField]
    private TMP_Text levelText;

    // The text for displaying player's combat power
    [Tooltip("The text for displaying player's combat power")]
    [SerializeField]
    private TMP_Text powerText;

    // The texture pool for top 3 players
    [Tooltip("The texture pool for top 3 players")]
    [SerializeField]
    private RankIndex rankIndexTexture;

    // The texture pool for player's avatar
    [Tooltip("The texture pool for player's avatar")]
    [SerializeField]
    private AvatarCollection avatarCollection;
    
    #endregion

    #region Public Methods
    // Set the received info to the player rank object
    public void SetInfo(int rank, string name, int level, int power){
        // Get the texture for the top 3 player
        if (rank <= 3){
            rankText.gameObject.SetActive(false);
            rankTexture.sprite = rankIndexTexture.GetRankSprite(rank);
            this.gameObject.GetComponent<Image>().color = rankIndexTexture.GetRankColor(rank);
        } else {
        // Get the sprite assest for other players
            rankTexture.gameObject.SetActive(false);
            rankText.text = "";

            while (rank != 0){
                int rankChar = rank % 10;
                rankText.text = "<sprite index=" + rankChar + ">" + rankText.text;
                rank = rank / 10;
            }
        }

        // Set player's name
        nameText.text = name;

        // Set player's level
        levelText.text = level.ToString();

        // Set player's combat power
        powerText.text = "";
        while (power != 0) {
            int powerChar = power % 10;
            powerText.text = "<sprite index=" + powerChar + ">" + powerText.text;
            power = power / 10;
        }

        // Set player's avatar
        avatarTexture.sprite = avatarCollection.GetRandomAvatar();
    }

    #endregion
}
