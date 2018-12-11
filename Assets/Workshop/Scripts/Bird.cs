using UnityEngine.UI;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody componentRigidibody;

    [Header("Character Options")]
    public float flyForce;

    [Header("Game Options")]
    public GameObject endPanel;
    public Text scoreGame;
    public int score;

    [Header("Particles")]
    public GameObject spawnParticle;
    public GameObject flyParticle;
    public GameObject dieParticle;

    [Header("Sound Effects")]
    public AudioSource flySound;
    public AudioSource scoreSound;
    public AudioSource dieSound;
    
    void Awake()
    {
        componentRigidibody = this.gameObject.GetComponent<Rigidbody>(); // It takes the need to use GetComponent for the whole code and it is only necessary this time.
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            componentRigidibody.velocity = Vector3.zero; // Reset the velocity of the bird.
            componentRigidibody.AddForce(Vector3.up * flyForce, ForceMode.Impulse); // Aplly a force impulse in the Y axis.
            Instantiate(flyParticle, spawnParticle.transform.position, spawnParticle.transform.rotation); // Spawn the particle stored in flyParticle.
            flySound.Play();
        }
    }

    void LateUpdate()
    {
        float speed = this.GetComponent<Rigidbody>().velocity.y; // Get the velocity in the Y axis.
        this.transform.rotation = Quaternion.Euler(0, 180f, speed * -7); // Use the velocity stored in speed to rotate the character.
    }

    void OnTriggerEnter(Collider other)
    {
        // When hit the Score Box Collider.
        if (other.gameObject.CompareTag("Score"))
        {
            score++;
            scoreSound.Play();
            scoreGame.text = score.ToString();
        }
         
        // When hit the Kill Box Collider.
        if (other.gameObject.CompareTag("Kill"))
        {
            PlayerPrefs.SetInt("score", score); // Save the score when die.
            dieSound.Play();
            Instantiate(dieParticle, spawnParticle.transform.position, spawnParticle.transform.rotation);
            endPanel.SetActive(true);
            this.gameObject.SetActive(false);
            Time.timeScale = 0;
        }

    }
}
