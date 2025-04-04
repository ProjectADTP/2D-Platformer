using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public void Rotate(float moveInput)
    {
        Vector3 direction = new Vector3(0, 0, moveInput); 

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1f);
    }
}