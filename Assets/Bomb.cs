using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float ratio;
    [SerializeField] private int damage;
    [SerializeField] private float explositionForce;
    [SerializeField] private GameObject ExplosionEffect;
    private bool isReady = false;
    public float delay = 0.1f;
    float startTimer;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Explosion()
    {
        Collider2D[] damageZone = Physics2D.OverlapCircleAll(transform.position, ratio);

        foreach(Collider2D col in damageZone)
        {
            Rigidbody2D rb2D = col.GetComponent<Rigidbody2D>();
            if(rb2D != null)
            {
                Vector2 direction = col.transform.position - transform.position;
                float distance = 1 + direction.magnitude;
                float explosionFinal = explositionForce / distance;
                float finalDamage = damage / distance;
                rb2D.AddForce(direction * explosionFinal);
                if (col.tag == "Player")
                {
                    Character character = col.GetComponent<Character>();
                    print(character.healthPoints);
                    print(finalDamage);
                    character.decrease(((int)finalDamage));
                    print(character.healthPoints);
                }
            }
        }

        GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIns, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady && startTimer + delay < Time.time)
        {
            print(Time.time);
            Explosion();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isReady) {
            isReady = true;
            startTimer = Time.time;
            print(Time.time);
        }
    }
}
