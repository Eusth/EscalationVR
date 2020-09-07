using System;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class SteamVR_IK : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600007D RID: 125 RVA: 0x00005BB0 File Offset: 0x00003DB0
	private void LateUpdate()
	{
		bool flag = this.blendPct < 0.001f;
		if (!flag)
		{
			global::UnityEngine.Vector3 vector = this.upVector ? this.upVector.up : global::UnityEngine.Vector3.Cross(this.end.position - this.start.position, this.joint.position - this.start.position).normalized;
			global::UnityEngine.Vector3 position = this.target.position;
			global::UnityEngine.Quaternion rotation = this.target.rotation;
			global::UnityEngine.Vector3 position2 = this.joint.position;
			global::UnityEngine.Vector3 vector2;
			global::UnityEngine.Vector3 vector3;
			global::SteamVR_IK.Solve(this.start.position, position, this.poleVector.position, (this.joint.position - this.start.position).magnitude, (this.end.position - this.joint.position).magnitude, ref position2, out vector2, out vector3);
			bool flag2 = vector3 == global::UnityEngine.Vector3.zero;
			if (!flag2)
			{
				global::UnityEngine.Vector3 position3 = this.start.position;
				global::UnityEngine.Vector3 position4 = this.joint.position;
				global::UnityEngine.Vector3 position5 = this.end.position;
				global::UnityEngine.Quaternion localRotation = this.start.localRotation;
				global::UnityEngine.Quaternion localRotation2 = this.joint.localRotation;
				global::UnityEngine.Quaternion localRotation3 = this.end.localRotation;
				global::UnityEngine.Transform parent = this.start.parent;
				global::UnityEngine.Transform parent2 = this.joint.parent;
				global::UnityEngine.Transform parent3 = this.end.parent;
				global::UnityEngine.Vector3 localScale = this.start.localScale;
				global::UnityEngine.Vector3 localScale2 = this.joint.localScale;
				global::UnityEngine.Vector3 localScale3 = this.end.localScale;
				bool flag3 = this.startXform == null;
				if (flag3)
				{
					this.startXform = new global::UnityEngine.GameObject("startXform").transform;
					this.startXform.parent = base.transform;
				}
				this.startXform.position = position3;
				this.startXform.LookAt(this.joint, vector);
				this.start.parent = this.startXform;
				bool flag4 = this.jointXform == null;
				if (flag4)
				{
					this.jointXform = new global::UnityEngine.GameObject("jointXform").transform;
					this.jointXform.parent = this.startXform;
				}
				this.jointXform.position = position4;
				this.jointXform.LookAt(this.end, vector);
				this.joint.parent = this.jointXform;
				bool flag5 = this.endXform == null;
				if (flag5)
				{
					this.endXform = new global::UnityEngine.GameObject("endXform").transform;
					this.endXform.parent = this.jointXform;
				}
				this.endXform.position = position5;
				this.end.parent = this.endXform;
				this.startXform.LookAt(position2, vector3);
				this.jointXform.LookAt(position, vector3);
				this.endXform.rotation = rotation;
				this.start.parent = parent;
				this.joint.parent = parent2;
				this.end.parent = parent3;
				this.end.rotation = rotation;
				bool flag6 = this.blendPct < 1f;
				if (flag6)
				{
					this.start.localRotation = global::UnityEngine.Quaternion.Slerp(localRotation, this.start.localRotation, this.blendPct);
					this.joint.localRotation = global::UnityEngine.Quaternion.Slerp(localRotation2, this.joint.localRotation, this.blendPct);
					this.end.localRotation = global::UnityEngine.Quaternion.Slerp(localRotation3, this.end.localRotation, this.blendPct);
				}
				this.start.localScale = localScale;
				this.joint.localScale = localScale2;
				this.end.localScale = localScale3;
			}
		}
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00005FC0 File Offset: 0x000041C0
	public static bool Solve(global::UnityEngine.Vector3 start, global::UnityEngine.Vector3 end, global::UnityEngine.Vector3 poleVector, float jointDist, float targetDist, ref global::UnityEngine.Vector3 result, out global::UnityEngine.Vector3 forward, out global::UnityEngine.Vector3 up)
	{
		float num = jointDist + targetDist;
		global::UnityEngine.Vector3 vector = end - start;
		global::UnityEngine.Vector3 normalized = (poleVector - start).normalized;
		float magnitude = vector.magnitude;
		result = start;
		bool flag = magnitude < 0.001f;
		if (flag)
		{
			result += normalized * jointDist;
			forward = global::UnityEngine.Vector3.Cross(normalized, global::UnityEngine.Vector3.up);
			up = global::UnityEngine.Vector3.Cross(forward, normalized).normalized;
		}
		else
		{
			forward = vector * (1f / magnitude);
			up = global::UnityEngine.Vector3.Cross(forward, normalized).normalized;
			bool flag2 = magnitude + 0.001f < num;
			if (flag2)
			{
				float num2 = (num + magnitude) * 0.5f;
				bool flag3 = num2 > jointDist + 0.001f && num2 > targetDist + 0.001f;
				if (flag3)
				{
					float num3 = global::UnityEngine.Mathf.Sqrt(num2 * (num2 - jointDist) * (num2 - targetDist) * (num2 - magnitude));
					float num4 = 2f * num3 / magnitude;
					float num5 = global::UnityEngine.Mathf.Sqrt(jointDist * jointDist - num4 * num4);
					global::UnityEngine.Vector3 vector2 = global::UnityEngine.Vector3.Cross(up, forward);
					result += forward * num5 + vector2 * num4;
					return true;
				}
				result += normalized * jointDist;
			}
			else
			{
				result += forward * jointDist;
			}
		}
		return false;
	}

	// Token: 0x04000048 RID: 72
	public global::UnityEngine.Transform target;

	// Token: 0x04000049 RID: 73
	public global::UnityEngine.Transform start;

	// Token: 0x0400004A RID: 74
	public global::UnityEngine.Transform joint;

	// Token: 0x0400004B RID: 75
	public global::UnityEngine.Transform end;

	// Token: 0x0400004C RID: 76
	public global::UnityEngine.Transform poleVector;

	// Token: 0x0400004D RID: 77
	public global::UnityEngine.Transform upVector;

	// Token: 0x0400004E RID: 78
	public float blendPct = 1f;

	// Token: 0x0400004F RID: 79
	[global::UnityEngine.HideInInspector]
	public global::UnityEngine.Transform startXform;

	// Token: 0x04000050 RID: 80
	[global::UnityEngine.HideInInspector]
	public global::UnityEngine.Transform jointXform;

	// Token: 0x04000051 RID: 81
	[global::UnityEngine.HideInInspector]
	public global::UnityEngine.Transform endXform;
}
