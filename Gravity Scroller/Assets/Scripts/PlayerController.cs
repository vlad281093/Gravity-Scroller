using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] public float speed = 6f;
    public bool isGravityChange { get; set; }
    public GameManager theGameManager;
    public AudioSource jumpSound;
    public AudioSource deathSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGravityChange = true;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isGravityChange)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.gravityScale *= -1;
            isGravityChange = false;
            jumpSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGravityChange = true;
        if (collision.gameObject.tag == "killbox")
        {
            FindObjectOfType<ScoreManager>().SaveScore();
            theGameManager.RestartGame();
            rb.gravityScale = 3;
            deathSound.Play();
        }
    }




}
