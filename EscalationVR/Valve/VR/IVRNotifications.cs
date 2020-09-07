using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x02000023 RID: 35
	public struct IVRNotifications
	{
		// Token: 0x0400019F RID: 415
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRNotifications._CreateNotification CreateNotification;

		// Token: 0x040001A0 RID: 416
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRNotifications._RemoveNotification RemoveNotification;

		// Token: 0x020001DB RID: 475
		// (Invoke) Token: 0x060009EF RID: 2543
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRNotificationError _CreateNotification(ulong ulOverlayHandle, ulong ulUserValue, global::Valve.VR.EVRNotificationType type, string pchText, global::Valve.VR.EVRNotificationStyle style, ref global::Valve.VR.NotificationBitmap_t pImage, ref uint pNotificationId);

		// Token: 0x020001DC RID: 476
		// (Invoke) Token: 0x060009F3 RID: 2547
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRNotificationError _RemoveNotification(uint notificationId);
	}
}
