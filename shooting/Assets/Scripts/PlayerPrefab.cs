using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody bulletPrefab;
    private bool gunFlag = true;
    public int force;
    public float gunSpeed;
    public float camSpeed;
    public Transform wall; // parent for all bricks --> wall
    void Start()
    {
        StartCoroutine(setGunFlag());
    }

    //coroutine for controlling the gunFlag according the gunSpeed
    IEnumerator setGunFlag()
    {
        while(true)
        {
            float gunDelay = gunSpeed>0 ? 1/gunSpeed : 1;
            Time.timeScale = 1; //normal time. if set time.timescale = 0; --> almost all frozen
            gunFlag = true;
            yield return new WaitForSeconds(gunDelay);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //we still check if the "Fire1" (left ctrl by default according project settings) is pressed --> we will create an instance of bullet and put some force in z direction

        if(Input.GetButton("Fire1") == true && gunFlag)
        {
            gunFlag = false;
            // 1) instance of a bullet, position: same as camera, rotation 0
            Rigidbody bulletRB = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // 2) add force in z direction
            Vector3 dir = Vector3.forward;
            bulletRB.AddForce(dir * force, ForceMode.Impulse);
        }
    }

    // code for moving the camera
    // a good place for that is LateUpdate() event which will be called by unity engine AFTER the screen has been rendered
    private void LateUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical"); //(-1,1)
        const float z = 0;
        Vector3 trans = new Vector3(x, y, z);
        transform.Translate(trans * camSpeed);

    }
}
