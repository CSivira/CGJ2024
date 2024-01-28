using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    public Rigidbody2D theRb;

    public float moveSpeed = 5f;

    private Vector2 _moveInput;
    private Vector2 _mouseInput;

    public float mouseSensitivity = 1f;

    public Camera viewCam;

    public GameObject bulletImpact;

    [SerializeField] private Cooldown cooldown;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveHorizontal = transform.up * -_moveInput.x;
        Vector3 moveVertical = transform.right * _moveInput.y;

        theRb.velocity = (moveHorizontal + moveVertical) * moveSpeed;
        
        //player view control
        _mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - _mouseInput.x);
        // viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, _mouseInput.y, 0f));
        
        if (cooldown.IsCoolingDown) return;
        //shooting
        if (Input.GetMouseButton(0))
        {
            
            Ray ray = viewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("I'm looking at "+ hit.transform.name);
                if (hit.transform.tag == "Enemy")
                {
                    Instantiate(bulletImpact, hit.point, transform.rotation);
                    hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                    cooldown.StartCoolDown();
                }
            }
            /*else
            {
                Debug.Log("I'm looking at nothing");
            }*/
        }
    }
}
