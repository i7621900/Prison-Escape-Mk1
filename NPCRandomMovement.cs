using UnityEngine;
using System.Collections;

public class NPCRandomMovement : MonoBehaviour
{
    public Transform Player;
    float m_Speed = 2; 
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, m_Speed * Time.deltaTime);
    }
}
