using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ViewportPointToRay(new(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
            {
                Debug.Log($"Raycast hit something: {hitInfo.transform.name}");
            }
            else
            {
                Debug.Log("Raycast did not hit anything");
            }
        }
    }
}
