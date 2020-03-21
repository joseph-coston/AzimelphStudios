using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomDamage : MonoBehaviour
{
    [Header("Damage")]
    [Tooltip("Damage of the shroom")]
    public float damage = 40f;
    [Tooltip("Area of damage")]
    public float areaOfEffectDistance = 5f;
    [Tooltip("the point around which to apply the AoE")]
    public Transform point;

    [Tooltip("Damage multiplier over distance for area of effect")]
    public AnimationCurve damageRatioOverDistance;

    [Tooltip("The frequency with which to deal damage")]
    public float frequency = 1f;

    [Tooltip("Layers this projectile can collide with")]
    public LayerMask layers;

    const QueryTriggerInteraction k_TriggerInteraction = QueryTriggerInteraction.Collide;

    public GameObject owner;

    float timer;

    // Update is called once per frame
    void Update()
    {
        //timer
        if (Time.time >= timer)
        {
            // area damage effect 
            Dictionary<Health, Damageable> uniqueDamagedHealths = new Dictionary<Health, Damageable>();
       
            // Create a collection of unique health components that would be damaged in the area of effect (in order to avoid damaging a same entity multiple times)
            Collider[] affectedColliders = Physics.OverlapSphere(point.position, areaOfEffectDistance, layers, k_TriggerInteraction);
            foreach (var coll in affectedColliders)
            {
                Damageable damageable = coll.GetComponent<Damageable>();
                if (damageable)
                {
                    Health health = damageable.GetComponentInParent<Health>();
                    if (health && !uniqueDamagedHealths.ContainsKey(health))
                    {
                        uniqueDamagedHealths.Add(health, damageable);
                    }
                }
            }

            // Apply damages with distance falloff
            foreach (Damageable uniqueDamageable in uniqueDamagedHealths.Values)
            {
                float distance = Vector3.Distance(uniqueDamageable.transform.position, transform.position);
                uniqueDamageable.InflictDamage(damage * damageRatioOverDistance.Evaluate(distance / areaOfEffectDistance), true, owner);
            }

        }
        else
        {
            timer = Time.time + frequency;
        }


    }
}
