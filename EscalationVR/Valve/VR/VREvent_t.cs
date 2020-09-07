using System;

namespace Valve.VR
{
	// Token: 0x02000076 RID: 118
	public struct VREvent_t
	{
		// Token: 0x04000422 RID: 1058
		public uint eventType;

		// Token: 0x04000423 RID: 1059
		public uint trackedDeviceIndex;

		// Token: 0x04000424 RID: 1060
		public float eventAgeSeconds;

		// Token: 0x04000425 RID: 1061
		public global::Valve.VR.VREvent_Data_t data;
	}
}
