using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private UnityEvent coinCollectedEvent;
    private bool hasCoin = false;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var collectable = other.GetComponent<Collectable>();
            if (collectable != null)
            {
                hasCoin = true;
                coinCollectedEvent.Invoke();
                collectable.collect();
            }
        }
    }
}
