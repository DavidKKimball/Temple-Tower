using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOnAwakeLevelThree : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    anim.Play("exitSign");        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
