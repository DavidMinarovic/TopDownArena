using UnityEngine;
using System.Collections;

public class sheeep : MonoBehaviour
{
    private Rigidbody2D rb;
    public float walkTimeMin = 1f;
    public float walkTimeMax = 3f;
    public float speedMin = 2f;
    public float speedMax = 6f;
    public float restTimeMin = 4;   
    public float restTimeMax = 8;
    public Transform spriteTransform;
    public GameObject eatengrass;
    public float chanceToEat;
    public Collider2D mouseCheckCollider;
    bool isMouseInside;
    public GameObject wool;
    private bool isStandingOnEatenGrass = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Rnadomcoroutine());
    }

    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        isMouseInside = mouseCheckCollider.OverlapPoint(mouseWorldPos);
    }

    IEnumerator Rnadomcoroutine()
    {
        while (true)
        {
            float waitTime = Random.Range(walkTimeMin, walkTimeMax);
            
            yield return new WaitForSeconds(waitTime);
            rb.linearVelocity = Vector2.zero;
            yield return Pausingcort();  
        
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);
            Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

            float randomSpeed = Random.Range(speedMin, speedMax);
            rb.linearVelocity = Vector2.zero;

            rb.AddForce(randomDirection * randomSpeed, ForceMode2D.Impulse);

            
            
        }
    }
    
    

    IEnumerator Pausingcort()
    {
        yield return new WaitForSeconds(1.5f);
        chanceToEat = Random.Range(0f, 10f);
        Vector3 originalPosition = spriteTransform.transform.position;
        Vector3 spawnPos = transform.position;
        if (chanceToEat > 4 && isStandingOnEatenGrass == false)
        {
           
            
            spriteTransform.transform.position = originalPosition + new Vector3(0f, -0.4f, 0f);
            yield return new WaitForSeconds(2f);
            spriteTransform.transform.position = originalPosition;

        
            Instantiate(eatengrass, spawnPos, Quaternion.identity);
            wool.SetActive(true);
        }
    }



    void OnMouseDown()
    {
        if (isMouseInside == true)
        {
            wool.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isStandingOnEatenGrass = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isStandingOnEatenGrass = false;
    }

 // v skole som sa tu trochu zasekol tak niektore veci mozno nebudu uplne presne ako podla zadania. Ospravedlnujem sa ale nebol som asi v najlepsiom  stave, prisiel som domov a nemal som problem s dokoncenim ostatnych uloh


}