using UnityEngine;
using Cinemachine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Player target;
    
    private float fixedY;

    private void Awake()
    {
        fixedY = virtualCamera.transform.position.y;
    }

    private void LateUpdate()
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
