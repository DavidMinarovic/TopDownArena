using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    public int health;
    private Transform playerTransform;
    public Rigidbody2D rb;
    public float movespeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = player.transform;

        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerdirection = playerTransform.position - transform.position;
        transform.up = playerdirection;

        rb.linearVelocity = transform.up * movespeed;


        if ( health == 0 )
        {
            Destroy(gameObject);
        }



    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("voslo");

        if (collision.gameObject.CompareTag("Damagable"))
        {
            health = health - 1;    
        }
    }
}
