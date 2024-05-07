using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsProjectile : Projectile
{
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject impactPrefab; // Prefab for the impact effect
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public override void Init(Weapon weapon)
    {
        base.Init(weapon);
        Destroy(gameObject, lifeTime);
    }

    public override void Launch()
    {
        base.Launch();
        rigidBody.AddRelativeForce(Vector3.forward * weapon.GetShootingForce(), ForceMode.Impulse);
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (impactPrefab != null)
    //     {
    //         Instantiate(impactPrefab, transform.position, Quaternion.identity);
    //     }

    //     Destroy(gameObject);
    //     TargetHittable[] damageTakers = other.GetComponentsInParent<TargetHittable>();

    //     foreach (var taker in damageTakers)
    //     {
    //         taker.OnHit();
    //     }
    // }

    void OnCollisionEnter(Collision collision)
    {
        if (impactPrefab != null)
        {
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
        }

        if (collision.gameObject != gameObject)
        {
            Debug.Log("Hit: " + collision.gameObject.name);
                        
            Destroy(gameObject);
            TargetHittable[] damageTakers = collision.gameObject.GetComponentsInParent<TargetHittable>();

            foreach (var taker in damageTakers)
            {
                taker.OnHit();
            }
        }
    }

}
