using UnityEngine;

public class Objects : MonoBehaviour
{
    [Header("Floor Scroll")]
    public Material floor;
    public float scrollSpeed;

    [Header("Objects to be spawned")]
    public float speed;
    public GameObject fence;
    public GameObject cloud;
    public GameObject rock;
    public GameObject pipes;

    [Header("Positions to spawn objects")]
    public Vector3 fencePosition;
    public Vector3 cloudPosition;
    public Vector3 rocksPosition;

    [Header("Pipes Configuration")]
    public float XPosition;
    public int randomYMax;
    public int randomYMin;

    // Invoke Repeating will help in simple stuff, but try not to use soo much, find another alternatives like Delegates or Fire Rate.
    void Start()
    {
        InvokeRepeating("CreateFence", 1f, 2.9f);
        InvokeRepeating("CreateCloud", 1f, 2.5f);
        InvokeRepeating("CreateRocks", 1f, 2f);
        InvokeRepeating("CreatePipes", 1f, 2f);
    }

    private void CreateFence()
    {
        GameObject newfence = Instantiate(fence);
        newfence.transform.parent = this.transform;
        newfence.transform.position = fencePosition;
        newfence.GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.Force);
        Destroy(newfence, 5f);
    }

    private void CreateCloud()
    {
        GameObject newcloud = Instantiate(cloud);
        newcloud.transform.parent = this.transform;
        newcloud.transform.position = cloudPosition;
        newcloud.GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.Force);
        Destroy(newcloud, 4f);
    }

    private void CreateRocks()
    {
        GameObject newrock = Instantiate(rock);
        newrock.transform.parent = this.transform;
        newrock.transform.position = rocksPosition;
        newrock.GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.Force);
        Destroy(newrock, 4f);
    }

    private void CreatePipes()
    {
        GameObject newpipes = Instantiate(pipes);
        newpipes.transform.parent = this.transform;
        newpipes.transform.position = new Vector3(XPosition, Random.Range(randomYMin, randomYMax), 0);
        newpipes.GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.Force);
        Destroy(newpipes, 4f);
    }
}
