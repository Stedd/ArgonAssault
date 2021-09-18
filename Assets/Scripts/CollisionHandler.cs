using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    Mover mover;

    [Header("Particles")]
    [SerializeField] GameObject[] particles;
    [SerializeField] GameObject[] parts;

    private void Start()
    {
        mover = GetComponent<Mover>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        Debug.Log("Crashed, respawning");
        PlayExplosion();
        DisableMovement();
        DisableBoxCollider();
        Invoke("Respawn", 1f);
    }


    void PlayExplosion()
    {
        particles[0].GetComponent<ParticleSystem>().Play();
        
        foreach (GameObject part in parts)
        {
            var meshRenderer = part.GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    void DisableMovement()
    {
        mover.enabled = false;
    }

    private void DisableBoxCollider()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    void Respawn()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
