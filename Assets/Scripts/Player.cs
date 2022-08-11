using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce = 10f;
    public SpriteRenderer sr;
    string currentColor;
    public Color cyan;
    public Color yellow;
    public Color magenta;
    public Color pink;

    private void Start()
    {
        randomColor();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            rb.velocity = Vector2.up * jumpForce;
                //rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "colorChanger")
        {
            randomColor();
            Destroy(collision.gameObject);
            return;
        }

        if (collision.tag != currentColor)
            FindObjectOfType<restartSlowness>().endGame();

    }

    void randomColor()
    {
        int index = Random.Range(0,4);

        switch (index)
        {
            case 0:
                sr.color = cyan;
                currentColor = "cyan";
                break;
            case 1:
                sr.color = yellow;
                currentColor = "yellow";
                break;
            case 2:
                sr.color = magenta;
                currentColor = "magenta";
                break;
            case 3:
                sr.color = pink;
                currentColor = "pink";
                break;
        }
    }
}
