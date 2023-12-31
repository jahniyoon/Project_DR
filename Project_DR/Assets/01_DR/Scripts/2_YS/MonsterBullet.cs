using BNG;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MonsterBullet : MonoBehaviour
{
    public Rigidbody rigid;
    public DamageCollider damageCollider;
    public Transform target;

    public float attack = 0.2f;

    public int ProjectileID;

    public float damageRadius = 1.0f;

    public bool isDamage = false;

    [Header("테이블 관련")]
    public float speed = default;
    public float damage = default;

    void Awake()
    {
        GetData(ProjectileID);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<PlayerPosition>().playerPos;
        damageCollider = GetComponent<DamageCollider>();
        rigid = GetComponent<Rigidbody>();

        transform.LookAt(target.position);

        rigid.velocity = transform.forward * speed;

        damageCollider.Damage = damage;
    }

    private void Update()
    {
        DealDamageToNearbyObjects();

       
    }

    void DealDamageToNearbyObjects()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        Collider[] colliders = Physics.OverlapSphere(transform.position, damageRadius);

        if (distance <= attack)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    // 데미지를 처리하거나 플레이어 스크립트에 데미지를 전달
                    collider.GetComponent<Damageable>().DealDamage(damage);
                    GFunc.Log($"데미지:{damage}");

                    isDamage = true;
                    Destroy(this.gameObject);
                    break;
                }

            }
        }

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Wall"))
            {
                Destroy(this.gameObject);
                GFunc.Log("벽이나 바닥 만났을 때 파괴되는가");
            }
        }

        Destroy(this.gameObject, 6.0f);
       

    }

    public virtual void GetData(int ProjectileID)
    {
        speed = (float)DataManager.Instance.GetData(ProjectileID, "MonSpd", typeof(float));
        damage = (float)DataManager.Instance.GetData(ProjectileID, "MonAtt", typeof(float));
    }


}
