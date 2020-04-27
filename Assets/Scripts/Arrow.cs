using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float currentTime;
    private void Start()
    {
        currentTime = lifetime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            gameObject.SetActive(false);
            currentTime = lifetime;
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Health>().TakeDamage(2);
        gameObject.SetActive(false);
        currentTime = lifetime;
    }
}