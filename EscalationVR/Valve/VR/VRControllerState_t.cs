using System;

namespace Valve.VR
{
	// Token: 0x02000079 RID: 121
	public struct VRControllerState_t
	{
		// Token: 0x0400042A RID: 1066
		public uint unPacketNum;

		// Token: 0x0400042B RID: 1067
		public ulong ulButtonPressed;

		// Token: 0x0400042C RID: 1068
		public ulong ulButtonTouched;

		// Token: 0x0400042D RID: 1069
		public global::Valve.VR.VRControllerAxis_t rAxis0;

		// Token: 0x0400042E RID: 1070
		public global::Valve.VR.VRControllerAxis_t rAxis1;

		// Token: 0x0400042F RID: 1071
		public global::Valve.VR.VRControllerAxis_t rAxis2;

		// Token: 0x04000430 RID: 1072
		public global::Valve.VR.VRControllerAxis_t rAxis3;

		// Token: 0x04000431 RID: 1073
		public global::Valve.VR.VRControllerAxis_t rAxis4;
	}
}
