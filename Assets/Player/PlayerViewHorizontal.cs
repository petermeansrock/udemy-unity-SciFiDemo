using UnityEngine;

public class PlayerViewHorizontal: MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 3.5f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        var newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * sensitivity;
        transform.localEulerAngles = newRotation;
    }
}
