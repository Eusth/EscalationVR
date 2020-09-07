using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x02000026 RID: 38
	public class CVRExtendedDisplay
	{
		// Token: 0x06000132 RID: 306 RVA: 0x0000B78D File Offset: 0x0000998D
		internal CVRExtendedDisplay(global::System.IntPtr pInterface)
		{
			this.FnTable = (global::Valve.VR.IVRExtendedDisplay)global::System.Runtime.InteropServices.Marshal.PtrToStructure(pInterface, typeof(global::Valve.VR.IVRExtendedDisplay));
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000B7B2 File Offset: 0x000099B2
		public void GetWindowBounds(ref int pnX, ref int pnY, ref uint pnWidth, ref uint pnHeight)
		{
			pnX = 0;
			pnY = 0;
			pnWidth = 0U;
			pnHeight = 0U;
			this.FnTable.GetWindowBounds(ref pnX, ref pnY, ref pnWidth, ref pnHeight);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000B7D8 File Offset: 0x000099D8
		public void GetEyeOutputViewport(global::Valve.VR.EVREye eEye, ref uint pnX, ref uint pnY, ref uint pnWidth, ref uint pnHeight)
		{
			pnX = 0U;
			pnY = 0U;
			pnWidth = 0U;
			pnHeight = 0U;
			this.FnTable.GetEyeOutputViewport(eEye, ref pnX, ref pnY, ref pnWidth, ref pnHeight);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000B801 File Offset: 0x00009A01
		public void GetDXGIOutputInfo(ref int pnAdapterIndex, ref int pnAdapterOutputIndex)
		{
			pnAdapterIndex = 0;
			pnAdapterOutputIndex = 0;
			this.FnTable.GetDXGIOutputInfo(ref pnAdapterIndex, ref pnAdapterOutputIndex);
		}

		// Token: 0x040001AE RID: 430
		private global::Valve.VR.IVRExtendedDisplay FnTable;
	}
}
