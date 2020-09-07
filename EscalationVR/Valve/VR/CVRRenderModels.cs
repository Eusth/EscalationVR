using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Valve.VR
{
	// Token: 0x0200002C RID: 44
	public class CVRRenderModels
	{
		// Token: 0x060001CF RID: 463 RVA: 0x0000CF12 File Offset: 0x0000B112
		internal CVRRenderModels(global::System.IntPtr pInterface)
		{
			this.FnTable = (global::Valve.VR.IVRRenderModels)global::System.Runtime.InteropServices.Marshal.PtrToStructure(pInterface, typeof(global::Valve.VR.IVRRenderModels));
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000CF38 File Offset: 0x0000B138
		public global::Valve.VR.EVRRenderModelError LoadRenderModel_Async(string pchRenderModelName, ref global::System.IntPtr ppRenderModel)
		{
			return this.FnTable.LoadRenderModel_Async(pchRenderModelName, ref ppRenderModel);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000CF5E File Offset: 0x0000B15E
		public void FreeRenderModel(global::System.IntPtr pRenderModel)
		{
			this.FnTable.FreeRenderModel(pRenderModel);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000CF74 File Offset: 0x0000B174
		public global::Valve.VR.EVRRenderModelError LoadTexture_Async(int textureId, ref global::System.IntPtr ppTexture)
		{
			return this.FnTable.LoadTexture_Async(textureId, ref ppTexture);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000CF9A File Offset: 0x0000B19A
		public void FreeTexture(global::System.IntPtr pTexture)
		{
			this.FnTable.FreeTexture(pTexture);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000CFB0 File Offset: 0x0000B1B0
		public global::Valve.VR.EVRRenderModelError LoadTextureD3D11_Async(int textureId, global::System.IntPtr pD3D11Device, ref global::System.IntPtr ppD3D11Texture2D)
		{
			return this.FnTable.LoadTextureD3D11_Async(textureId, pD3D11Device, ref ppD3D11Texture2D);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000CFD8 File Offset: 0x0000B1D8
		public global::Valve.VR.EVRRenderModelError LoadIntoTextureD3D11_Async(int textureId, global::System.IntPtr pDstTexture)
		{
			return this.FnTable.LoadIntoTextureD3D11_Async(textureId, pDstTexture);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000CFFE File Offset: 0x0000B1FE
		public void FreeTextureD3D11(global::System.IntPtr pD3D11Texture2D)
		{
			this.FnTable.FreeTextureD3D11(pD3D11Texture2D);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000D014 File Offset: 0x0000B214
		public uint GetRenderModelName(uint unRenderModelIndex, global::System.Text.StringBuilder pchRenderModelName, uint unRenderModelNameLen)
		{
			return this.FnTable.GetRenderModelName(unRenderModelIndex, pchRenderModelName, unRenderModelNameLen);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000D03C File Offset: 0x0000B23C
		public uint GetRenderModelCount()
		{
			return this.FnTable.GetRenderModelCount();
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000D060 File Offset: 0x0000B260
		public uint GetComponentCount(string pchRenderModelName)
		{
			return this.FnTable.GetComponentCount(pchRenderModelName);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000D088 File Offset: 0x0000B288
		public uint GetComponentName(string pchRenderModelName, uint unComponentIndex, global::System.Text.StringBuilder pchComponentName, uint unComponentNameLen)
		{
			return this.FnTable.GetComponentName(pchRenderModelName, unComponentIndex, pchComponentName, unComponentNameLen);
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000D0B4 File Offset: 0x0000B2B4
		public ulong GetComponentButtonMask(string pchRenderModelName, string pchComponentName)
		{
			return this.FnTable.GetComponentButtonMask(pchRenderModelName, pchComponentName);
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000D0DC File Offset: 0x0000B2DC
		public uint GetComponentRenderModelName(string pchRenderModelName, string pchComponentName, global::System.Text.StringBuilder pchComponentRenderModelName, uint unComponentRenderModelNameLen)
		{
			return this.FnTable.GetComponentRenderModelName(pchRenderModelName, pchComponentName, pchComponentRenderModelName, unComponentRenderModelNameLen);
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000D108 File Offset: 0x0000B308
		public bool GetComponentState(string pchRenderModelName, string pchComponentName, ref global::Valve.VR.VRControllerState_t pControllerState, ref global::Valve.VR.RenderModel_ControllerMode_State_t pState, ref global::Valve.VR.RenderModel_ComponentState_t pComponentState)
		{
			return this.FnTable.GetComponentState(pchRenderModelName, pchComponentName, ref pControllerState, ref pState, ref pComponentState);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000D134 File Offset: 0x0000B334
		public bool RenderModelHasComponent(string pchRenderModelName, string pchComponentName)
		{
			return this.FnTable.RenderModelHasComponent(pchRenderModelName, pchComponentName);
		}

		// Token: 0x040001B4 RID: 436
		private global::Valve.VR.IVRRenderModels FnTable;
	}
}
