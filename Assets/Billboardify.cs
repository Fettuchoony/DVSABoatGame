using UnityEngine;

public class Billboardify : MonoBehaviour
{

    public GameObject playerCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currAngle = transform.eulerAngles;
        transform.LookAt(playerCam.transform.position);
        transform.forward = -transform.forward;
    }
}
