using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;

    bool isFacingRight;
    bool isJumping;

    Animator anim;
    Rigidbody2D rg2d;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rg2d = GetComponent<Rigidbody2D>();
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(x, 0).normalized;

        if (Input.GetAxis("Jump") > 0)
        {
            if (!isJumping)
            {
                Jump();
            }
        }

        Move(speed, direction);
    }

    void Move(float speed, Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.x = max.x - 0.285f;
        min.x = min.x + 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    void Jump()
    {
        Debug.Log("is jumping!");
        isJumping = true;
        rg2d.AddForce(new Vector3(0, jump, 0));
        anim.SetBool("isJumping", true);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            Debug.Log("is grounded!");
            isJumping = false;
            anim.SetBool("isJumping", false);
        }
    }
}
