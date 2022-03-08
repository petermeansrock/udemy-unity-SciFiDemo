using UnityEngine;

public class Vendor : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool Offer(int coins)
    {
        if (coins > 0)
        {
            audioSource.Play();
            return true;
        }
        else
        {
            Debug.Log("Get out of here!");
            return false;
        }
    }
}
