using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CameraController : MonoBehaviour
{
    [SerializeField] public float panSpeed = 30f;
    [SerializeField] public float panBorder = 10f;
    [SerializeField] public float scrollSpeed = 3f;
    [SerializeField] public float minY = 10f;
    [SerializeField] public float maxY = 80f;

    private bool canMove = true;

    void Update()
    {
        if(SC_GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = !canMove;
        }

        if(!canMove)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorder)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

    }
}
