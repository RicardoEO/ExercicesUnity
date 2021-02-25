using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float moveForce;
    private float horizontalInput;
    public GameObject focalPoint;
    public bool hasPowerUp;
    public float powerUpForce;
    public GameObject[] powerUpIndicators;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * forwardInput, ForceMode.Force);
        foreach(GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position;
            indicator.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if (this.transform.position.y < -10)
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountdown()
    {
        for(int i = 0; i < powerUpIndicators.Length; i++)
        {
            powerUpIndicators[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(7 / powerUpIndicators.Length);
            powerUpIndicators[i].gameObject.SetActive(false);
        }

        hasPowerUp = false;
    }
}
