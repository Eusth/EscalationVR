using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x0200006D RID: 109
	public struct VREvent_Process_t
	{
		// Token: 0x0400040D RID: 1037
		public uint pid;

		// Token: 0x0400040E RID: 1038
		public uint oldPid;

		// Token: 0x0400040F RID: 1039
		[global::System.Runtime.InteropServices.MarshalAs(3)]
		public bool bForced;
	}
}
