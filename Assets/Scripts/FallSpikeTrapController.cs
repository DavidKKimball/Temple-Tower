using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpikeTrapController : MonoBehaviour
{
    public Animator anim;
    public float waitTime;
    private bool reload = true;
    public bool level5 = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && reload == true)
        {
            reload = false;
            if(level5)
            anim.Play("FallSpikeTrapGoDownLevel5");
            else
            {
                anim.Play("FallSpikeTrapGoDown");
            }
            StartCoroutine(Wait());
        }       
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        // moves down
        reload = true;
    }
    public void switchThis()
    {
        if(level5)
        level5 = false;
        if(!level5)
        level5 = true;
    }
}
