using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace E2C
{
    public class E2ChartZoomControl : MonoBehaviour
    {
        public UnityAction<float> onZoom;

        public RectTransform rectTransform { get => (RectTransform)transform; }

        private float initialDistance;
        private float zoomSpeed = 0.01f; // Скорость масштабирования

        void Update()
        {
            if (onZoom == null) return;
            //HandleMouseScroll();
            HandleTouchScroll();
        }

        void HandleMouseScroll()
        {
            if (!Mathf.Approximately(Input.mouseScrollDelta.y, 0.0f))
                onZoom.Invoke(Input.mouseScrollDelta.y);
        }

        void HandleTouchScroll()
        {
            if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
                {
                    initialDistance = Vector2.Distance(touch1.position, touch2.position);
                }
                else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                    float deltaDistance = currentDistance - initialDistance;

                    // Умножьте deltaDistance на zoomSpeed и передайте его в onZoom.Invoke()
                    float scaledDelta = deltaDistance * zoomSpeed;
                    onZoom.Invoke(scaledDelta);

                    initialDistance = currentDistance;
                }
            }
        }
    }
}