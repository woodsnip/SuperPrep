using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_GROUND = 20f;

    [SerializeField] private Transform levelStart;
    [SerializeField] private Transform levelGround;
    public GameObject player;
    private Vector3 lastEndPosition;
    private Vector3 spawnOffset = new Vector3(11f, 1f, 0);
    float x,y,z;

    private void Awake()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    void OnDataReceived(GetUserDataResult result) {
        Debug.Log("Data received");
        if (result.Data != null && result.Data.ContainsKey("x") && result.Data.ContainsKey("y") && result.Data.ContainsKey("z")){
            x = float.Parse(result.Data["x"].Value);
            y = float.Parse(result.Data["y"].Value);
            z = float.Parse(result.Data["z"].Value);
        
            Vector3 loadPosition = new Vector3(x,y,z);
            lastEndPosition =  loadPosition;
            SpawnLevel();
            SpawnLevel();
            Debug.Log("Successful");
        }
        else {
            Debug.Log("Unsucessful");
        }
    }

    void OnError(PlayFabError error){
        Debug.Log("Unsuccessful");
        }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_GROUND)
        {
            SpawnLevel();
        }
    }

    
    private void SpawnLevel()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelGround, spawnPosition + spawnOffset, Quaternion.identity);
        levelPartTransform.transform.parent = gameObject.transform.parent;
        return levelPartTransform;
    }
}
