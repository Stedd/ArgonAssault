using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scoreValue = 1;

    ScoreBoard scoreBoard;


    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        ProcessDeath(other);
    }

    private void ProcessHit()
    {
        scoreBoard.UpdateScore(scoreValue);
    }

    private void ProcessDeath(GameObject other)
    {
        Debug.Log($"{name} destroyed by {other.gameObject.name}");
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
