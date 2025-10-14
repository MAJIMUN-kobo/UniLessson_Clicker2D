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
    /// スコアを加算するメソッド
    /// </summary>
    /// <param name="add">加算値</param>
    public void AddScore(int add)
    {
        score += add;
    }

    /// <summary>
    /// スコア表示を更新するメソッド
    /// </summary>
    public void UpdateText()
    {
        scoreText.text = score.ToString("#,0");
    }

    /// <summary>
    /// スコアをセーブするメソッド
    /// </summary>
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        PlaySound(saveSound);
    }

    /// <summary>
    /// スコアのセーブデータをロードするメソッド
    /// </summary>
    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("Score");
    }

    /// <summary>
    /// スコアのセーブデータを削除するメソッド
    /// </summary>
    public void DeleteScore()
    {
        score = 0;
        PlayerPrefs.DeleteKey("Score");
        PlaySound(deleteSound);
    }

    /// <summary>
    /// 指定した効果音を再生するメソッド
    /// </summary>
    /// <param name="clip">効果音</param>
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
