using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movecar : MonoBehaviour
{
    public Text busHealthText;
    public AudioClip horn;
    public GameObject student;


    public float turnSpeed = 100f;
    public Text studentsCollectedText;
    float busHealthValue = 50;
    public int studentsCollected = 0;
    public float pickupRadius = 25f;

    void Start()
    {
        busHealthText.text = "Health: " + busHealthValue;
        studentsCollectedText.text = "Students Collected: " + studentsCollected;
        GetComponent<AudioSource>().clip = horn;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 0.8f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -0.8f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0.8f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -0.8f, 0);
        }
        if(Input.GetKey(KeyCode.H))
        {
            GetComponent<AudioSource>().PlayOneShot(horn);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PickupStudents();
        }
        studentsCollectedText.text = "Students Collected: " + studentsCollected;


        Vector3 carpos = transform.position;
        if (carpos.z > 136)
        {
            carpos.z = -136;
            transform.position = carpos;
        }

        if (busHealthValue <= 0)
        {
            SceneManager.LoadScene("game_over");
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name.StartsWith("traffic"))
        {
            Debug.Log("there is collision");
            busHealthValue -= 10f;
            busHealthText.text = "Health: " + busHealthValue;

            if (busHealthValue <= 0)
            {
                SceneManager.LoadScene("game_over");
            }

        }


    }

    void PickupStudents()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Student"))
            {
                Destroy(hitCollider.gameObject);
                studentsCollected++;

                if (studentsCollected >= 30)
                {
                    SceneManager.LoadScene("win_scene");
                }
            }
        }
    }
}

