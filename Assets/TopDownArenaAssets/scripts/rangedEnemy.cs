using UnityEngine;
using System.Collections;


public class rangedEnemy : MonoBehaviour
{

    public GameObject player;
    public int health;
    private Transform playerTransform;
    public Rigidbody2D rb;
    public GameObject projectile;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = player.transform;
        StartCoroutine(enemyShooting());
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerdirection = playerTransform.position - transform.position;
        transform.up = playerdirection;




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

    IEnumerator enemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}
