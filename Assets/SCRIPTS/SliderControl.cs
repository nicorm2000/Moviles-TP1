using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("volume");
    }

    public static void ChangeValue(float value)
    {
        AudioManager.Instance.ChangeVolume(value);
    }
}
