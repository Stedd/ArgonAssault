using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject damageVFX;
    [SerializeField] Transform parent;
    [SerializeField] float health = 10f;
    [SerializeField] int scoreValue = 1;

    ScoreBoard scoreBoard;


    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit(other);
    }

    private void ProcessHit(GameObject other)
    {
        GameObject vfx = Instantiate(damageVFX, transform.position, Quaternion.identity);
        scoreBoard.UpdateScore(scoreValue);
        health -= other.GetComponent<Weapon>().damage;
        Debug.Log($"{name} received {other.GetComponent<Weapon>().damage} damage. now has {health} left");
        if(health <= 0)
        {
            Debug.Log($"{name} died");
            ProcessDeath(other);
        }
    }

    private void ProcessDeath(GameObject other)
    {
        Debug.Log($"{name} destroyed by {other.gameObject.name}");
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
