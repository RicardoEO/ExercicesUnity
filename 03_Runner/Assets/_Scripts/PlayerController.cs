using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce;
    public bool isOnGround = true;
    private bool _gameOver = false;
    private Animator _animator;
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";

    public ParticleSystem explosion;
    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;
    
    public bool gameOver
    {
        get => _gameOver;
 
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _animator.SetFloat("Speed_f", 1);
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("speed multiplier", 1+Time.time/10);
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // F = m * a
            isOnGround = false;
            _animator.SetTrigger("Jump_trig");
            _audioSource.PlayOneShot(jumpSound);
        }

    }

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if(other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            explosion.Play();
            _animator.SetBool(DEATH_B, true);
            _animator.SetInteger(DEATH_TYPE_INT, UnityEngine.Random.Range(1, 3));
            _audioSource.PlayOneShot(crashSound);
            Invoke("RestartGame", 1.0f);
        }
    }
    private void RestartGame()
    {
        SceneManager.LoadScene("Prototype 3");
    }
}
