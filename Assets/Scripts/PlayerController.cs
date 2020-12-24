using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1500f;
    public int health = 5;
    private int score = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("a"))
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("d"))
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("w"))
            rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("s"))
            rb.AddForce(0, 0, -speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Pickup"))
        {
            Debug.Log($"Score: {++score}");
            Destroy(other.gameObject);
        }

        if (other.GetComponent<Collider>().CompareTag("Trap"))
            Debug.Log($"Health: {--health}");

        if (other.GetComponent<Collider>().CompareTag("Goal"))
            Debug.Log("You win!");
    }
}
