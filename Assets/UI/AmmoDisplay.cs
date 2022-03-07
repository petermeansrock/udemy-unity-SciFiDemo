using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;

    public void UpdateAmmo(int ammo)
    {
        ammoText.text = $"Ammo: {ammo}";
    }
}
