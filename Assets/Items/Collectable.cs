using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private AudioClip collectedAudioClip;

    public void collect()
    {
        AudioSource.PlayClipAtPoint(collectedAudioClip, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
