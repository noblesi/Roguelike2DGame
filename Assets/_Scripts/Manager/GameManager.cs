using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{

    [Header("GameInfo")]
    public bool isLive;

    [Header("PlayerInfo")]
    

    [Header("DungeonInfo")]
    RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    [SerializeField] private GameObject dungeonPrefab;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject PlayerInstance;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    public static List<Vector2Int> roomCentersList = new List<Vector2Int>();
    public Vector3 startPos;

    public LevelUp LevelUpUI;

    private void Awake()
    {
        roomFirstDungeonGenerator = gameObject.GetComponent<RoomFirstDungeonGenerator>();
        roomCentersList.Clear();
    }

    public void InitDungeon()
    { 
        dungeonPrefab.SetActive(true);
        roomFirstDungeonGenerator.GenerateDungeon();

        PlayerSpawn();

        FollowCamToPlayer();
    }

    public void PlayerSpawn()
    {
        int idx = Random.Range(0, roomCentersList.Count);
        startPos = new Vector3(roomCentersList[idx].x, roomCentersList[idx].y, 0);
        PlayerInstance = Instantiate(playerPrefab, startPos, Quaternion.identity);
    }

    public static void AddRoomCenter(Vector2Int roomCneter)
    {
        roomCentersList.Add(roomCneter);
    }

    public void FollowCamToPlayer()
    {
        if (virtualCamera != null && PlayerInstance != null)
        {
            virtualCamera.Follow = PlayerInstance.transform;
        }
    }

    public static int GetExp(int exp)
    {
        return exp;
    }

    public static int GetGold(int gold)
    {
        return gold;
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
