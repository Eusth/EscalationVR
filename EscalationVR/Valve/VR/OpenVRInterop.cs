using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x0200002F RID: 47
	public class OpenVRInterop
	{
		// Token: 0x060001EF RID: 495
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "VR_InitInternal")]
		internal static extern uint InitInternal(ref global::Valve.VR.EVRInitError peError, global::Valve.VR.EVRApplicationType eApplicationType);

		// Token: 0x060001F0 RID: 496
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "VR_ShutdownInternal")]
		internal static extern void ShutdownInternal();

		// Token: 0x060001F1 RID: 497
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "VR_IsHmdPresent")]
		internal static extern bool IsHmdPresent();

		// Token: 0x060001F2 RID: 498
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "VR_IsRuntimeInstalled")]
		internal static extern bool IsRuntimeInstalled();

		// Token: 0x060001F3 RID: 499
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "VR_GetStringForHmdError")]
		internal static extern global::System.IntPtr GetStringForHmdError(global::Valve.VR.EVRInitError error);

		// Token: 0x060001F4 RID: 500
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "VR_GetGenericInterface")]
		internal static extern global::System.IntPtr GetGenericInterface([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.MarshalAs(20)] string pchInterfaceVersion, ref global::Valve.VR.EVRInitError peError);

		// Token: 0x060001F5 RID: 501
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "VR_IsInterfaceVersionValid")]
		internal static extern bool IsInterfaceVersionValid([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.MarshalAs(20)] string pchInterfaceVersion);

		// Token: 0x060001F6 RID: 502
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "VR_GetInitToken")]
		internal static extern uint GetInitToken();
	}
}
