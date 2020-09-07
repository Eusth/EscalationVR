using System;
using VRGIN.Helpers;

namespace VRGIN.Core
{
	// Token: 0x020000B6 RID: 182
	public class CaptureConfig
	{
		// Token: 0x040005D4 RID: 1492
		public global::VRGIN.Core.XmlKeyStroke Shortcut = new global::VRGIN.Core.XmlKeyStroke("Ctrl + F12", global::VRGIN.Helpers.KeyMode.PressUp);

		// Token: 0x040005D5 RID: 1493
		public bool Stereoscopic = true;

		// Token: 0x040005D6 RID: 1494
		public bool WithEffects = true;

		// Token: 0x040005D7 RID: 1495
		public bool SetCameraUpright = true;

		// Token: 0x040005D8 RID: 1496
		public bool HideGUI = false;
	}
}
