using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    private Rigidbody2D rb2dEnemy;
    private float speed = 550f;
    private float lastShot = 0f;
    private float fireRate = 1.0f;
    private bool viuPlayer;
    public GameObject bullet;
    private bool movimentoVertical;

    void Start()
    {
        rb2dEnemy = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovimentEnemy();
    }

    void MovimentEnemy()
    {
        if (!viuPlayer && !movimentoVertical)
        {
            rb2dEnemy.velocity = Vector2.left * Time.deltaTime * speed;
        }
        else if (viuPlayer)
        {
            movimentoVertical = true;
            //rb2dEnemy.velocity = Vector2.up * Time.deltaTime * speed;W
            Fire();
            if (transform.position.y >= 3.0f)
            {
                rb2dEnemy.velocity = Vector2.down * Time.deltaTime * speed;

            }
            else if (transform.position.y <= -2f)
            {
                rb2dEnemy.velocity = Vector2.up * Time.deltaTime * speed;
            }
        }
    }

    void Fire()
    {
        if (Time.time > fireRate + lastShot)
        {
            GameObject bulletInstaciada = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletInstaciada.GetComponent<Rigidbody2D>().velocity = Vector2.left * Time.deltaTime * speed * 2;
            lastShot = Time.time;
        }
    }

    #region OnTriggers
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            viuPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            viuPlayer = false;
        }
    } 
    #endregion
}