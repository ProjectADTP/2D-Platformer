using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Vector3 _baseScale;

    private void Awake()
    {
        _baseScale = transform.localScale;    
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.D))
            transform.localScale = _baseScale;
        else if (Input.GetKeyDown(KeyCode.A))
            transform.localScale = new Vector3(-_baseScale.x, _baseScale.y, _baseScale.z);
    }
}