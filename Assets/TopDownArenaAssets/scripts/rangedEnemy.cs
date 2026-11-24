using UnityEngine;
using System.Collections;


public class rangedEnemy : MonoBehaviour
{

    public GameObject player;
    public int enemyhealth = 2;
    private Transform playerTransform;
    public GameObject projectile;
    public bool cantakedamage;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = player.transform;
        StartCoroutine(enemyShooting());
        
        cantakedamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerdirection = playerTransform.position - transform.position;
        transform.up = playerdirection;




        if ( enemyhealth == 0 )
        {
            Destroy(gameObject);
        }



    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("voslo");

        if (collision.gameObject.CompareTag("Damagable") && cantakedamage)
        {
           enemyhealth = enemyhealth - 1;
           StartCoroutine(damagecd());    
        }
    }

    IEnumerator enemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }



    IEnumerator damagecd()
    {
        cantakedamage = false;
        yield return new WaitForSeconds(.76f);
        cantakedamage = true;
    }
}
