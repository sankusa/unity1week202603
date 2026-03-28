using R3;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShirohataLabo.u1w202603
{
    public class ClickChecker : MonoBehaviour
    {
        readonly Subject<Unit> _onClickSubject = new();
        public Observable<Unit> OnClick => _onClickSubject;

        void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

                // if (Physics.Raycast(ray, out var hit))
                // {
                //     Debug.Log(hit.collider.gameObject);
                // }

                var hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit && hit.collider.gameObject == gameObject)
                {
                    _onClickSubject.OnNext(Unit.Default);
                    Debug.Log("Clicked:" + gameObject.name);
                }
            }
        }
    }
}