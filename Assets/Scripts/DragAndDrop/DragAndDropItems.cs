using System.Collections;
using Events;
using UnityEngine;

namespace DragAndDrop
{
    public class DragAndDropItems : MonoBehaviour
    {
        [SerializeField] private float _returnSpeed = 5f; // Скорость возвращения объекта на место.

        private Vector3 _initialPosition;
        private Vector3 _mousePos;
        private bool _isDragging = false;

        private void Awake()
        {
            GlobalEvents.OnStartDraggingFalse.AddListener(DraggingDisabled);
        }

        private void Start()
        {
            _initialPosition = transform.position;
        }

        private void DraggingDisabled()
        {
            _isDragging = false;
        }

        private Vector3 GetMousePos()
        {
            return Camera.main.WorldToScreenPoint(transform.position);
        }

        private void OnMouseDown()
        {
            _isDragging = true;
            _mousePos = Input.mousePosition - GetMousePos();
        }

        private void OnMouseDrag()
        {
            if (_isDragging)
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePos);
                transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            }
        }

        private void OnMouseUp()
        {
            _isDragging = false;
            StartCoroutine(ReturnToInitialPosition());
        }

        private IEnumerator ReturnToInitialPosition()
        {
            GetComponent<SphereCollider>().enabled = false;
            float elapsedTime = 0f;
            Vector3 currentPosition = transform.position;

            while (elapsedTime < 1f)
            {
                transform.position = Vector3.Lerp(currentPosition, _initialPosition, elapsedTime);
                elapsedTime += Time.deltaTime * _returnSpeed;
                yield return null;
            }

            transform.position = _initialPosition;
            GetComponent<SphereCollider>().enabled = true;
        }

        private void OnDestroy()
        {
            GlobalEvents.OnStartDraggingFalse.RemoveListener(DraggingDisabled);
        }
    }
}