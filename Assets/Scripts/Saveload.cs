using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class Saveload : MonoBehaviour
{
    float x,y;

    public void SavePosition(){

        x = transform.position.x;
        y = transform.position.y;

        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"x", (x + "")},
                {"y", (y + "")}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSent, OnError);
    }

    void OnDataSent(UpdateUserDataResult result) {
        Debug.Log("Successful");
    }

    public void LoadPosition(){
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    void OnDataReceived(GetUserDataResult result) {
        Debug.Log("Data received");
        if (result.Data != null && result.Data.ContainsKey("x") && result.Data.ContainsKey("y")){
            x = float.Parse(result.Data["x"].Value);
            y = float.Parse(result.Data["y"].Value);
        
            Vector2 loadPosition = new Vector2(x,y);
            transform.position = loadPosition;
            Debug.Log("Successful");
        }
        else {
            Debug.Log("Unsucessful");
        }
    }

    void OnError(PlayFabError error){
        Debug.Log("Unsuccessful");
        }
}
