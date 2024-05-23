using Cinemachine;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void AssignTargetObject(Transform targetObject)
    {
        cinemachineVirtualCamera.Follow = targetObject;
    }
}
