using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x02000059 RID: 89
	[global::System.Runtime.InteropServices.StructLayout(2)]
	public struct VREvent_Data_t
	{
		// Token: 0x040003A7 RID: 935
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_Reserved_t reserved;

		// Token: 0x040003A8 RID: 936
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_Controller_t controller;

		// Token: 0x040003A9 RID: 937
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_Mouse_t mouse;

		// Token: 0x040003AA RID: 938
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_Scroll_t scroll;

		// Token: 0x040003AB RID: 939
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_Process_t process;

		// Token: 0x040003AC RID: 940
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_Notification_t notification;

		// Token: 0x040003AD RID: 941
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_Overlay_t overlay;

		// Token: 0x040003AE RID: 942
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_Status_t status;

		// Token: 0x040003AF RID: 943
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_Ipd_t ipd;

		// Token: 0x040003B0 RID: 944
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_Chaperone_t chaperone;

		// Token: 0x040003B1 RID: 945
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_PerformanceTest_t performanceTest;

		// Token: 0x040003B2 RID: 946
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_TouchPadMove_t touchPadMove;

		// Token: 0x040003B3 RID: 947
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_SeatedZeroPoseReset_t seatedZeroPoseReset;

		// Token: 0x040003B4 RID: 948
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::Valve.VR.VREvent_Keyboard_t keyboard;
	}
}
