using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float m_Speed;

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * m_Speed;
    }
}
