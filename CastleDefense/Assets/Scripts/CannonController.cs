using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    public GameObject cannon;
    public Transform firePoint;
    public GameObject bullet;
    public float rotationRotater = 1;
    public float rotationCannon = 1;
    public float bulletPower;
    public float fireRate = 1.0f;
    private float _nextFire;


    // Start is called before the first frame update
    void Start()
    {
        Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Fire();
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

        if (Input.GetKey("w") && cannon.transform.rotation.x > -0.3)
        {
            cannon.transform.Rotate(new Vector3(-rotationCannon, 0, 0));

        }
        else if (Input.GetKey("s") && cannon.transform.rotation.x <0.1)
        {
            cannon.transform.Rotate(new Vector3(rotationCannon, 0, 0));

        }


    }

    void Fire() 
    {
        if (Input.GetKeyDown("x") && Time.time > _nextFire)
        {
            _nextFire = Time.time + fireRate;
            GameObject b = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody rb = b.GetComponent<Rigidbody>();
            rb.AddRelativeForce(new Vector3(0, 0, bulletPower));
        }
    }

}
