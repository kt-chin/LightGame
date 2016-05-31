using UnityEngine;
using System.Collections;

public class controlScript : MonoBehaviour {
    private Transform wallTransform1;
    private Transform wallTransform2;
    private Transform wallTransform3;
    private Transform wallTransform4;
    public GameObject bullet;
    public GameObject laserPoint;
    private int num;
	// Use this for initialization
	void Start () {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        wallTransform1 = GameObject.Find("Wall1").GetComponent<Transform>();
        wallTransform2 = GameObject.Find("Wall2").GetComponent<Transform>();
        wallTransform3 = GameObject.Find("Wall3").GetComponent<Transform>();
        wallTransform4 = GameObject.Find("Wall4").GetComponent<Transform>();
        //Vector3 spawnPos = laserPoint.transform.position + laserPoint.transform.forward * laserPoint.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            num = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            num = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            num = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            num = 4;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!GameObject.FindGameObjectWithTag("Bullet"))
            {
                GameObject bulletClone = Instantiate(bullet, laserPoint.transform.position + laserPoint.transform.forward * 3, laserPoint.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody>().AddForce(laserPoint.transform.forward * 100);
            }
        }

        switch (num)
        {
            case 1:
                {
                    wallTransform1.Rotate(Time.deltaTime * Input.GetAxis("Horizontal") * Vector3.up * 20.0f);
                    break;
                }
            case 2:
                {
                    wallTransform2.Rotate(Time.deltaTime * Input.GetAxis("Horizontal") * Vector3.up * 20.0f);
                    break;
                }
            case 3:
                {
                    wallTransform3.Rotate(Time.deltaTime * Input.GetAxis("Horizontal") * Vector3.up * 20.0f);
                    break;
                }
            case 4:
                {
                    wallTransform4.Rotate(Time.deltaTime * Input.GetAxis("Horizontal") * Vector3.up * 20.0f);
                    break;
                }
        }


	}
}
