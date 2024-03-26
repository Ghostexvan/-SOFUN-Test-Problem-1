using UnityEngine;
using UnityEngine.UI;

public class LikeButtonController : MonoBehaviour
{
    #region MonoBehaviour Callbacks
    // Update is called once per frame
    void Update()
    {
        // Don't check this button if this is already disabled
        if (!this.GetComponent<Button>().interactable){
            return;
        }

        // Check the available likes left
        if (LikeController.Instance.GetAvailableLike() == 0){
            // Disable this button if no available like left
            this.GetComponent<Button>().interactable = false;
        }
    }

    #endregion

    # region Public Methods
    // Use to determine what will this button do when being clicked
    public void OnClick(){
        // Assign click to the controller
        LikeController.Instance.LikeClicked();
        // Disable this button
        this.GetComponent<Button>().interactable = false;
    }

    #endregion
}
