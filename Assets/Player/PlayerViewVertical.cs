using UnityEngine;

public class PlayerViewVertical : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 3.5f;

    private void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        var newRotation = transform.localEulerAngles;
        newRotation.x -= mouseY * sensitivity;
        transform.localEulerAngles = newRotation;
    }
}
