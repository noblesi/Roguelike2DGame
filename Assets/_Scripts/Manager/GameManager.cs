using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{
    RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    [SerializeField] private GameObject dungeonPrefab;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject PlayerInstance;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public List<Vector2Int> startPosList = new List<Vector2Int>();
    public Vector3 startPos;

    private void Awake()
    {
        roomFirstDungeonGenerator = gameObject.GetComponent<RoomFirstDungeonGenerator>();
    }

    public void InitDungeon()
    {
        startPosList.Clear();
        
        dungeonPrefab.SetActive(true);
        roomFirstDungeonGenerator.GenerateDungeon();
        int idx = Random.Range(0, startPosList.Count);
        startPos = new Vector3(startPosList[idx].x, startPosList[idx].y, 0);
        PlayerInstance = Instantiate(playerPrefab, startPos, Quaternion.identity);

        if(virtualCamera != null && PlayerInstance != null)
        {
            virtualCamera.Follow = PlayerInstance.transform;
        }
    }
}
