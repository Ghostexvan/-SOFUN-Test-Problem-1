using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikeButtonController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<Button>().interactable){
            return;
        }

        if (LikeController.Instance.GetAvaibleLike() == 0){
            this.GetComponent<Button>().interactable = false;
        }
    }

    public void OnClick(){
        LikeController.Instance.LikeClicked();
        this.GetComponent<Button>().interactable = false;
    }
}
