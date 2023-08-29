using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    private Rigidbody _playerRigidBody;
    public float forceMultiplier;
    public TextMeshProUGUI countText;

    private int count;


    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
        count = 0;
    }

    void Update()
    {
        

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        _playerRigidBody.AddForce(movement * forceMultiplier);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);

            count = count = 1;
        }
    }
}
