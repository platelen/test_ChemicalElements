using UnityEngine;

namespace DragAndDrop
{
    public class DragAndDropItems : MonoBehaviour
    {
        private Vector3 _mousePos;

        private Vector3 GetMousePos()
        {
            return Camera.main.WorldToScreenPoint(transform.position);
        }

        private void OnMouseDown()
        {
            _mousePos = Input.mousePosition - GetMousePos();
        }

        private void OnMouseDrag()
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePos);
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Flask"))
            {
                // Обработка соприкосновения с объектом на слое Flask
                Debug.Log("Trigger Enter with Flask: " + other.gameObject.name);
            }
        }
    }
}