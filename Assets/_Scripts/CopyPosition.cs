using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CopyPosition : MonoBehaviour
{
    //[SerializeField] Transform target;

    private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        //virtualCamera.Follow.position = GameManager.Instance.startPos;
    }
}
