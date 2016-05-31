using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class bulletScript : MonoBehaviour
{
    public Transform origObject;
    public Transform reflectObject;
    // Use this for initialization
    Vector3 velocity;
    public float speed;

    void Start()
    {
        velocity = this.transform.forward;
        speed = 20;
    }


    void Update()
    {
        this.transform.position += velocity * Time.deltaTime * speed;
    }


    void OnCollisionEnter(Collision col)
    {
        //'Bounce' off surface
        if (col.gameObject.tag == "Mirror")
        {
            foreach (ContactPoint contact in col.contacts)
            {

                velocity = 2 * (Vector3.Dot(velocity, Vector3.Normalize(contact.normal))) * Vector3.Normalize(contact.normal) - velocity;
                velocity *= -1;
            }
        }
        else if (col.gameObject.tag == "Objective")
        {
          if(SceneManager.GetActiveScene().name == "MainScene1")
            {
                SceneManager.LoadScene("MainScene2");
            }
          else if (SceneManager.GetActiveScene().name == "MainScene2")
            {
                SceneManager.LoadScene("MainScene3");
            }
        }
        else
            Destroy(gameObject);
    }
}
