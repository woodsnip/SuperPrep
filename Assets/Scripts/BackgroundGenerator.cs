using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_BACKGROUND = 20f;

    [SerializeField] private Transform backgroundStart;
    [SerializeField] private List<Transform> backgroundList;
    public GameObject player;
    private Vector3 lastEndPosition;
    private Vector3 spawnOffset = new Vector3(11f, 5f, 0);

    private void Awake()
    {
        lastEndPosition = backgroundStart.Find("EndPosition").position;
        SpawnBackground();
        SpawnBackground();
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
