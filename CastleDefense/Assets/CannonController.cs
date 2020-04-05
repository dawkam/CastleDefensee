using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    public GameObject Cannon;
    public float rotationRotater = 1;
    public float rotationCannon = 1;
    public float xU=0.85f;
    public float xD=0.55f;
    // Start is called before the first frame update
    void Start()
    {
        Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
       
    }

    void Rotate()
    {
       

        if (Input.GetKey("a") && this.transform.rotation.y < 0.85)
        {
            this.transform.Rotate(new Vector3(0, -rotationRotater, 0));

        }
        else if (Input.GetKey("d") && this.transform.rotation.y > 0.55)
        {
            this.transform.Rotate(new Vector3(0, rotationRotater, 0));

        }

        Debug.Log(Cannon.transform.rotation.x);
        if (Input.GetKey("w") && Cannon.transform.rotation.x > xU)
        {
            Cannon.transform.Rotate(new Vector3(-rotationCannon, 0, 0));

        }
        else if (Input.GetKey("s") && Cannon.transform.rotation.x <xD)
        {
            Cannon.transform.Rotate(new Vector3(rotationCannon, 0, 0));

        }


    }
}
