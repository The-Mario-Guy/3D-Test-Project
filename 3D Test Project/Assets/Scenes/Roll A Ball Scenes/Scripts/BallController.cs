using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    private Rigidbody _playerRigidBody;
    public float forceMultiplier;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI shadowCountText;
    public GameObject winTextObject;
    public GameObject winTextObjectShadow;

    private int count;


    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
        count = 0;
        winTextObject.SetActive(false);
        winTextObjectShadow.SetActive(false);

       // SetCountText ();
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

            count = count + 1;
            SetCountText();
            SetShadowCountText();

        }
        void SetCountText()
        {
            countText.text = count.ToString();

            if (count == 8)
            {
                // Set the text value of your 'winText'
                winTextObject.SetActive(true);
                StartCoroutine(Timer());
            }

        }
        void SetShadowCountText()
        {
            shadowCountText.text = count.ToString();

            if (count == 8)
            {
                winTextObjectShadow.SetActive(true);
            }
        }

    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
