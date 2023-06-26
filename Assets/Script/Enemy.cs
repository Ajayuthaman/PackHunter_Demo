using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public float distanceThreshold = 10f;
    public float runSpeed = 5f;
    private bool isRunning = false;

    [SerializeField] private Animator anim;

    private Rigidbody enemyRigidbody;
    private float followTimer = 0f;
    private bool isFollowing = false;

    public CinemachineFreeLook freeLookCamera;


    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
       

        float distance = Vector3.Distance(player.position, enemy.position);

        if (distance < distanceThreshold)
        {
            if (!isRunning)
            {
                isRunning = true;
                anim.SetBool("Run", true);
                isFollowing = true;
            }

            Vector3 direction = (enemy.position - player.position).normalized;
            enemyRigidbody.velocity = direction * runSpeed;
            transform.LookAt(transform.position + direction);


        }
        else
        {
            if (isRunning)
            {
                isRunning = false;
                anim.SetBool("Run", false);
                isFollowing = false;
            }

            enemyRigidbody.velocity = Vector3.zero;
        }

        if (isFollowing)
        {
            followTimer += Time.deltaTime;

            if (followTimer >= 5f)
            {
                freeLookCamera.Priority = 10;

                followTimer = 0f;
                
            }
        }
        else
        {
            // Reset the timer if not following
            followTimer = 0f;
            freeLookCamera.Priority = 0;
        }
    }
}
