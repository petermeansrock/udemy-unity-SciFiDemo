using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private GameObject hitMarkerPrefab;

    private void Update()
    {
        // Toggle muzzle flash
        if (Input.GetMouseButtonDown(0))
        {
            muzzleFlash.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            muzzleFlash.SetActive(false);
        }

        // Log raycasts
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ViewportPointToRay(new(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
            {
                var normalQuaternion = Quaternion.LookRotation(hitInfo.normal);
                var hitMarker = Instantiate(hitMarkerPrefab, hitInfo.point, normalQuaternion);
                Destroy(hitMarker, 1.0f);
            }
        }
    }
}
