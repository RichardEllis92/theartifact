using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{

    [SerializeField]
    private GameObject slashPrefab;

    [SerializeField]
    private float attackCooldown = 0.3f;

    private float attackTimer;

    private AudioSource audioSource;

    private Camera mainCamera;

    private Vector3 spawnPosition;

    [SerializeField]
    private GameObject Artifact;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main;

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time > attackTimer)
        {
            if (Artifact)
            {
                Slash();
                audioSource.Play();
                attackTimer = Time.time + attackCooldown;
            }



        }
    }

    void Slash()
    {
        spawnPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.z = 0f;

        Instantiate(slashPrefab, spawnPosition, Quaternion.identity);
    }

} //class
