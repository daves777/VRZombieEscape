using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIfGrabbed : MonoBehaviour
{
    private SimpleShoot simpleShoot;
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;
    
    public int damageAmount = 5;
    public float targetDistance;
    public float allowedRange = 15f;

    // Start is called before the first frame update
    void Start()
    {
        simpleShoot = GetComponent<SimpleShoot>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton))
        {
            simpleShoot.TriggerShoot();
            AudioSource gunsound = GetComponent<AudioSource>();
            gunsound.Play();
            RaycastHit shot;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                targetDistance = shot.distance;
                if (targetDistance < allowedRange)
                {
                    shot.transform.SendMessage("DeductPoints", damageAmount);
                }

            }
        }
    }
}
