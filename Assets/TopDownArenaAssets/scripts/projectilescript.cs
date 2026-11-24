using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class projectilescript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidb;  
    private PlayerScript player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidb.linearVelocity = transform.up * speed;   

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<PlayerScript>();
        }

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            player.health -= 1;      
            Destroy(gameObject);
        }
    }
}
