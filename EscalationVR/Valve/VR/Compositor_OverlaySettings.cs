using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x0200007A RID: 122
	public struct Compositor_OverlaySettings
	{
		// Token: 0x04000432 RID: 1074
		public uint size;

		// Token: 0x04000433 RID: 1075
		[global::System.Runtime.InteropServices.MarshalAs(3)]
		public bool curved;

		// Token: 0x04000434 RID: 1076
		[global::System.Runtime.InteropServices.MarshalAs(3)]
		public bool antialias;

		// Token: 0x04000435 RID: 1077
		public float scale;

		// Token: 0x04000436 RID: 1078
		public float distance;

		// Token: 0x04000437 RID: 1079
		public float alpha;

		// Token: 0x04000438 RID: 1080
		public float uOffset;

		// Token: 0x04000439 RID: 1081
		public float vOffset;

		// Token: 0x0400043A RID: 1082
		public float uScale;

		// Token: 0x0400043B RID: 1083
		public float vScale;

		// Token: 0x0400043C RID: 1084
		public float gridDivs;

		// Token: 0x0400043D RID: 1085
		public float gridWidth;

		// Token: 0x0400043E RID: 1086
		public float gridScale;

		// Token: 0x0400043F RID: 1087
		public global::Valve.VR.HmdMatrix44_t transform;
	}
}
