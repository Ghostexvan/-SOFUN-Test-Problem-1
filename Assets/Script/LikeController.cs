using TMPro;
using UnityEngine;

public class LikeController : MonoBehaviour
{
    #region Public Static Fields
    // The instance of this script
    public static LikeController Instance;

    #endregion

    #region Private Serialize Fields
    // The text for displaying likes info
    [Tooltip("The text for displaying likes info")]
    [SerializeField]
    private TMP_Text likeText;

    // The maximum likes available
    [Tooltip("The maximum likes")]
    [SerializeField]
    private int maxLike = 10;

    #endregion

    #region Private Fields
    // The available likes left
    private int avaibleLike;

    #endregion

    #region MonoBehaviour Callbacks
    // Awake called first when object been created
    public void Awake() {
        // Set the instance of this script
        if (LikeController.Instance == null) {
            LikeController.Instance = this;
        }

        // Set the available likes
        avaibleLike = maxLike; 
    }

    #endregion

    # region Public Methods
    // Decrease available likes when a like button clicked
    public void LikeClicked(){
        avaibleLike -= 1;
        ShowInfo();
    }

    // Get the available likes left
    public int GetAvailableLike(){
        return this.avaibleLike;
    }

    #endregion

    #region Private Methods
    // Display the likes info
    private void ShowInfo(){
        likeText.text = "Lượt thích: " + avaibleLike + "/" + maxLike;
    }

    #endregion
}
