using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    private GameObject replacementPrefab;

    public void Destruct()
    {
        Instantiate(replacementPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
