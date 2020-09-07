using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x02000024 RID: 36
	public struct IVRSettings
	{
		// Token: 0x040001A1 RID: 417
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._GetSettingsErrorNameFromEnum GetSettingsErrorNameFromEnum;

		// Token: 0x040001A2 RID: 418
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._Sync Sync;

		// Token: 0x040001A3 RID: 419
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._GetBool GetBool;

		// Token: 0x040001A4 RID: 420
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._SetBool SetBool;

		// Token: 0x040001A5 RID: 421
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._GetInt32 GetInt32;

		// Token: 0x040001A6 RID: 422
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._SetInt32 SetInt32;

		// Token: 0x040001A7 RID: 423
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._GetFloat GetFloat;

		// Token: 0x040001A8 RID: 424
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._SetFloat SetFloat;

		// Token: 0x040001A9 RID: 425
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._GetString GetString;

		// Token: 0x040001AA RID: 426
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._SetString SetString;

		// Token: 0x040001AB RID: 427
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._RemoveSection RemoveSection;

		// Token: 0x040001AC RID: 428
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSettings._RemoveKeyInSection RemoveKeyInSection;

		// Token: 0x020001DD RID: 477
		// (Invoke) Token: 0x060009F7 RID: 2551
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::System.IntPtr _GetSettingsErrorNameFromEnum(global::Valve.VR.EVRSettingsError eError);

		// Token: 0x020001DE RID: 478
		// (Invoke) Token: 0x060009FB RID: 2555
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _Sync(bool bForce, ref global::Valve.VR.EVRSettingsError peError);

		// Token: 0x020001DF RID: 479
		// (Invoke) Token: 0x060009FF RID: 2559
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetBool(string pchSection, string pchSettingsKey, bool bDefaultValue, ref global::Valve.VR.EVRSettingsError peError);

		// Token: 0x020001E0 RID: 480
		// (Invoke) Token: 0x06000A03 RID: 2563
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetBool(string pchSection, string pchSettingsKey, bool bValue, ref global::Valve.VR.EVRSettingsError peError);

		// Token: 0x020001E1 RID: 481
		// (Invoke) Token: 0x06000A07 RID: 2567
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate int _GetInt32(string pchSection, string pchSettingsKey, int nDefaultValue, ref global::Valve.VR.EVRSettingsError peError);

		// Token: 0x020001E2 RID: 482
		// (Invoke) Token: 0x06000A0B RID: 2571
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetInt32(string pchSection, string pchSettingsKey, int nValue, ref global::Valve.VR.EVRSettingsError peError);

		// Token: 0x020001E3 RID: 483
		// (Invoke) Token: 0x06000A0F RID: 2575
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate float _GetFloat(string pchSection, string pchSettingsKey, float flDefaultValue, ref global::Valve.VR.EVRSettingsError peError);

		// Token: 0x020001E4 RID: 484
		// (Invoke) Token: 0x06000A13 RID: 2579
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetFloat(string pchSection, string pchSettingsKey, float flValue, ref global::Valve.VR.EVRSettingsError peError);

		// Token: 0x020001E5 RID: 485
		// (Invoke) Token: 0x06000A17 RID: 2583
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _GetString(string pchSection, string pchSettingsKey, string pchValue, uint unValueLen, string pchDefaultValue, ref global::Valve.VR.EVRSettingsError peError);

		// Token: 0x020001E6 RID: 486
		// (Invoke) Token: 0x06000A1B RID: 2587
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetString(string pchSection, string pchSettingsKey, string pchValue, ref global::Valve.VR.EVRSettingsError peError);

		// Token: 0x020001E7 RID: 487
		// (Invoke) Token: 0x06000A1F RID: 2591
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _RemoveSection(string pchSection, ref global::Valve.VR.EVRSettingsError peError);

		// Token: 0x020001E8 RID: 488
		// (Invoke) Token: 0x06000A23 RID: 2595
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _RemoveKeyInSection(string pchSection, string pchSettingsKey, ref global::Valve.VR.EVRSettingsError peError);
	}
}
