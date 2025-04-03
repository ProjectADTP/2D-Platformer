using UnityEngine;
using Cinemachine;

public class FreezeCameraY : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Player target;
    
    private float fixedY;

    void Awake()
    {
        fixedY = virtualCamera.transform.position.y;
    }

    void LateUpdate()
    {
        if (virtualCamera != null && target != null)
        {
            Vector3 cameraPosition = virtualCamera.transform.position;

            cameraPosition.y = fixedY;
            cameraPosition.x = target.transform.position.x;

            virtualCamera.transform.position = cameraPosition;
        }
    }
}
