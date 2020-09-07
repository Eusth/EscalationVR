using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x0200006B RID: 107
	public struct VREvent_TouchPadMove_t
	{
		// Token: 0x04000405 RID: 1029
		[global::System.Runtime.InteropServices.MarshalAs(3)]
		public bool bFingerDown;

		// Token: 0x04000406 RID: 1030
		public float flSecondsFingerDown;

		// Token: 0x04000407 RID: 1031
		public float fValueXFirst;

		// Token: 0x04000408 RID: 1032
		public float fValueYFirst;

		// Token: 0x04000409 RID: 1033
		public float fValueXRaw;

		// Token: 0x0400040A RID: 1034
		public float fValueYRaw;
	}
}
