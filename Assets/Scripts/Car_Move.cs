using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.InputSystem;
public class Car_Move : MonoBehaviour
{

        public float speed = 5f;

        private void Start()
        {


        }

        private void Update()
        {


                Move();
                Turn();

        }

        public void Move()
        {

                if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                {
                        transform.Translate(speed * Time.deltaTime * Vector3.forward);
                }
                if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                {
                        transform.Translate(speed * Time.deltaTime * Vector3.back);
                }


        }
        Vector3 direction = Vector3.zero;
        public void Turn()
        {

                if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                {
                        direction = transform.right;
                }
                else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                {
                        direction = -Vector3.right;
                }
                else
                {
                        direction = Vector3.zero;
                }
            
                transform.Translate(direction * speed * Time.deltaTime);
       
        }
        


}
