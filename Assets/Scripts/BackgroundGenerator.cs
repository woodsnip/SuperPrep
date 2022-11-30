using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;


public class BackgroundGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_BACKGROUND = 20f;

    [SerializeField] private Transform backgroundStart;
    [SerializeField] private List<Transform> backgroundList;
    public GameObject player;
    private Vector3 lastEndPosition;
    private Vector3 spawnOffset = new Vector3(11f, 5f, 0);
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
            SpawnBackground();
            SpawnBackground();
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
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_BACKGROUND)
        {
            SpawnBackground();
        }
    }

    private void SpawnBackground()
    {
        Transform randomBackground = backgroundList[Random.Range(0, backgroundList.Count)];
        Transform lastLevelPartTransform = SpawnPart(randomBackground, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnPart(Transform background, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(background, spawnPosition + spawnOffset, Quaternion.identity);
        levelPartTransform.transform.parent = gameObject.transform.parent;
        return levelPartTransform;
    }
}
