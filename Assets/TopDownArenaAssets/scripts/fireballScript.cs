using UnityEngine;

public class fireballScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 12f;
    public float lifetime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()    
    {
        rb = GetComponent<Rigidbody2D>();


        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
