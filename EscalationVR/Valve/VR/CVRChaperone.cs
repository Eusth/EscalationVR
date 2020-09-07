using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x02000028 RID: 40
	public class CVRChaperone
	{
		// Token: 0x0600014F RID: 335 RVA: 0x0000BC27 File Offset: 0x00009E27
		internal CVRChaperone(global::System.IntPtr pInterface)
		{
			this.FnTable = (global::Valve.VR.IVRChaperone)global::System.Runtime.InteropServices.Marshal.PtrToStructure(pInterface, typeof(global::Valve.VR.IVRChaperone));
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000BC4C File Offset: 0x00009E4C
		public global::Valve.VR.ChaperoneCalibrationState GetCalibrationState()
		{
			return this.FnTable.GetCalibrationState();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000BC70 File Offset: 0x00009E70
		public bool GetPlayAreaSize(ref float pSizeX, ref float pSizeZ)
		{
			pSizeX = 0f;
			pSizeZ = 0f;
			return this.FnTable.GetPlayAreaSize(ref pSizeX, ref pSizeZ);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000BCA4 File Offset: 0x00009EA4
		public bool GetPlayAreaRect(ref global::Valve.VR.HmdQuad_t rect)
		{
			return this.FnTable.GetPlayAreaRect(ref rect);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000BCC9 File Offset: 0x00009EC9
		public void ReloadInfo()
		{
			this.FnTable.ReloadInfo();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000BCDD File Offset: 0x00009EDD
		public void SetSceneColor(global::Valve.VR.HmdColor_t color)
		{
			this.FnTable.SetSceneColor(color);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000BCF2 File Offset: 0x00009EF2
		public void GetBoundsColor(ref global::Valve.VR.HmdColor_t pOutputColorArray, int nNumOutputColors, float flCollisionBoundsFadeDistance, ref global::Valve.VR.HmdColor_t pOutputCameraColor)
		{
			this.FnTable.GetBoundsColor(ref pOutputColorArray, nNumOutputColors, flCollisionBoundsFadeDistance, ref pOutputCameraColor);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000BD0C File Offset: 0x00009F0C
		public bool AreBoundsVisible()
		{
			return this.FnTable.AreBoundsVisible();
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000BD30 File Offset: 0x00009F30
		public void ForceBoundsVisible(bool bForce)
		{
			this.FnTable.ForceBoundsVisible(bForce);
		}

		// Token: 0x040001B0 RID: 432
		private global::Valve.VR.IVRChaperone FnTable;
	}
}
