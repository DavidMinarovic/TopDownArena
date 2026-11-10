using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SwordDamage : MonoBehaviour
{
    public UnityEvent damageEnemy;
    public bool DamageCD;
    public bool isTouching;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DamageCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DamageCD = false && !collision.CompareTag("Player"))
        {
            damageEnemy.Invoke();
            StartCoroutine(damagecooldownCOURT());
        }
    }

    IEnumerator damagecooldownCOURT()
    {
        DamageCD = true;
        yield return new WaitForSeconds(2f);
        DamageCD = false;
    }
}
