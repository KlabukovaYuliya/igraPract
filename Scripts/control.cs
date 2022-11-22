using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    public CharacterController controller; //переменная типа компонента CharacterController
    public float speedMove = 15f; //переменная отвечает за скорость движения вперёд-назад
    public float speedRotation = 100f; //переменная отвечает за скорость поворота по сторонам, когдабудем двигать мышь вправо-влево
    public Text countText, winText;//переменная для хранения компонента текст
    private int count, count1;//переменная в которую записывает число собранных кубиков
    void Start()
    {
        count = 0;
        count1 = 30;
        winText.text = " ";
        setCount();
        Cursor.visible = false;//отключаем видимость курсора
        Cursor.lockState = CursorLockMode.Locked;//ставим курсор по центру
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)//метод проверки находится ли объект на земле
        {
            float vertical = Input.GetAxis("Vertical");//создаём переменную для которой записываем метод проверки нажатия клавиш движения вперёд-назад
            float mouse = Input.GetAxis("Mouse X"); //переменная в которую записывается вращение мыши вправо-влево
            if (vertical != 0)//проверка движения по вертикали
            {
                controller.Move(transform.forward * vertical*speedMove*Time.deltaTime);//Move-это метод для движения персонажа встроенный в компоненте CharacterController
            }
            if (mouse!=0)//проверка поворота мыши
            {
                transform.Rotate(transform.up * mouse * speedRotation * Time.deltaTime);
            }
        }
        controller.Move(Physics.gravity * Time.deltaTime);
 
                }
    void OnTriggerEnter(Collider other)//функция которая срабатывает при касании объектов с включенным триггером у коллайдера
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
        countText.text = "Собрано блоков: " + count.ToString() +
            "\nОсталось: " + count1.ToString();
        if (count >= 30)
            winText.text = "Вы собрали все блоки!";
    }
}
