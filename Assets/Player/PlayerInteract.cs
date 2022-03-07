using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private bool hasCoin = false;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var collectable = other.GetComponent<Collectable>();
            if (collectable != null)
            {
                hasCoin = true;
                collectable.collect();
            }
        }
    }
}
