using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject rangedEnemy;
    public GameObject SwordEnemy;
    public float waitTime = 5f;
    public int randomenemy;

    public float minX = -8f;
    public float minY = -4.25f;
    public float maxX = 8f;
    public float maxY = 4.25f;




    public float OutY = 10f;
    public float OutY2 = -10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(constantSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator constantSpawning()
    {
        while (true)
        {


            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector3 RandomINNERposition = new Vector3( randomX, randomY, 0f);


            int randomboundary = Random.Range(1, 3);    


            randomenemy = Random.Range(1,3);
            yield return new WaitForSeconds(waitTime);

            Vector3 OutsidespawnUP = new Vector3( 0f, OutY, 0f);
            Vector3 OutsidespawnUP2 = new Vector3( 0f, OutY2, 0f);


            if (randomenemy == 1)
            {
                if ( randomboundary == 1)
                {
                    Instantiate(SwordEnemy, OutsidespawnUP , Quaternion.identity);
                }
                if ( randomboundary == 2)
                {
                    Instantiate(SwordEnemy, OutsidespawnUP2 , Quaternion.identity);
                }
                
            }
            if (randomenemy == 2)
            {
                Instantiate(rangedEnemy, RandomINNERposition, Quaternion.identity);
            }
        }
    }
}
