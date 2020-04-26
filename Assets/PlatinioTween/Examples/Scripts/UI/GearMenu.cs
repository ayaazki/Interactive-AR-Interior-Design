using UnityEngine;
using Platinio.TweenEngine;
using Platinio.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;

namespace Platinio
{
    public class GearMenu : MonoBehaviour
    {
        [SerializeField] private EventSystem eventSystem;
        [SerializeField] private PhysicsRaycaster physicsRaycaster;
        [SerializeField] private float height = 0.05f;
        [SerializeField] private float gearRotation = 180.0f;
        [SerializeField] private RectTransform canvas = null;
        [SerializeField] private RectTransform hideMenu = null;
        [SerializeField] private RectTransform gearIcon = null;
      //  [SerializeField] private RectTransform backIcon = null;
        [SerializeField] private float time = 1.0f;
        [SerializeField] private Ease ease = Ease.Linear;
        [SerializeField] private List<RectTransform> hideList = new List<RectTransform>();
        [SerializeField] private List<float> heightList = new List<float>();

        private Vector2 startPosition = Vector2.zero;
        private Vector2 startPosition01 = Vector2.zero;
     //   private Vector3 startRotation = new Vector3();
        [HideInInspector] public bool isVisible = false;
        private bool isBusy = false;

        private void Start()
        {
            startPosition = hideMenu.FromAnchoredPositionToAbsolutePosition(canvas);
         //   startRotation = gearIcon.rotation.eulerAngles;
        }

        private void Show()
        {
            
            hideMenu.MoveUI(new Vector2(startPosition.x, startPosition.y + height), canvas, time).SetEase(ease);
            gearIcon.RotateTween(Vector3.forward, gearIcon.rotation.eulerAngles.z + gearRotation, time).SetEase(ease).SetOnComplete(delegate
            {
                isBusy = false;
                isVisible = true;
                eventSystem.enabled = true;
                physicsRaycaster.enabled = true;
            });


        }

        private void Hide()
        {
            hideMenu.MoveUI(new Vector2(startPosition.x, startPosition.y - height), canvas, time).SetEase(ease);

            gearIcon.RotateTween(Vector3.forward, gearIcon.rotation.eulerAngles.z - gearRotation, time).SetEase(ease).SetOnComplete(delegate
            {
                isBusy = false;
                isVisible = false;
                eventSystem.enabled = true;
                physicsRaycaster.enabled = true;
            });


        }

        public void Toggle()
        {
            //if (isBusy)
            //    return;

            //isBusy = true;
            //Debug.Log(isBusy);
            if (isVisible)
                HideCoroutine();
            else
                ShowCoroutine();
        }

        public void ShowCoroutine()
        {
            if (isBusy)
                return;

            isBusy = true;

            eventSystem.enabled = false;
            physicsRaycaster.enabled = false;

            StartCoroutine(ShowIconsSequence());
        }

        public void HideCoroutine()
        {
            if (isBusy)
                return;

            isBusy = true;

            eventSystem.enabled = false;
            physicsRaycaster.enabled = false;

            StartCoroutine(HideIconsSequence());
        }

        IEnumerator ShowIconsSequence()
        {
            for (int i = 0; i < hideList.Count; i++)
            {
                hideMenu = hideList[i];
                height = heightList[i];
                Show();
                yield return new WaitForSeconds(0.5f);
            }
 
        }
        IEnumerator HideIconsSequence()
        {
            for (int i = 0; i < hideList.Count; i++)
            {
                hideMenu = hideList[i];
                height = heightList[i];
                Hide();
                yield return new WaitForSeconds(0.5f);
            }

        }

    }

}

