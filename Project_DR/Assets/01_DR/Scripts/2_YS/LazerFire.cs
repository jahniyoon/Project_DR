using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerFire : MonoBehaviour
{
    public Damageable damageable;

    public float damage = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("Player"))
        {
            other.GetComponent<Damageable>().DealDamage(damage);
            GFunc.Log("불 장판 데미지 들어온다");
        }
    }
}
