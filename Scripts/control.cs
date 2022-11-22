using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    public CharacterController controller; //���������� ���� ���������� CharacterController
    public float speedMove = 15f; //���������� �������� �� �������� �������� �����-�����
    public float speedRotation = 100f; //���������� �������� �� �������� �������� �� ��������, ���������� ������� ���� ������-�����
    public Text countText, winText;//���������� ��� �������� ���������� �����
    private int count, count1;//���������� � ������� ���������� ����� ��������� �������
    void Start()
    {
        count = 0;
        count1 = 30;
        winText.text = " ";
        setCount();
        Cursor.visible = false;//��������� ��������� �������
        Cursor.lockState = CursorLockMode.Locked;//������ ������ �� ������
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)//����� �������� ��������� �� ������ �� �����
        {
            float vertical = Input.GetAxis("Vertical");//������ ���������� ��� ������� ���������� ����� �������� ������� ������ �������� �����-�����
            float mouse = Input.GetAxis("Mouse X"); //���������� � ������� ������������ �������� ���� ������-�����
            if (vertical != 0)//�������� �������� �� ���������
            {
                controller.Move(transform.forward * vertical*speedMove*Time.deltaTime);//Move-��� ����� ��� �������� ��������� ���������� � ���������� CharacterController
            }
            if (mouse!=0)//�������� �������� ����
            {
                transform.Rotate(transform.up * mouse * speedRotation * Time.deltaTime);
            }
        }
        controller.Move(Physics.gravity * Time.deltaTime);
 
                }
    void OnTriggerEnter(Collider other)//������� ������� ����������� ��� ������� �������� � ���������� ��������� � ����������
    {
        if (other.tag == "Cube")
        {
            Destroy(other.gameObject);
            count++;
            count1--;
            setCount();
        }
    }
    void setCount()
    {
        countText.text = "������� ������: " + count.ToString() +
            "\n��������: " + count1.ToString();
        if (count >= 30)
            winText.text = "�� ������� ��� �����!";
    }
}
