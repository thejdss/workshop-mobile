using UnityEngine;

public class Objects : MonoBehaviour
{
    [Header("Objects Options")]
    public float speed;
    public GameObject fence;
    public GameObject rocks;
    public GameObject cloud;
    public GameObject pipes;

    [Header("Objects Positions")]
    public Vector3 fencePosition;
    public Vector3 rockPosition;
    public Vector3 cloudPosition;

    [Header("Pipes Options")]
    public float XPosition;
    public float YMax;
    public float YMin;

    void Start()
    {
        InvokeRepeating("CreateFence", 1f, 2.7f);
        InvokeRepeating("CreateRocks", 1f, 2.7f);
        InvokeRepeating("CreateCloud", 1f, 2.7f);
        InvokeRepeating("CreatePipes", 1f, 2.7f);
    }

    public void CreateFence()
    {
        GameObject newfence = Instantiate(fence);
        newfence.transform.parent = this.transform;
        newfence.transform.position = fencePosition;
        newfence.GetComponent<Rigidbody>().AddForce(Vector3.left * speed, ForceMode.Force);
        Destroy(newfence, 5f);
    }

    public void CreateRocks()
    {
        GameObject newRocks = Instantiate(rocks);
        newRocks.transform.parent = this.transform;
        newRocks.transform.position = rockPosition;
        newRocks.GetComponent<Rigidbody>().AddForce(Vector3.left * speed, ForceMode.Force);
        Destroy(newRocks, 5f);
    }

    public void CreateCloud()
    {
        GameObject newCloud = Instantiate(cloud);
        newCloud.transform.parent = this.transform;
        newCloud.transform.position = cloudPosition;
        newCloud.GetComponent<Rigidbody>().AddForce(Vector3.left * speed, ForceMode.Force);
        Destroy(newCloud, 5f);
    }

    public void CreatePipes()
    {
        GameObject newPipes = Instantiate(pipes);
        newPipes.transform.parent = this.transform;
        newPipes.transform.position = new Vector3(XPosition,Random.Range(YMin, YMax),0);
        newPipes.GetComponent<Rigidbody>().AddForce(Vector3.left * speed, ForceMode.Force);
        Destroy(newPipes, 5f);
    }
}