using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    public int ENMhealth = 2;
    private Transform playerTransform;
    public Rigidbody2D rb;
    public float movespeed;
    public bool cantakedmg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cantakedmg = true;
        playerTransform = player.transform;
        ENMhealth = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerdirection = playerTransform.position - transform.position;
        transform.up = playerdirection;

        rb.linearVelocity = transform.up * movespeed;


        if ( ENMhealth == 0 )
        {
            Destroy(gameObject);
        }



    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Damagable") && cantakedmg)
        {
           ENMhealth = ENMhealth - 1;
           //StartCoroutine(damagecdd());    
        }
    }

   /* IEnumerator damagecdd() ---- toto mi prislo ako dost otravne a celkovo zle pre hru tak so to dal prec
    {
        Debug.Log("this happenawdawdawed");
        cantakedmg = false;
        yield return new WaitForSeconds(.76f);
        cantakedmg = true;
    }
    */
}
