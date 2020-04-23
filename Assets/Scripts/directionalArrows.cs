using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionalArrows : MonoBehaviour
{
    private Animator anim;
    public Movement movement;
    public GameObject miles;
    public GameObject cameraFollowObject;
    public Transform originalPosition;
    public float speed;
    //public bool cameraMove = true;
    public MoveSegment moveSegment;

    // Start is called before the first frame update
    void Start()
    {
        miles = GameObject.Find("MilesNewWorking");
        movement = miles.GetComponent<Movement>();
        anim = GetComponent<Animator>();
        originalPosition = cameraFollowObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("a") || Input.GetAxis("Horizontal") < 0) /*&& cameraMove*/)
        {
            cameraFollowObject.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            CameraLimiter();
        }

        if ((Input.GetKey("d") || Input.GetAxis("Horizontal") > 0) /*&& cameraMove*/)
        {
            cameraFollowObject.transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            CameraLimiter();
        }

        if ((Input.GetKey("w") || Input.GetAxis("Vertical") > 0) /*&& cameraMove*/)
        {
            cameraFollowObject.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            CameraLimiter();
        }

        if ((Input.GetKey("s") || Input.GetAxis("Vertical") < 0) /*&& cameraMove*/)
        {
            cameraFollowObject.transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            CameraLimiter();
        }

        if (Input.GetKey("q") || Input.GetButtonDown("Fire1"))
        {
            cameraFollowObject.transform.localPosition = new Vector3(0, 0, 0);
            foreach (GameObject sprites in movement.MilesSprites)
            {
                sprites.GetComponent<SpriteRenderer>().enabled = true;
            }
            movement.isLocked = false;
            movement.MilesFrontWalk.enabled = true;
            movement.MilesBackWalk.enabled = true;
            moveSegment.isLocked = false;
            moveSegment.vcam.m_Lens.FieldOfView = moveSegment.originalPosition;
            gameObject.SetActive(false);
        }

        if (Input.GetKey("e") || Input.GetButtonDown("Fire6"))
        {
            cameraFollowObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void ResetAndDestroy()
    {
        cameraFollowObject.transform.localPosition = new Vector3(originalPosition.position.x, originalPosition.position.y, originalPosition.position.z);
        gameObject.SetActive(false);
    }

    public void CameraLimiter()
    {
        cameraFollowObject.transform.localPosition = new Vector2(Mathf.Clamp(cameraFollowObject.transform.localPosition.x, -200, 200),
        Mathf.Clamp(cameraFollowObject.transform.localPosition.y, -50, 50));
    }
}
