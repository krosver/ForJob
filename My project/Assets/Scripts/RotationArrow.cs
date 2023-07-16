using UnityEngine;
using UnityEngine.EventSystems;

public class RotationArrow : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private float speed;
    private Vector2 mousePos;
    private Vector2 objPos;
    private Vector2 direction;
    private Vector2 currentDir;

    public delegate void onMoveArrow(Transform arrow);
    public static event onMoveArrow OnMoveArrow;

    private bool onClickDown;
    void Update()
    {
        if (Input.touchCount > 0 && onClickDown)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            objPos = transform.position;

            direction = mousePos - objPos;
            direction.Normalize();

            currentDir = Vector2.Lerp(currentDir, direction, speed);
            transform.up = currentDir;
            OnMoveArrow?.Invoke(transform);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        onClickDown = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        onClickDown = false;
    }
}
