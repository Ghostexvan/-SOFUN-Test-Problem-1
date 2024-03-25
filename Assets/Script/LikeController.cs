using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LikeController : MonoBehaviour
{
    public static LikeController Instance;

    [SerializeField]
    private TMP_Text likeText;

    private int avaibleLike;

    [SerializeField]
    private int maxLike = 10;

    private void Awake() {
        if (LikeController.Instance == null) {
            LikeController.Instance = this;
        }

        avaibleLike = maxLike; 
    }

    public void LikeClicked(){
        avaibleLike -= 1;
        ShowInfo();
    }

    public int GetAvaibleLike(){
        return this.avaibleLike;
    }

    private void ShowInfo(){
        likeText.text = "Lượt thích: " + avaibleLike + "/" + maxLike;
    }
}
