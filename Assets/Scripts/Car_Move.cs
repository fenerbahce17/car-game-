using UnityEngine;
using UnityEngine.InputSystem;
public class Car_Move : MonoBehaviour
{

        public float speed = 5f;

        private void Start() {


        }

        private void Update() {


                Move();
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


}
