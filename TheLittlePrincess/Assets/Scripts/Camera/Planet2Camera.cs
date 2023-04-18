using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel.Cameras
{
    public class Planet2Camera : MonoBehaviour
    {

        #region Variables
        
        private int targetCount = 0;

        [SerializeField]
        public Transform m_Target1;
        [SerializeField]
        public Transform m_Target2;
        [SerializeField]
        
        public Transform m_Target3;
        
        private List<Transform> targets;
        
        private Transform m_MainTarget;

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
            targets = new List<Transform>();
            targets.Add(m_Target1);
            targets.Add(m_Target2);
            targets.Add(m_Target3);
            m_MainTarget = m_Target1;
            HandleCamera();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                switch (targetCount)
                {
                    case 0:
                    case 1:
                        targetCount++;
                        break;
                    case 2:
                        targetCount = 0;
                        break;
                }
            }
            m_MainTarget = targets[targetCount];
            HandleCamera();
        }
        #endregion

        #region Helper Methods
        protected virtual void HandleCamera()
        {
            if (!m_MainTarget)
            {
                return;
            }

            // Build World position vector
            Vector3 worldPosition = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
            Debug.DrawLine(m_MainTarget.position, worldPosition, Color.red);

            // Build our Rotated Vector
            Vector3 rotatedVector = worldPosition;
            Debug.DrawLine(m_MainTarget.position, rotatedVector, Color.green);

            // Move our position
            Vector3 flatTargetPosition = m_MainTarget.position;



            flatTargetPosition.y = 0f;


            Vector3 finalPosition = flatTargetPosition + rotatedVector;
            Debug.DrawLine(m_MainTarget.position, finalPosition, Color.blue);

            Vector3 finaly = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_SmoothSpeed);
            finaly.z = m_MainTarget.position.z - m_Distance;
            transform.position = finaly;
            transform.LookAt(flatTargetPosition);

            transform.Rotate(m_Angle, 0, 0);
        }
        #endregion
    }
}
