using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI _sliderText;

    [SerializeField] private bool FX;
    [SerializeField] private bool background;

    [SerializeField] private Audio audio;

    public void ChangeVolume(float value)
    {
        //float value = slider.value;
        if (FX)
        {
            PlayerPrefs.SetFloat("FX", value);
            _sliderText.text = string.Format("FX: {0}%", Mathf.Round(value * 100f));
            //Debug.Log("FX TRIGGERED!");

        }
        else if (background)
        {
            PlayerPrefs.SetFloat("Background", value);
            _sliderText.text = string.Format("Background: {0}%", Mathf.Round(value * 100f));

        }
        audio.UpdateSounds();
    }
}
