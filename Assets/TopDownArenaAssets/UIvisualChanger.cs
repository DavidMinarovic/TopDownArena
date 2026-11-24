using UnityEngine;

public class UIvisualChanger : MonoBehaviour
{

    public float totalCooldown = 1.5f;
    public float currentTimer = 0f;

    private Vector3 fullScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fullScale = transform.localScale;

        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
     if (currentTimer > 0f)
        {
            currentTimer -= Time.deltaTime;
            float ratio = currentTimer / totalCooldown;
            transform.localScale = fullScale * ratio;
        }
        else
        {
            transform.localScale = Vector3.zero;
        }   
    }




    public void TriggerCooldown()
    {
        currentTimer = totalCooldown;
        transform.localScale = fullScale;
    }
}
