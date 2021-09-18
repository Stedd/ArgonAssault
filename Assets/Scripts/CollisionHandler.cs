using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.name + " --collided with-- " + collision.gameObject.name);
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log($"{this.name} **triggered by** {collision.gameObject.name}");
    }
}
