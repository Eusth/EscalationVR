using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x0200002D RID: 45
	public class CVRNotifications
	{
		// Token: 0x060001DF RID: 479 RVA: 0x0000D15A File Offset: 0x0000B35A
		internal CVRNotifications(global::System.IntPtr pInterface)
		{
			this.FnTable = (global::Valve.VR.IVRNotifications)global::System.Runtime.InteropServices.Marshal.PtrToStructure(pInterface, typeof(global::Valve.VR.IVRNotifications));
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000D180 File Offset: 0x0000B380
		public global::Valve.VR.EVRNotificationError CreateNotification(ulong ulOverlayHandle, ulong ulUserValue, global::Valve.VR.EVRNotificationType type, string pchText, global::Valve.VR.EVRNotificationStyle style, ref global::Valve.VR.NotificationBitmap_t pImage, ref uint pNotificationId)
		{
			pNotificationId = 0U;
			return this.FnTable.CreateNotification(ulOverlayHandle, ulUserValue, type, pchText, style, ref pImage, ref pNotificationId);
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000D1B4 File Offset: 0x0000B3B4
		public global::Valve.VR.EVRNotificationError RemoveNotification(uint notificationId)
		{
			return this.FnTable.RemoveNotification(notificationId);
		}

		// Token: 0x040001B5 RID: 437
		private global::Valve.VR.IVRNotifications FnTable;
	}
}
