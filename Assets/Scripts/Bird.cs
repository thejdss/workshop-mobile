using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public float flyForce;
    
    public int score;

    public GameObject canvas;

    public Text scoreText;

    public Rigidbody componentRigidbody;

    void Start()
    {
        componentRigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            componentRigidbody.velocity = Vector3.zero;
            componentRigidbody.AddForce(Vector3.up * flyForce, ForceMode.Impulse);
        }
    }

    void LateUpdate()
    {
        float speed = componentRigidbody.velocity.y;
        this.transform.rotation = Quaternion.Euler(0,180f, speed * -7);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kill"))
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
        }

        if (other.CompareTag("Score"))
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}