using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (FieldOfView))]
public class FieldOfViewEditor : Editor {

	void OnSceneGUI() {
		FieldOfView fow = (FieldOfView)target;
		Handles.color = Color.white;
		Handles.DrawWireArc (fow.transform.position, Vector3.up, Vector3.forward, 360, fow.GetRadius());
		Vector3 viewAngleA = fow.DirFromAngle (-fow.GetAngle() / 2, false);
		Vector3 viewAngleB = fow.DirFromAngle (fow.GetAngle() / 2, false);

		Handles.DrawLine (fow.transform.position, fow.transform.position + viewAngleA * fow.GetRadius());
		Handles.DrawLine (fow.transform.position, fow.transform.position + viewAngleB * fow.GetRadius());

        // draw ray for visible targets
		Handles.color = Color.red;
		foreach (Transform visibleTarget in fow.GetTargets()) {
			Handles.DrawLine (fow.transform.position, visibleTarget.position);
		}

        // draw ray for visible obstacles
        Handles.color = Color.green;
        foreach (Transform visibleTarget in fow.GetNearbyObstacles(true))
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }

        // draw ray for non visible, nearby obstacles
        Handles.color = Color.yellow;
        foreach (Transform visibleTarget in fow.GetNearbyObstacles(false))
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
    }

}
