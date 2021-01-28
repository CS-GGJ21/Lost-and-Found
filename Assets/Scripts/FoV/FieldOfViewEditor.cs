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

		Handles.color = Color.red;
		foreach (Transform visibleTarget in fow.GetTargets()) {
			Handles.DrawLine (fow.transform.position, visibleTarget.position);
		}
	}

}
