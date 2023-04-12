using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel.Cameras
{
    public class Planet3Camera : MonoBehaviour
    {

        #region Variables
        public Transform m_Target;

        [SerializeField]
        public float m_Height = 20f;

        [SerializeField]
        public float m_Distance = 5f;

        [SerializeField]
        public float m_Angle = 0f;

        [SerializeField]
        public float m_SmoothSpeed = 0.5f;

        private Vector3 refVelocity;

        float oldHeight = 0;


        #endregion


        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {
            HandleCamera();
        }

        // Update is called once per frame
        void Update()
        {
            HandleCamera();

        }
        #endregion

        #region Helper Methods
        protected virtual void HandleCamera()
        {
            if (!m_Target)
            {
                return;
            }

            /*
            float newHeight = Mathf.Clamp(m_Target.position.y + 2f, 2f, 5f);

            if (m_Target.position.y > oldHeight)
            {
                m_Height = 1 + Mathf.Round(m_Target.position.y);
                oldHeight = m_Height;
            }*/


            // Build World position vector
            Vector3 heightVector3 = Vector3.up * m_Height;
            //heightVector3.y += m_Target.position.y;
            Vector3 worldPosition = (Vector3.forward * -m_Distance) + (heightVector3);
            Debug.DrawLine(m_Target.position, worldPosition, Color.red);

            // Build our Rotated Vector
            Vector3 rotatedVector = worldPosition;
            Debug.DrawLine(m_Target.position, rotatedVector, Color.green);

            // Move our position
            Vector3 flatTargetPosition = m_Target.position;



            flatTargetPosition.y = 0f;


            Vector3 finalPosition = flatTargetPosition + rotatedVector;
            Debug.DrawLine(m_Target.position, finalPosition, Color.blue);

            Vector3 finaly = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_SmoothSpeed);
            finaly.z = m_Target.position.z - m_Distance;
            transform.position = finaly;
            transform.LookAt(flatTargetPosition);

            transform.Rotate(m_Angle, 0, 0);
        }
        #endregion
    }
}
