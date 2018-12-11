using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Text UI and the 3D Logo")]
    public Text scoreMenu;
    public GameObject logo3D;

	void Start()
    {
        if (PlayerPrefs.HasKey("score"))
            scoreMenu.text = "Last Score: " + PlayerPrefs.GetInt("score").ToString();
        else scoreMenu.text = "Last Score: 0";
    }

    void Update()
    {
        logo3D.transform.Rotate(0, 20 * Time.deltaTime, 0);   
    }
}
