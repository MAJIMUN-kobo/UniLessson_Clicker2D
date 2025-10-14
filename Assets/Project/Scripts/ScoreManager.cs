using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("** Score View **")]
    public int score = 0;

    [Header("** uGUI Settings **")]
    public TextMeshProUGUI scoreText;

    [Header("** Sound Settings **")]
    public AudioSource audioSource;
    public AudioClip saveSound;
    public AudioClip deleteSound;

    void Start()
    {
        LoadScore();
    }

    void Update()
    {
        UpdateText();
    }

    /// <summary>
    /// �X�R�A�����Z���郁�\�b�h
    /// </summary>
    /// <param name="add">���Z�l</param>
    public void AddScore(int add)
    {
        score += add;
    }

    /// <summary>
    /// �X�R�A�\�����X�V���郁�\�b�h
    /// </summary>
    public void UpdateText()
    {
        scoreText.text = score.ToString("#,0");
    }

    /// <summary>
    /// �X�R�A���Z�[�u���郁�\�b�h
    /// </summary>
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        PlaySound(saveSound);
    }

    /// <summary>
    /// �X�R�A�̃Z�[�u�f�[�^�����[�h���郁�\�b�h
    /// </summary>
    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("Score");
    }

    /// <summary>
    /// �X�R�A�̃Z�[�u�f�[�^���폜���郁�\�b�h
    /// </summary>
    public void DeleteScore()
    {
        score = 0;
        PlayerPrefs.DeleteKey("Score");
        PlaySound(deleteSound);
    }

    /// <summary>
    /// �w�肵�����ʉ����Đ����郁�\�b�h
    /// </summary>
    /// <param name="clip">���ʉ�</param>
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
