using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour {
    [SerializeField]
    private Enum @enum;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        @enum.ADamage += UpdateFiil;
    }
    private void UpdateFiil(float max, float now)
    {
        image.fillAmount = now / max;
    }
}
