using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Valve.VR
{
	// Token: 0x02000029 RID: 41
	public class CVRChaperoneSetup
	{
		// Token: 0x06000158 RID: 344 RVA: 0x0000BD45 File Offset: 0x00009F45
		internal CVRChaperoneSetup(global::System.IntPtr pInterface)
		{
			this.FnTable = (global::Valve.VR.IVRChaperoneSetup)global::System.Runtime.InteropServices.Marshal.PtrToStructure(pInterface, typeof(global::Valve.VR.IVRChaperoneSetup));
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000BD6C File Offset: 0x00009F6C
		public bool CommitWorkingCopy(global::Valve.VR.EChaperoneConfigFile configFile)
		{
			return this.FnTable.CommitWorkingCopy(configFile);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000BD91 File Offset: 0x00009F91
		public void RevertWorkingCopy()
		{
			this.FnTable.RevertWorkingCopy();
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000BDA8 File Offset: 0x00009FA8
		public bool GetWorkingPlayAreaSize(ref float pSizeX, ref float pSizeZ)
		{
			pSizeX = 0f;
			pSizeZ = 0f;
			return this.FnTable.GetWorkingPlayAreaSize(ref pSizeX, ref pSizeZ);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000BDDC File Offset: 0x00009FDC
		public bool GetWorkingPlayAreaRect(ref global::Valve.VR.HmdQuad_t rect)
		{
			return this.FnTable.GetWorkingPlayAreaRect(ref rect);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000BE04 File Offset: 0x0000A004
		public bool GetWorkingCollisionBoundsInfo(out global::Valve.VR.HmdQuad_t[] pQuadsBuffer)
		{
			uint num = 0U;
			bool flag = this.FnTable.GetWorkingCollisionBoundsInfo(null, ref num);
			pQuadsBuffer = new global::Valve.VR.HmdQuad_t[num];
			return this.FnTable.GetWorkingCollisionBoundsInfo(pQuadsBuffer, ref num);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000BE4C File Offset: 0x0000A04C
		public bool GetLiveCollisionBoundsInfo(out global::Valve.VR.HmdQuad_t[] pQuadsBuffer)
		{
			uint num = 0U;
			bool flag = this.FnTable.GetLiveCollisionBoundsInfo(null, ref num);
			pQuadsBuffer = new global::Valve.VR.HmdQuad_t[num];
			return this.FnTable.GetLiveCollisionBoundsInfo(pQuadsBuffer, ref num);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000BE94 File Offset: 0x0000A094
		public bool GetWorkingSeatedZeroPoseToRawTrackingPose(ref global::Valve.VR.HmdMatrix34_t pmatSeatedZeroPoseToRawTrackingPose)
		{
			return this.FnTable.GetWorkingSeatedZeroPoseToRawTrackingPose(ref pmatSeatedZeroPoseToRawTrackingPose);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000BEBC File Offset: 0x0000A0BC
		public bool GetWorkingStandingZeroPoseToRawTrackingPose(ref global::Valve.VR.HmdMatrix34_t pmatStandingZeroPoseToRawTrackingPose)
		{
			return this.FnTable.GetWorkingStandingZeroPoseToRawTrackingPose(ref pmatStandingZeroPoseToRawTrackingPose);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000BEE1 File Offset: 0x0000A0E1
		public void SetWorkingPlayAreaSize(float sizeX, float sizeZ)
		{
			this.FnTable.SetWorkingPlayAreaSize(sizeX, sizeZ);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000BEF7 File Offset: 0x0000A0F7
		public void SetWorkingCollisionBoundsInfo(global::Valve.VR.HmdQuad_t[] pQuadsBuffer)
		{
			this.FnTable.SetWorkingCollisionBoundsInfo(pQuadsBuffer, (uint)pQuadsBuffer.Length);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000BF0F File Offset: 0x0000A10F
		public void SetWorkingSeatedZeroPoseToRawTrackingPose(ref global::Valve.VR.HmdMatrix34_t pMatSeatedZeroPoseToRawTrackingPose)
		{
			this.FnTable.SetWorkingSeatedZeroPoseToRawTrackingPose(ref pMatSeatedZeroPoseToRawTrackingPose);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000BF24 File Offset: 0x0000A124
		public void SetWorkingStandingZeroPoseToRawTrackingPose(ref global::Valve.VR.HmdMatrix34_t pMatStandingZeroPoseToRawTrackingPose)
		{
			this.FnTable.SetWorkingStandingZeroPoseToRawTrackingPose(ref pMatStandingZeroPoseToRawTrackingPose);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000BF39 File Offset: 0x0000A139
		public void ReloadFromDisk(global::Valve.VR.EChaperoneConfigFile configFile)
		{
			this.FnTable.ReloadFromDisk(configFile);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000BF50 File Offset: 0x0000A150
		public bool GetLiveSeatedZeroPoseToRawTrackingPose(ref global::Valve.VR.HmdMatrix34_t pmatSeatedZeroPoseToRawTrackingPose)
		{
			return this.FnTable.GetLiveSeatedZeroPoseToRawTrackingPose(ref pmatSeatedZeroPoseToRawTrackingPose);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000BF75 File Offset: 0x0000A175
		public void SetWorkingCollisionBoundsTagsInfo(byte[] pTagsBuffer)
		{
			this.FnTable.SetWorkingCollisionBoundsTagsInfo(pTagsBuffer, (uint)pTagsBuffer.Length);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000BF90 File Offset: 0x0000A190
		public bool GetLiveCollisionBoundsTagsInfo(out byte[] pTagsBuffer)
		{
			uint num = 0U;
			bool flag = this.FnTable.GetLiveCollisionBoundsTagsInfo(null, ref num);
			pTagsBuffer = new byte[num];
			return this.FnTable.GetLiveCollisionBoundsTagsInfo(pTagsBuffer, ref num);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000BFD8 File Offset: 0x0000A1D8
		public bool SetWorkingPhysicalBoundsInfo(global::Valve.VR.HmdQuad_t[] pQuadsBuffer)
		{
			return this.FnTable.SetWorkingPhysicalBoundsInfo(pQuadsBuffer, (uint)pQuadsBuffer.Length);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000C000 File Offset: 0x0000A200
		public bool GetLivePhysicalBoundsInfo(out global::Valve.VR.HmdQuad_t[] pQuadsBuffer)
		{
			uint num = 0U;
			bool flag = this.FnTable.GetLivePhysicalBoundsInfo(null, ref num);
			pQuadsBuffer = new global::Valve.VR.HmdQuad_t[num];
			return this.FnTable.GetLivePhysicalBoundsInfo(pQuadsBuffer, ref num);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000C048 File Offset: 0x0000A248
		public bool ExportLiveToBuffer(global::System.Text.StringBuilder pBuffer, ref uint pnBufferLength)
		{
			pnBufferLength = 0U;
			return this.FnTable.ExportLiveToBuffer(pBuffer, ref pnBufferLength);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000C074 File Offset: 0x0000A274
		public bool ImportFromBufferToWorking(string pBuffer, uint nImportFlags)
		{
			return this.FnTable.ImportFromBufferToWorking(pBuffer, nImportFlags);
		}

		// Token: 0x040001B1 RID: 433
		private global::Valve.VR.IVRChaperoneSetup FnTable;
	}
}
