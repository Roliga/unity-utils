#if (UNITY_EDITOR)
using UnityEngine;
using UnityEditor;
 
namespace UnityUtils
{
    [ExecuteAlways]
    public class AlignCameraWithSceneView : MonoBehaviour
    {
        public Camera gameCam;
        public bool enable = false;
        private void OnRenderObject()
        {
            if (enable && gameCam != null)
            {
                SceneView sceneCam = SceneView.lastActiveSceneView;
                gameCam.transform.position = sceneCam.camera.transform.position;
                gameCam.transform.rotation = sceneCam.camera.transform.rotation;
            }
        }
    }
}
#endif