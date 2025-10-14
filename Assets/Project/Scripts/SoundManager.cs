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
    /// ���ʂ��Z�[�u���郁�\�b�h
    /// </summary>
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
        PlayerPrefs.SetFloat("SeVolume", seSlider.value);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// ���ʂ̃Z�[�u�f�[�^�����[�h���郁�\�b�h
    /// </summary>
    public void LoadVolume()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("BgmVolume");
        seSlider.value = PlayerPrefs.GetFloat("SeVolume");
    }

    /// <summary>
    /// ���ʂ�Mixer�ɔ��f���郁�\�b�h
    /// </summary>
    public void SoundMixerUpdate()
    {
        audioMixer.SetFloat("BgmVolume", bgmVolume);
        audioMixer.SetFloat("SeVolume", seVolume);
    }

    /// <summary>
    /// BGM���ʂ��X�V���郁�\�b�h
    /// </summary>
    public void UpdateBgmVolume()
    {
        bgmVolume = (bgmSlider.value * 100) - 80;
    }

    /// <summary>
    /// SE���ʂ��X�V���郁�\�b�h
    /// </summary>
    public void UpdateSeVolume()
    {
        seVolume = (seSlider.value * 100) - 80;
    }
}
