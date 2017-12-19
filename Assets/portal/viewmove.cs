using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewmove : MonoBehaviour {
    public Transform player;
    public float speed;
    public float viewCamWeak;   // 传送门相机视角旋转速度衰减
    public Camera viewCam;  //传送门上的摄像机
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float movex = Input.GetAxis("Mouse X");
        float movey = Input.GetAxis("Mouse Y");
        player.eulerAngles += new Vector3(-movey * Time.deltaTime * speed,movex * Time.deltaTime * speed ,0);
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += player.transform.forward * Time.deltaTime * 10;
        }


        viewCam.transform.eulerAngles += new Vector3(-movey * Time.deltaTime * speed * viewCamWeak, movex * Time.deltaTime * speed * viewCamWeak, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "rr")
        {
            // print("send!");
            player.position = viewCam.transform.position;
            player.eulerAngles = viewCam.transform.eulerAngles;
        }
    }
}
