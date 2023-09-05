using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class BallController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    public float Gravity;
    private Rigidbody _playerRigidBody;
    public float forceMultiplier;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI shadowCountText;
    public GameObject winTextObject;
   // public GameObject winTextObjectShadow;

    private int count;


    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
        count = 0;
        winTextObject.SetActive(false);
        //winTextObjectShadow.SetActive(false);

       // SetCountText ();
    }

    void Update()
    {
        

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, Gravity, verticalInput);

        _playerRigidBody.AddForce(movement * forceMultiplier);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;
            SetCountText();
            SetShadowCountText();

        }
        if (other.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            void SetCountText()
        {
            countText.text = count.ToString();


            if (count == 10)
            {
                // Set the text value of your 'winText'
                winTextObject.SetActive(true);
                // StartCoroutine(Timer());
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

        }
        void SetShadowCountText()
        {
            shadowCountText.text = count.ToString();
        }

    }
   
}
