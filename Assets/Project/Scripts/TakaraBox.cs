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
    /// �}�E�X�N���b�N�̃C�x���g���\�b�h
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
    /// �󕨂��h���b�v���郁�\�b�h
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
    /// �󔠂̊J���A�j���[�V�������Đ����郁�\�b�h
    /// </summary>
    public void PlayOpenAnimation()
    {
        animator.SetTrigger("OpenTrigger");
    }

    /// <summary>
    /// �w�肵�����ʉ����Đ����郁�\�b�h
    /// </summary>
    /// <param name="se">���ʉ�</param>
    public void PlaySound( AudioClip se )
    {
        audioSource.PlayOneShot(se);
    }

    /// <summary>
    /// ScoreManager�̃X�R�A�����Z���郁�\�b�h
    /// </summary>
    /// <param name="add">���Z�l</param>
    public void AddScore(int add)
    {
        scoreManager.AddScore(add);
    }
}
