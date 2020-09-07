using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x0200001C RID: 28
	public struct IVRExtendedDisplay
	{
		// Token: 0x040000F9 RID: 249
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRExtendedDisplay._GetWindowBounds GetWindowBounds;

		// Token: 0x040000FA RID: 250
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRExtendedDisplay._GetEyeOutputViewport GetEyeOutputViewport;

		// Token: 0x040000FB RID: 251
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRExtendedDisplay._GetDXGIOutputInfo GetDXGIOutputInfo;

		// Token: 0x02000135 RID: 309
		// (Invoke) Token: 0x06000757 RID: 1879
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _GetWindowBounds(ref int pnX, ref int pnY, ref uint pnWidth, ref uint pnHeight);

		// Token: 0x02000136 RID: 310
		// (Invoke) Token: 0x0600075B RID: 1883
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _GetEyeOutputViewport(global::Valve.VR.EVREye eEye, ref uint pnX, ref uint pnY, ref uint pnWidth, ref uint pnHeight);

		// Token: 0x02000137 RID: 311
		// (Invoke) Token: 0x0600075F RID: 1887
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _GetDXGIOutputInfo(ref int pnAdapterIndex, ref int pnAdapterOutputIndex);
	}
}
