using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class API_Receiver : MonoBehaviour
{
    #region Public Struct
    // This struct use to store player's info received
    [Serializable]
    public struct PlayerInfo{
        public int rank;
        public string name;
        public int luc_chien;
        public int level;
    }

    #endregion

    #region Private Fields
    // List of player's info stored
    private PlayerInfo[] playerInfos;

    #endregion

    #region Private Serialize Fields
    [Tooltip("The transform of the place to spawn player's info object")]
    [SerializeField]
    private Transform rankContent;

    [Tooltip("The player's info object")]
    [SerializeField]
    private GameObject playerRankPrefab;

    #endregion

    #region Monobehaviour Callbacks
    // Start is called before the first frame update
    void Start()
    {
        // Get data from API link.
        StartCoroutine(GetRequest("https://sofun.vn/API/rank.php"));
    }

    #endregion

    #region Private Methods
    // Use to display received data on the scroll view
    private void ShowPlayersRank(){
        for (int index = 0; index < playerInfos.Length; index++){
            GameObject playerInfo = Instantiate(playerRankPrefab, rankContent);
            playerInfo.GetComponent<PlayerRankInfoController>().SetInfo(
                playerInfos[index].rank,
                playerInfos[index].name,
                playerInfos[index].level,
                playerInfos[index].luc_chien
            );
        }
    }

    #endregion

    #region IEnumerator Methods
    // Create new thread to receive data
    private IEnumerator GetRequest(string uri){
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)){
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    string received = "{\"Players\":" + webRequest.downloadHandler.text + "}";
                    playerInfos = JsonHelper.FromJson<PlayerInfo>(received);
                    ShowPlayersRank();
                    break;
            }
        }
    }

    #endregion
}

// Use to convert received data string from API into list objects
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Players;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Players = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Players = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Players;
    }
}