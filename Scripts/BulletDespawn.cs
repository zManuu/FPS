using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour
{

    public GameObject impactEffect;
    public float impactEffectTime = 1.5F;

    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.GetContact(0);
        GameObject impactEffectObj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactEffectObj, impactEffectTime);
        Destroy(this.gameObject);
    }

}
