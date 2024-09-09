using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

        void Update()
    {
     // we sill check if the "Fire1" (left ctrl by default according project settings)
     // is pressed --> we will create an instance of bullet and put some force
     // in z direction
     if(Input.GetButton("Fire1") == true)
     {
        // 1) instance of a bullet, position: same as camera, rotation (0,0,0)
        Rigidbody bulletRB = Instantiate(bulletPrefab, transform.position, Quaternion.identity /*no rotation*/);
        // 2) add force to the bullet in z direction
     }

    }
}
