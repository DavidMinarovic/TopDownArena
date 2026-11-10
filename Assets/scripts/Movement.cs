using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX = moveSpeed;
        }
        else
        {
            rb.linearVelocityX = 0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocityY = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocityY = -moveSpeed;
        }
        else
        {
            rb.linearVelocityY = 0f;
        }





    }
}
