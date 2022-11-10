using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_GROUND = 20f;

    [SerializeField] private Transform levelStart;
    [SerializeField] private Transform levelGround;
    public GameObject player;
    private Vector3 lastEndPosition;
    private Vector3 spawnOffset = new Vector3(11f, 1f, 0);

    private void Awake()
    {
        lastEndPosition = levelStart.Find("EndPosition").position;
        SpawnLevel();
        SpawnLevel();
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
