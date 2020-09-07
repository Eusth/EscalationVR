using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Valve.VR
{
	// Token: 0x02000022 RID: 34
	public struct IVRRenderModels
	{
		// Token: 0x04000190 RID: 400
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._LoadRenderModel_Async LoadRenderModel_Async;

		// Token: 0x04000191 RID: 401
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._FreeRenderModel FreeRenderModel;

		// Token: 0x04000192 RID: 402
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._LoadTexture_Async LoadTexture_Async;

		// Token: 0x04000193 RID: 403
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._FreeTexture FreeTexture;

		// Token: 0x04000194 RID: 404
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._LoadTextureD3D11_Async LoadTextureD3D11_Async;

		// Token: 0x04000195 RID: 405
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._LoadIntoTextureD3D11_Async LoadIntoTextureD3D11_Async;

		// Token: 0x04000196 RID: 406
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._FreeTextureD3D11 FreeTextureD3D11;

		// Token: 0x04000197 RID: 407
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._GetRenderModelName GetRenderModelName;

		// Token: 0x04000198 RID: 408
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._GetRenderModelCount GetRenderModelCount;

		// Token: 0x04000199 RID: 409
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._GetComponentCount GetComponentCount;

		// Token: 0x0400019A RID: 410
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._GetComponentName GetComponentName;

		// Token: 0x0400019B RID: 411
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._GetComponentButtonMask GetComponentButtonMask;

		// Token: 0x0400019C RID: 412
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._GetComponentRenderModelName GetComponentRenderModelName;

		// Token: 0x0400019D RID: 413
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._GetComponentState GetComponentState;

		// Token: 0x0400019E RID: 414
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRRenderModels._RenderModelHasComponent RenderModelHasComponent;

		// Token: 0x020001CC RID: 460
		// (Invoke) Token: 0x060009B3 RID: 2483
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRRenderModelError _LoadRenderModel_Async(string pchRenderModelName, ref global::System.IntPtr ppRenderModel);

		// Token: 0x020001CD RID: 461
		// (Invoke) Token: 0x060009B7 RID: 2487
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _FreeRenderModel(global::System.IntPtr pRenderModel);

		// Token: 0x020001CE RID: 462
		// (Invoke) Token: 0x060009BB RID: 2491
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRRenderModelError _LoadTexture_Async(int textureId, ref global::System.IntPtr ppTexture);

		// Token: 0x020001CF RID: 463
		// (Invoke) Token: 0x060009BF RID: 2495
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _FreeTexture(global::System.IntPtr pTexture);

		// Token: 0x020001D0 RID: 464
		// (Invoke) Token: 0x060009C3 RID: 2499
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRRenderModelError _LoadTextureD3D11_Async(int textureId, global::System.IntPtr pD3D11Device, ref global::System.IntPtr ppD3D11Texture2D);

		// Token: 0x020001D1 RID: 465
		// (Invoke) Token: 0x060009C7 RID: 2503
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRRenderModelError _LoadIntoTextureD3D11_Async(int textureId, global::System.IntPtr pDstTexture);

		// Token: 0x020001D2 RID: 466
		// (Invoke) Token: 0x060009CB RID: 2507
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _FreeTextureD3D11(global::System.IntPtr pD3D11Texture2D);

		// Token: 0x020001D3 RID: 467
		// (Invoke) Token: 0x060009CF RID: 2511
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetRenderModelName(uint unRenderModelIndex, global::System.Text.StringBuilder pchRenderModelName, uint unRenderModelNameLen);

		// Token: 0x020001D4 RID: 468
		// (Invoke) Token: 0x060009D3 RID: 2515
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetRenderModelCount();

		// Token: 0x020001D5 RID: 469
		// (Invoke) Token: 0x060009D7 RID: 2519
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetComponentCount(string pchRenderModelName);

		// Token: 0x020001D6 RID: 470
		// (Invoke) Token: 0x060009DB RID: 2523
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetComponentName(string pchRenderModelName, uint unComponentIndex, global::System.Text.StringBuilder pchComponentName, uint unComponentNameLen);

		// Token: 0x020001D7 RID: 471
		// (Invoke) Token: 0x060009DF RID: 2527
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate ulong _GetComponentButtonMask(string pchRenderModelName, string pchComponentName);

		// Token: 0x020001D8 RID: 472
		// (Invoke) Token: 0x060009E3 RID: 2531
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetComponentRenderModelName(string pchRenderModelName, string pchComponentName, global::System.Text.StringBuilder pchComponentRenderModelName, uint unComponentRenderModelNameLen);

		// Token: 0x020001D9 RID: 473
		// (Invoke) Token: 0x060009E7 RID: 2535
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetComponentState(string pchRenderModelName, string pchComponentName, ref global::Valve.VR.VRControllerState_t pControllerState, ref global::Valve.VR.RenderModel_ControllerMode_State_t pState, ref global::Valve.VR.RenderModel_ComponentState_t pComponentState);

		// Token: 0x020001DA RID: 474
		// (Invoke) Token: 0x060009EB RID: 2539
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _RenderModelHasComponent(string pchRenderModelName, string pchComponentName);
	}
}
