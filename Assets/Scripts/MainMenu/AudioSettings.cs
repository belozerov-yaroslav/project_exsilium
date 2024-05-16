using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Scrollbar scrollbarMaster;
    [SerializeField] private Scrollbar scrollbarMusic;
    [SerializeField] private Scrollbar scrollbarEffects;
    [SerializeField] private float masterVolumeDefault = 0.5f;
    [SerializeField] private float musicVolumeDefault = 1f;
    [SerializeField] private float effectsVolumeDefault = 1f;
    [SerializeField] private AudioMixerGroup master;
    [SerializeField] private AudioMixerGroup music;
    [SerializeField] private AudioMixerGroup effects;

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
    }

    private void MasterChanged(float value)
    {
        master.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, value));
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
    private void MusicChanged(float value)
    {
        music.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, value));
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    private void EffectsChanged(float value)
    {
        effects.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, value));
        PlayerPrefs.SetFloat("EffectsVolume", value);
    }

    public void TurnOff()
    {
        canvas.SetActive(false);
    }
}