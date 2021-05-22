using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5f;
    public float minY, maxY;
    [SerializeField] private GameObject PlayerBullet;
    [SerializeField] private Transform attackPoint;
    public float attackTimer = 0.15f;
    private float currectAttackTimer;
    private bool canAttack;
    private AudioSource audioSrc;

    private void Start() {
        currectAttackTimer = attackTimer;
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update() {
        MovePlayer();
        Attack();
    }

    void MovePlayer() {
        if (Input.GetAxisRaw("Vertical") > 0f) {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            if (temp.y > maxY) {
                temp.y = maxY;
            }
            transform.position = temp;
        }else if (Input.GetAxisRaw("Vertical") < 0f) {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            if (temp.y < minY) {
                temp.y = minY;
            }
            transform.position = temp;
        }
    }

    void Attack() {
        attackTimer += Time.deltaTime;
        if (attackTimer > currectAttackTimer) {
            canAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (canAttack) {
                audioSrc.Play();
                canAttack = false;
                attackTimer = 0f;
                Instantiate(PlayerBullet, attackPoint.position, Quaternion.identity);
                
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("bullet")) {
            canAttack = false;
            Destroy(gameObject);
        }
    }
} // class
