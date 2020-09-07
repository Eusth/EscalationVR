using System;

namespace VRGIN.Helpers
{
	// Token: 0x020000E0 RID: 224
	public interface IRumbleSession : global::System.IComparable<global::VRGIN.Helpers.IRumbleSession>
	{
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000592 RID: 1426
		bool IsOver { get; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000593 RID: 1427
		ushort MicroDuration { get; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000594 RID: 1428
		float MilliInterval { get; }

		// Token: 0x06000595 RID: 1429
		void Consume();
	}
}
