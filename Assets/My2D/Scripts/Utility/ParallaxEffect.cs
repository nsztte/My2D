using UnityEngine;

namespace My2D
{
    public class ParallaxEffect : MonoBehaviour
    {
        #region Variables
        public Camera m_camera;           //카메라
        public Transform followTarget;  //플레이어

        //시작 위치
        private Vector2 startingPoint;  //시작 위치(배경, 카메라)
        private float startingZ;        //시작할때 배경의 z축 위치값

        //시작지점으로부터 카메라가 있는 위치까지의 거리
        private Vector2 CamMoveSinceStart => startingPoint - (Vector2)m_camera.transform.position;

        //배경과 플레이어와의 z축 거리 
        private float zDistanceFromTarget => transform.position.z - followTarget.position.z;

        //
        private float ClippingPlane => m_camera.transform.position.z + (zDistanceFromTarget > 0 ? m_camera.farClipPlane : m_camera.nearClipPlane);
        //시차 거리 factor
        private float ParallaxFactor => Mathf.Abs(zDistanceFromTarget) / ClippingPlane;
        #endregion

        private void Start()
        {
            //초기화
            startingPoint = transform.position;
            startingZ = transform.position.z;
        }

        private void Update()
        {
            Vector2 newPosition = startingPoint + CamMoveSinceStart * ParallaxFactor;
            transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
        }
    }
}