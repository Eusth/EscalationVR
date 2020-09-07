using System;
using UnityEngine;

namespace VRGIN.Helpers
{
	// Token: 0x020000E3 RID: 227
	public class VelocityRumble : global::VRGIN.Helpers.IRumbleSession, global::System.IComparable<global::VRGIN.Helpers.IRumbleSession>
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060005AB RID: 1451 RVA: 0x0001BCD2 File Offset: 0x00019ED2
		// (set) Token: 0x060005AC RID: 1452 RVA: 0x0001BCDA File Offset: 0x00019EDA
		public bool IsOver { get; set; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060005AD RID: 1453 RVA: 0x0001BCE4 File Offset: 0x00019EE4
		public ushort MicroDuration
		{
			get
			{
				return (ushort)((float)this._MicroDuration + this.Device.velocity.magnitude / this._MaxVelocity * (float)(this._MaxMicroDuration - this._MicroDuration));
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x0001BD28 File Offset: 0x00019F28
		public float MilliInterval
		{
			get
			{
				return global::UnityEngine.Mathf.Lerp(this._MilliInterval, this._MaxMilliInterval, this.Device.velocity.magnitude / this._MaxVelocity);
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060005AF RID: 1455 RVA: 0x0001BD65 File Offset: 0x00019F65
		// (set) Token: 0x060005B0 RID: 1456 RVA: 0x0001BD6D File Offset: 0x00019F6D
		public global::SteamVR_Controller.Device Device { get; set; }

		// Token: 0x060005B1 RID: 1457 RVA: 0x0001BD76 File Offset: 0x00019F76
		public VelocityRumble(global::SteamVR_Controller.Device device, ushort microDuration, float milliInterval, float maxVelocity, ushort maxMicroDuration, float maxMilliInterval)
		{
			this.Device = device;
			this._MaxMilliInterval = maxMilliInterval;
			this._MaxMicroDuration = maxMicroDuration;
			this._MaxVelocity = maxVelocity;
			this._MilliInterval = milliInterval;
			this._MicroDuration = microDuration;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0001BDB0 File Offset: 0x00019FB0
		public int CompareTo(global::VRGIN.Helpers.IRumbleSession other)
		{
			return this.MicroDuration.CompareTo(other.MicroDuration);
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0001BDD6 File Offset: 0x00019FD6
		public void Consume()
		{
		}

		// Token: 0x04000677 RID: 1655
		private readonly ushort _MicroDuration;

		// Token: 0x04000678 RID: 1656
		private readonly float _MilliInterval;

		// Token: 0x04000679 RID: 1657
		private readonly float _MaxVelocity;

		// Token: 0x0400067A RID: 1658
		private readonly ushort _MaxMicroDuration;

		// Token: 0x0400067B RID: 1659
		private readonly float _MaxMilliInterval;
	}
}
