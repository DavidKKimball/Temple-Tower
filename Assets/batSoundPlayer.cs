using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batSoundPlayer : MonoBehaviour
{
    private AudioSource batSqueek;
    public float squeekDelay;
    // Start is called before the first frame update
    void Start()
    {
        batSqueek =  GetComponent<AudioSource>();
        StartCoroutine(batSqueekPlay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator batSqueekPlay()
    {
        yield return new WaitForSeconds(squeekDelay);
        batSqueek.Play();
    }
}
