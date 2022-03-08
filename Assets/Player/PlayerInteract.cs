using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<bool> coinUpdatedEvent;
    [SerializeField]
    private GameObject weapon;

    private bool hasCoin = false;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var collectable = other.GetComponent<Collectable>();
            if (collectable != null)
            {
                hasCoin = true;
                coinUpdatedEvent.Invoke(hasCoin);
                collectable.collect();
            }

            var vendor = other.GetComponent<Vendor>();
            if (vendor != null)
            {
                int coins = hasCoin ? 1 : 0;
                if (vendor.Offer(coins))
                {
                    weapon.SetActive(true);
                    hasCoin = false;
                    coinUpdatedEvent.Invoke(hasCoin);
                }
            }
        }
    }
}
