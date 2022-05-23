using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("AUDIO SHENANNIGANS")]
    [SerializeField] private AudioSource ded;

    private int playerLives;
    private int currentLives;
    public GameObject Objt;

    private Vector3 respawnPoint;

    private void Start()
    {
        
        playerLives = 3;
        currentLives = playerLives;
        respawnPoint = transform.position;
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy") && Player_Movement.shadowState == false)
        {
            Die();
        }
    }

    public void SetSpawnPoint (Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }


    public void Die()
    {
        ded.volume = Random.Range(0.8f, 1f);
        ded.pitch = Random.Range(0.7f, 1.5f);
        ded.Play();
        if(currentLives < 1)
        {
            GetComponent<DeathMenu>().PlayerDies();
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Player_Movement>().enabled = false;
        }
        else
        {
            currentLives--;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Player_Movement>().enabled = false;
            Respawn();
        }
        
    }

    void Respawn()
    {
        transform.position = respawnPoint;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Player_Movement>().enabled = true;
        GetComponent<Player_Movement>().enabled = true;
    }

}
