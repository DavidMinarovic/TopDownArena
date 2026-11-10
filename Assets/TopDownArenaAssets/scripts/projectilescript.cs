using UnityEngine;

public class projectilescript : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rigidb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidb.linearVelocity = transform.up * speed;   

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
