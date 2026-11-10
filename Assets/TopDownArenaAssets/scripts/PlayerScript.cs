using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public int health = 3;
    public float movementspeed;
    public GameObject swordcollider;
    public GameObject fireball;
    public GameObject firepointthing;
    public bool fireballcooldown;
    public float fireballSpeed = 12f;
    public TextMeshProUGUI healthtext;
    public bool iframeOn = false;
    public bool healthCD = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        swordcollider.SetActive(false);

        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX = -movementspeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX = movementspeed;
        }
        else
        {
            rb.linearVelocityX = 0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocityY = movementspeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocityY = -movementspeed;
        }
        else
        {
            rb.linearVelocityY = 0f;
        }

/////////////////////////////////////////////
/// 
/// 
/// 
        if (Input.GetKey(KeyCode.Space))    
        {
            StartCoroutine(swordaction());
        }




        if (Input.GetKey(KeyCode.Q) && healthCD == false)
        {
            Heal();
            StartCoroutine(healthcooldownCORT());
        }


        

/////////////////////////////////////////

        if(Input.GetKey(KeyCode.E) && !fireballcooldown)
        {
            fireballshoot();
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;


        transform.up = mousePosition - transform.position;




        healthtext.text = $"Health: {health}";



    }


    IEnumerator swordaction()
    {
        swordcollider.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        swordcollider.SetActive(false);
    }


    IEnumerator healthcooldownCORT()
    {
        healthCD = true;
        yield return new WaitForSeconds(12f);
        healthCD = false;
    }




        
    
    public void fireballshoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector2 direction = (mousePosition - firepointthing.transform.position).normalized;
        GameObject newFireball = Instantiate(fireball, firepointthing.transform.position, Quaternion.identity);
        Rigidbody2D rb = newFireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * fireballSpeed;
        }
        StartCoroutine(fireballcooldowncoroutine());
    }

    IEnumerator fireballcooldowncoroutine()
    {
        fireballcooldown = true;
        yield return new WaitForSeconds(1f);
        fireballcooldown = false;
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (iframeOn == false && collision.gameObject.CompareTag("Enemy"))
        {
            health = health - 1;
            StartCoroutine(Iframes());
        }
    }

    
    IEnumerator Iframes()
    {
        iframeOn = true;
        yield return new WaitForSeconds(1.5f);
        iframeOn = false;
    }


    public void Heal()
    {
        health = health + 1;
    }




    

}