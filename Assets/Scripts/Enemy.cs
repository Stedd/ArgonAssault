using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject damageVFX;
    //[SerializeField] Transform parent;
    [SerializeField] float health = 10f;
    [SerializeField] int scoreValue = 1;

    TMP_Text healthText;
    ScoreBoard scoreBoard;
    Transform vfxParent;


    private void Start()
    {
        vfxParent = GameObject.FindWithTag("VFXGameObjectParent").transform;
        scoreBoard = FindObjectOfType<ScoreBoard>();
        healthText = GetComponentInChildren<TMP_Text>();
        AddRigidBody();
        //UpdateHealthText(health);
    }

    private void AddRigidBody()
    {
        Rigidbody entityRigidBody = gameObject.AddComponent<Rigidbody>();
        entityRigidBody.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit(other);
    }

    private void ProcessHit(GameObject other)
    {
        SpawnVFX(damageVFX);

        scoreBoard.UpdateScore(scoreValue);

        health -= other.GetComponent<Weapon>().damage;

        //UpdateHealthText(health);

        if(health <= 0)
        {
            ProcessDeath(other);
        }
    }

    private void ProcessDeath(GameObject other)
    {
        SpawnVFX(deathVFX);
        Destroy(gameObject);
    }

    private void SpawnVFX(GameObject _vfx)
    {
        GameObject vfx = Instantiate(_vfx, transform.position, Quaternion.identity);
        vfx.transform.parent = vfxParent;
    }

    void UpdateHealthText(float _health)
    {
        healthText.text = health.ToString();
    }

}
