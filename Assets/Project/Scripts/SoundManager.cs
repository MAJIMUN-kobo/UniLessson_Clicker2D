using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("** Mixer Settings **")]
    public AudioMixer audioMixer;
    [Range(-80f, 20f), Tooltip("Unit notation is 'dB'")] public float bgmVolume = 0.0f;
    [Range(-80f, 20f), Tooltip("Unit notation is 'dB'")] public float seVolume = 0.0f;

    [Header("** uGUI Settings **")]
    public Slider bgmSlider;
    public Slider seSlider;

    void Start()
    {
        LoadVolume();
    }

    void Update()
    {
        UpdateBgmVolume();
        UpdateSeVolume();
        SoundMixerUpdate();
        SaveVolume();
    }

    /// <summary>
    /// 音量をセーブするメソッド
    /// </summary>
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
        PlayerPrefs.SetFloat("SeVolume", seSlider.value);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 音量のセーブデータをロードするメソッド
    /// </summary>
    public void LoadVolume()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("BgmVolume");
        seSlider.value = PlayerPrefs.GetFloat("SeVolume");
    }

    /// <summary>
    /// 音量をMixerに反映するメソッド
    /// </summary>
    public void SoundMixerUpdate()
    {
        audioMixer.SetFloat("BgmVolume", bgmVolume);
        audioMixer.SetFloat("SeVolume", seVolume);
    }

    /// <summary>
    /// BGM音量を更新するメソッド
    /// </summary>
    public void UpdateBgmVolume()
    {
        bgmVolume = (bgmSlider.value * 100) - 80;
    }

    /// <summary>
    /// SE音量を更新するメソッド
    /// </summary>
    public void UpdateSeVolume()
    {
        seVolume = (seSlider.value * 100) - 80;
    }
}
