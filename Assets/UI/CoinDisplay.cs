using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject coinImage;

    public void DisplayCoin(bool hasCoin)
    {
        coinImage.SetActive(hasCoin);
    }
}
