using System;
using UnityEngine;
using VRGIN.Core;

namespace VRGIN.Helpers
{
	// Token: 0x020000D2 RID: 210
	public static class Calculator
	{
		// Token: 0x0600053E RID: 1342 RVA: 0x0001A774 File Offset: 0x00018974
		public static float Distance(float worldValue)
		{
			return worldValue / global::VRGIN.Core.VR.Settings.IPDScale * global::VRGIN.Core.VR.Context.UnitToMeter;
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0001A7A0 File Offset: 0x000189A0
		public static float Angle(global::UnityEngine.Vector3 v1, global::UnityEngine.Vector3 v2)
		{
			float num = global::UnityEngine.Mathf.Atan2(v1.x, v1.z) * 57.29578f;
			float num2 = global::UnityEngine.Mathf.Atan2(v2.x, v2.z) * 57.29578f;
			return global::UnityEngine.Mathf.DeltaAngle(num, num2);
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0001A7EC File Offset: 0x000189EC
		public static global::UnityEngine.Vector3 GetForwardVector(global::UnityEngine.Quaternion rotation)
		{
			global::UnityEngine.Vector3 vector = rotation * global::UnityEngine.Vector3.forward;
			global::UnityEngine.Vector3 vector2 = vector.WithY(0f);
			bool flag = (double)vector2.magnitude < 0.3;
			global::UnityEngine.Vector3 result;
			if (flag)
			{
				bool flag2 = vector.y > 0f;
				if (flag2)
				{
					result = (rotation * global::UnityEngine.Vector3.down).WithY(0f).normalized;
				}
				else
				{
					result = (rotation * global::UnityEngine.Vector3.up).WithY(0f).normalized;
				}
			}
			else
			{
				bool flag3 = global::UnityEngine.Vector3.Dot(global::UnityEngine.Vector3.up, rotation * global::UnityEngine.Vector3.up) < 0f;
				if (flag3)
				{
					result = -vector2.normalized;
				}
				else
				{
					result = vector2.normalized;
				}
			}
			return result;
		}
	}
}
