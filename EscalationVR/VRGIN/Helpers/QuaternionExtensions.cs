using System;
using UnityEngine;

namespace VRGIN.Helpers
{
	// Token: 0x020000DD RID: 221
	public static class QuaternionExtensions
	{
		// Token: 0x0600058C RID: 1420 RVA: 0x0001B928 File Offset: 0x00019B28
		public static global::UnityEngine.Vector3 WithY(this global::UnityEngine.Vector3 self, float y)
		{
			return new global::UnityEngine.Vector3(self.x, y, self.z);
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0001B94C File Offset: 0x00019B4C
		public static global::UnityEngine.Vector3 WithX(this global::UnityEngine.Vector3 self, float x)
		{
			return new global::UnityEngine.Vector3(x, self.y, self.z);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0001B970 File Offset: 0x00019B70
		public static global::UnityEngine.Vector3 WithZ(this global::UnityEngine.Vector3 self, float z)
		{
			return new global::UnityEngine.Vector3(self.x, self.y, z);
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0001B994 File Offset: 0x00019B94
		public static global::UnityEngine.Vector3 ToPitchYawRollRad(this global::UnityEngine.Quaternion rotation)
		{
			float num = global::UnityEngine.Mathf.Atan2(2f * rotation.y * rotation.w - 2f * rotation.x * rotation.z, 1f - 2f * rotation.y * rotation.y - 2f * rotation.z * rotation.z);
			float num2 = global::UnityEngine.Mathf.Atan2(2f * rotation.x * rotation.w - 2f * rotation.y * rotation.z, 1f - 2f * rotation.x * rotation.x - 2f * rotation.z * rotation.z);
			float num3 = global::UnityEngine.Mathf.Asin(2f * rotation.x * rotation.y + 2f * rotation.z * rotation.w);
			return new global::UnityEngine.Vector3(num2, num3, num);
		}
	}
}
