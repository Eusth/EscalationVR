using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x02000066 RID: 102
	public struct TrackedDevicePose_t
	{
		// Token: 0x040003F4 RID: 1012
		public global::Valve.VR.HmdMatrix34_t mDeviceToAbsoluteTracking;

		// Token: 0x040003F5 RID: 1013
		public global::Valve.VR.HmdVector3_t vVelocity;

		// Token: 0x040003F6 RID: 1014
		public global::Valve.VR.HmdVector3_t vAngularVelocity;

		// Token: 0x040003F7 RID: 1015
		public global::Valve.VR.ETrackingResult eTrackingResult;

		// Token: 0x040003F8 RID: 1016
		[global::System.Runtime.InteropServices.MarshalAs(3)]
		public bool bPoseIsValid;

		// Token: 0x040003F9 RID: 1017
		[global::System.Runtime.InteropServices.MarshalAs(3)]
		public bool bDeviceIsConnected;
	}
}
