using System;

namespace VRGIN.Helpers
{
	// Token: 0x020000E2 RID: 226
	public class RumbleImpulse : global::VRGIN.Helpers.IRumbleSession, global::System.IComparable<global::VRGIN.Helpers.IRumbleSession>
	{
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x0001BC44 File Offset: 0x00019E44
		public bool IsOver
		{
			get
			{
				return this._Over;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0001BC5C File Offset: 0x00019E5C
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x0001BC64 File Offset: 0x00019E64
		public ushort MicroDuration { get; set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0001BC70 File Offset: 0x00019E70
		public float MilliInterval
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x0001BC87 File Offset: 0x00019E87
		public void Consume()
		{
			this._Over = true;
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0001BC91 File Offset: 0x00019E91
		public RumbleImpulse(ushort strength)
		{
			this.MicroDuration = strength;
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0001BCAC File Offset: 0x00019EAC
		public int CompareTo(global::VRGIN.Helpers.IRumbleSession other)
		{
			return this.MicroDuration.CompareTo(other.MicroDuration);
		}

		// Token: 0x04000674 RID: 1652
		private bool _Over = false;
	}
}
