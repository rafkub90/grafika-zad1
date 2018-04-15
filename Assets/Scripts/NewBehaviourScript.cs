using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    public float speed;
    public Rigidbody rb;
    private int count;
    public Text countText;
    public Text WinText;

    // Use this for initialization
    void Start () {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        WinText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        else
        {
            other.gameObject.SetActive(false);
            count += 2;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = " Wynik: " + count.ToString();
        if (count == 10)
        {
            WinText.text = "Wygrana";
        }

    }
}
