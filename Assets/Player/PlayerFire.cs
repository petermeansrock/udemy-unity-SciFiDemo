using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private GameObject hitMarkerPrefab;
    [SerializeField]
    private int maxAmmo = 50;
    [SerializeField]
    private int currentAmmo;
    [SerializeField]
    private float reloadDelay = 1.5f;
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private UnityEvent<int> ammoUpdatedEvent; 

    private Coroutine reloadRoutine = null;

    private void Start()
    {
        currentAmmo = maxAmmo;
        ammoUpdatedEvent.Invoke(currentAmmo);
    }

    private void Update()
    {
        HandleFire();
        HandleReload();
    }

    private void HandleFire()
    {
        if (weapon.activeInHierarchy && Input.GetMouseButton(0) && currentAmmo > 0)
        {
            muzzleFlash.SetActive(true);
            currentAmmo--;
            ammoUpdatedEvent.Invoke(currentAmmo);
            var ray = Camera.main.ViewportPointToRay(new(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
            {
                var normalQuaternion = Quaternion.LookRotation(hitInfo.normal);
                var hitMarker = Instantiate(hitMarkerPrefab, hitInfo.point, normalQuaternion);
                Destroy(hitMarker, 1.0f);

                var targetObject = hitInfo.transform.gameObject;
                var destructable = targetObject.GetComponent<Destructable>();
                if (destructable != null)
                {
                    destructable.Destruct();
                }
            }
        }
        else
        {
            muzzleFlash.SetActive(false);
        }
    }

    private void HandleReload()
    {
        if (weapon.activeInHierarchy && Input.GetKeyDown(KeyCode.R) && reloadRoutine == null)
        {
            reloadRoutine = StartCoroutine(ReloadRoutine());
        }
    }

    private IEnumerator ReloadRoutine()
    {
        weapon.SetActive(false);
        yield return new WaitForSeconds(reloadDelay);
        weapon.SetActive(true);
        currentAmmo = maxAmmo;
        ammoUpdatedEvent.Invoke(currentAmmo);
        reloadRoutine = null;
    }
}
