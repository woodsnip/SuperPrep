using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class Saveload : MonoBehaviour
{
    float x,y,z;
    private float nextActionTime = 0.0f;
    public float period = 1.5f;

    void Start()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    // Update is called once per frame
    void Update () {
     if (Time.time > nextActionTime ) {
        nextActionTime = Time.time + period;
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"x", (x + "")},
                {"y", (y + "")},
                {"z", (z + "")}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSent, OnError);
     }
     
    }

    public void SavePosition(){

        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"x", (x + "")},
                {"y", (y + "")},
                {"z", (z + "")}
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
        if (result.Data != null && result.Data.ContainsKey("x") && result.Data.ContainsKey("y") && result.Data.ContainsKey("z")){
            x = float.Parse(result.Data["x"].Value);
            y = float.Parse(result.Data["y"].Value);
            z = float.Parse(result.Data["z"].Value);
        
            Vector3 loadPosition = new Vector3(x,y,z);
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
