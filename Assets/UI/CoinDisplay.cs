using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject coinImage;

    public void DisplayCoin()
    {
        coinImage.SetActive(true);
    }

    public void HideCoin()
    {
        coinImage.SetActive(false);
    }
}
