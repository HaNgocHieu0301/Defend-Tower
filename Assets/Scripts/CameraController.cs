using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speedScroll = 1000f;
    public float speed = 20f;
    public float limitMoving = 20f;
    private float limitTop;
    private float limitBot;
    private float limitLeft;
    private float limitRight;
    private bool movement = true;
    // Start is called before the first frame update
    void Start()
    {
        limitTop = transform.position.z - limitMoving;
        limitBot = transform.position.z + limitMoving;
        limitRight = transform.position.x - limitMoving;
        limitLeft = transform.position.x + limitMoving;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.endGame)
        {
            this.enabled = false;
            return;
        }
        if (GameManager.endGame)
        {
            movement = !movement;
        }
        if (!movement)
        {
            return;
        }
        //di chuyen camera len xuong
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.back, Space.World);
        //di chuyen camera trai phai
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.left, Space.World);
        //scroll
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(scroll * speedScroll * Time.deltaTime * Vector3.down, Space.World);

        float posX = Mathf.Clamp(transform.position.x, limitRight, limitLeft);
        float posZ = Mathf.Clamp(transform.position.z, limitTop, limitBot);
        float posY = Mathf.Clamp(transform.position.y, transform.position.y - limitMoving, transform.position.y + limitMoving);

        transform.position = new Vector3(posX, posY, posZ);

        //Vector3 pos = transform.position;
        //float posY = pos.y;

        //pos.y -= scroll * 1000 * speedScroll * Time.deltaTime;
        //pos.y = Mathf.Clamp(pos.y, posY - limitMoving, posY + limitMoving);
    }
}
