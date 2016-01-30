using UnityEngine;
using System.Collections;

public class Enemy_Collision : MonoBehaviour
{
    public Transform TargetA;
    public Transform TargetB;

    bool m_Collision = false, m_TargetA = true, m_TargetB = false;
    public float m_Speed, m_StartingRot;
    float m_Rotation;
    int m_NewTarget = 1;

    IEnumerator OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.name != "Player") {
            if ((m_TargetA && m_NewTarget == 1) || (m_TargetB && m_NewTarget == 2))
            {
                //Rotates the object 180 degrees
                if (m_TargetA && m_StartingRot <= 180)
                    m_Rotation = m_StartingRot + 180.0f;
                else if (m_TargetA && m_StartingRot > 180)
                    m_Rotation = m_StartingRot - 180.0f;
                else if (m_TargetB && m_Rotation <= 180)
                    m_Rotation = m_Rotation + 180.0f;
                else if (m_TargetB && m_Rotation > 180)
                    m_Rotation = m_Rotation - 180.0f;
            }
            //Starts Collision 
            m_Collision = true;

            //Swaps the Target Around
            if (m_TargetA && m_NewTarget == 1)
            {
                m_TargetA = false;
                m_TargetB = true;
            }
            else if (m_TargetB && m_NewTarget == 2)
            {
                m_TargetB = false;
                m_TargetA = true;
            }
            //Wait for 1 Second
            yield return new WaitForSeconds(1);
            //End Collision
            m_Collision = false;
            //Rotate 
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, m_Rotation);
            //Set Target Checker
            ChangeTarget();
        }
    }

    void Update()
    {
        //Movement when Collision == false
        //checks 3 values
        if (m_Collision == false && m_TargetA && m_NewTarget == 1)
            transform.position = Vector3.MoveTowards(transform.position, TargetA.position, m_Speed * Time.deltaTime);
        else if (m_Collision == false && m_TargetB && m_NewTarget == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetB.position, m_Speed * Time.deltaTime);
        }

    }

    void ChangeTarget()
    {
        //changes the value 
        if (m_NewTarget == 1) //Target A
            m_NewTarget = 2;
        else if (m_NewTarget == 2) //Target B
            m_NewTarget = 1;
    }


}
