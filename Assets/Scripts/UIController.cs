using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] private Slider energySlider;
    [SerializeField] private TMP_Text energyText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    } 

    public void UpdateEnergySlider(float current, float max)
    {
        energySlider.value = current ;
        energySlider.maxValue = max;
        energyText.text = energySlider.value + " / " + energySlider.maxValue;
    }
}
