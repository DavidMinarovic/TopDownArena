using UnityEngine;
using System.Collections;
public class sheep : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 randomdirection = new Vector2(-1f, 1f);
    public int walkTimeMin;
    public int walkTimeMax;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        Vector2 randomdirection = new Vector2(randomX, randomY).normalized;
        StartCoroutine(RandomStartDelay());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    IEnumerator RandomStartDelay()
    {
        yield return new WaitForSeconds(Random.Range(walkTimeMin, walkTimeMax));
        float randomX = Random.Range(-1f, 1f);
        rb.AddForce(randomdirection);
        StartCoroutine(RandomStartDelay());

    }
}
