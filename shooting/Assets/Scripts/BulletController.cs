using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(checkFalling));
    }

    // create a coroutine (thread) called once per seccond
    // coroutines:
    // - return type: IEnumerator
    // - usually contains infinite loop
    // - in infinite loop
    //  * some code for checking something etc
    //  * finally a sleep wait call to unity engine: yield return new WaitForSeconds(time)
    public IEnumerator checkFalling()
    {
        while(true)
        {
            // transform is the connected game objects Transform component
            if(transform.position.y <= -0.75f)
            {
                // when we want to destroy a game object we can use "gameObject"
                // --> the whole game object will be removed
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    // Update is called once per frame
    //we could put periodic checking to Update() but it takes too much computing resources...

}
