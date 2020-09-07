using System;
using UnityEngine;

namespace VRGIN.Helpers
{
	// Token: 0x020000E1 RID: 225
	public class RumbleSession : global::VRGIN.Helpers.IRumbleSession, global::System.IComparable<global::VRGIN.Helpers.IRumbleSession>
	{
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x0001BB17 File Offset: 0x00019D17
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x0001BB1F File Offset: 0x00019D1F
		public bool IsOver { get; private set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x0001BB28 File Offset: 0x00019D28
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x0001BB30 File Offset: 0x00019D30
		public ushort MicroDuration { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x0001BB39 File Offset: 0x00019D39
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x0001BB41 File Offset: 0x00019D41
		public float MilliInterval { get; set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0001BB4A File Offset: 0x00019D4A
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x0001BB52 File Offset: 0x00019D52
		public float Lifetime { get; set; }

		// Token: 0x0600059E RID: 1438 RVA: 0x0001BB5B File Offset: 0x00019D5B
		public RumbleSession(ushort microDuration, float milliInterval)
		{
			this.MicroDuration = microDuration;
			this.MilliInterval = milliInterval;
			this._Time = global::UnityEngine.Time.time;
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0001BB8B File Offset: 0x00019D8B
		public RumbleSession(ushort microDuration, float milliInterval, float lifetime)
		{
			this.MicroDuration = microDuration;
			this.MilliInterval = milliInterval;
			this.Lifetime = lifetime;
			this._Time = global::UnityEngine.Time.time;
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0001BBC3 File Offset: 0x00019DC3
		public void Close()
		{
			this.IsOver = true;
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0001BBD0 File Offset: 0x00019DD0
		public int CompareTo(global::VRGIN.Helpers.IRumbleSession other)
		{
			return this.MicroDuration.CompareTo(other.MicroDuration);
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0001BBF6 File Offset: 0x00019DF6
		public void Restart()
		{
			this._Time = global::UnityEngine.Time.time;
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0001BC04 File Offset: 0x00019E04
		public void Consume()
		{
			bool flag = this.Lifetime > 0f && global::UnityEngine.Time.time - this._Time > this.Lifetime;
			if (flag)
			{
				this.IsOver = true;
			}
		}

		// Token: 0x04000673 RID: 1651
		private float _Time = 0f;
	}
}
