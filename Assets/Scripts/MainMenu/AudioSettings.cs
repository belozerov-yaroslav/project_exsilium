using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Scrollbar scrollbarMaster;
    [SerializeField] private Scrollbar scrollbarMusic;
    [SerializeField] private Scrollbar scrollbarEffects;
    [SerializeField] private float masterVolumeDefault = 0.91f;
    [SerializeField] private float musicVolumeDefault = 1f;
    [SerializeField] private float effectsVolumeDefault = 1f;
    [SerializeField] private AudioMixer mixer;
    public bool Turned { get; private set; }

    private void Start()
    {
        scrollbarMaster.onValueChanged.AddListener(MasterChanged);
        scrollbarMusic.onValueChanged.AddListener(MusicChanged);
        scrollbarEffects.onValueChanged.AddListener(EffectsChanged);
        scrollbarMaster.value = PlayerPrefs.HasKey("MasterVolume")
            ? PlayerPrefs.GetFloat("MasterVolume")
            : masterVolumeDefault;
        scrollbarMusic.value = PlayerPrefs.HasKey("MusicVolume")
            ? PlayerPrefs.GetFloat("MusicVolume")
            : musicVolumeDefault;
        scrollbarEffects.value = PlayerPrefs.HasKey("EffectsVolume")
            ? PlayerPrefs.GetFloat("EffectsVolume")
            : effectsVolumeDefault;
    }

    public void TurnOn()
    {
        canvas.SetActive(true);
        Turned = true;
    }

    private void MasterChanged(float value)
    {
        if(value < 1e-7)
            mixer.SetFloat("MasterVolume", -80);
        else
            mixer.SetFloat("MasterVolume", Mathf.Log10(value)*30);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
    private void MusicChanged(float value)
    {
        if(value < 1e-7)
            mixer.SetFloat("MusicVolume", -80);
        else
            mixer.SetFloat("MusicVolume", Mathf.Log10(value)*30);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    private void EffectsChanged(float value)
    {
        if(value < 1e-7)
            mixer.SetFloat("EffectsVolume", -80);
        else
            mixer.SetFloat("EffectsVolume", Mathf.Log10(value)*30);
        PlayerPrefs.SetFloat("EffectsVolume", value);
    }

    public void TurnOff()
    {
        canvas.SetActive(false);
        Turned = false;
    }
}