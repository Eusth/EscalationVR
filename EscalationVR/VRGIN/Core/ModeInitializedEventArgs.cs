using System;
using VRGIN.Modes;

namespace VRGIN.Core
{
	// Token: 0x020000B2 RID: 178
	public class ModeInitializedEventArgs : global::System.EventArgs
	{
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x000134A3 File Offset: 0x000116A3
		// (set) Token: 0x060003B2 RID: 946 RVA: 0x000134AB File Offset: 0x000116AB
		public global::VRGIN.Modes.ControlMode Mode { get; private set; }

		// Token: 0x060003B3 RID: 947 RVA: 0x000134B4 File Offset: 0x000116B4
		public ModeInitializedEventArgs(global::VRGIN.Modes.ControlMode mode)
		{
			this.Mode = mode;
		}
	}
}
