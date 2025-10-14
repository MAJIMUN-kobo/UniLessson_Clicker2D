using UnityEngine;

public class TakaraBox : MonoBehaviour
{
    [Header("** Treasure Drop Settings **")]
    public GameObject treasurePrefab;
    public Vector2 dropForceMin = new Vector2(-1.0f, 0.5f);
    public Vector2 dropForceMax = new Vector2(1.0f, 1.0f);
    public float dropTorqueMin = -5f;
    public float dropTorqueMax = 5f;
    public float lifeTime = 1f;
    public Animator animator;

    [Header("** Sound Settings")]
    public AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip dropSound;

    [Header("** Score Manager **")]
    public ScoreManager scoreManager;
    public int scoreMin = 10;
    public int scoreMax = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>
    /// マウスクリックのイベントメソッド
    /// </summary>
    void OnMouseDown()
    {
        DropTreasure();
        PlayOpenAnimation();
        PlaySound(openSound);
        PlaySound(dropSound);
        AddScore(Random.Range(scoreMin, scoreMax));
    }

    /// <summary>
    /// 宝物をドロップするメソッド
    /// </summary>
    public void DropTreasure()
    {
        GameObject treasure = Instantiate(treasurePrefab, transform.position, transform.rotation);
        
        Vector2 dropForce = Vector2.zero;
        dropForce.x = Random.Range(dropForceMin.x, dropForceMax.x);
        dropForce.y = Random.Range(dropForceMin.y, dropForceMax.y);

        float dropTorque = Random.Range(dropTorqueMin, dropTorqueMax);

        Rigidbody2D rb = treasure.GetComponent<Rigidbody2D>();
        rb.AddForce(dropForce, ForceMode2D.Impulse);
        rb.AddTorque(dropTorque, ForceMode2D.Impulse);

        Destroy( treasure.gameObject, lifeTime );
    }

    /// <summary>
    /// 宝箱の開くアニメーションを再生するメソッド
    /// </summary>
    public void PlayOpenAnimation()
    {
        animator.SetTrigger("OpenTrigger");
    }

    /// <summary>
    /// 指定した効果音を再生するメソッド
    /// </summary>
    /// <param name="se">効果音</param>
    public void PlaySound( AudioClip se )
    {
        audioSource.PlayOneShot(se);
    }

    /// <summary>
    /// ScoreManagerのスコアを加算するメソッド
    /// </summary>
    /// <param name="add">加算値</param>
    public void AddScore(int add)
    {
        scoreManager.AddScore(add);
    }
}
