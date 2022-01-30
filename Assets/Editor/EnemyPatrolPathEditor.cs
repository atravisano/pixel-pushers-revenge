using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
namespace Platformer
{
    [CustomEditor(typeof(EnemyController))]
    public class EnemyPatrolPathGizmo : Editor
    {
        public void OnSceneGUI()
        {
            var path = target as EnemyController;
            using (var cc = new EditorGUI.ChangeCheckScope())
            {
                var sp = path.transform.InverseTransformPoint(Handles.PositionHandle(path.transform.TransformPoint(new Vector3(path.startPosition, 0, 0)), path.transform.rotation));
                var ep = path.transform.InverseTransformPoint(Handles.PositionHandle(path.transform.TransformPoint(new Vector3(path.endPosition, 0, 0)), path.transform.rotation));
                
                if (cc.changed)
                {
                    sp.y = 0;
                    ep.y = 0;

                    path.startPosition = sp.x;
                    path.endPosition = ep.x;

                    EditorUtility.SetDirty(target);
                }
            }
        }

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        static void OnDrawGizmo(EnemyController path, GizmoType gizmoType)
        {
            if (path.patrol)
            {
                var start = path.transform.TransformPoint(new Vector2(path.startPosition, 0));
                var end = path.transform.TransformPoint(new Vector2(path.endPosition, 0));
                Handles.color = Color.yellow;
                Handles.DrawDottedLine(start, end, 5);
                Handles.DrawSolidDisc(start, path.transform.forward, 0.1f);
                Handles.DrawSolidDisc(end, path.transform.forward, 0.1f);
            }
        }
    }
}
