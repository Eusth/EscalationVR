using System;
using UnityEngine;
using VRGIN.Core;
using VRGIN.Helpers;

namespace VRGIN.Controls.Handlers
{
	// Token: 0x020000C9 RID: 201
	public class BodyRumbleHandler : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x060004A6 RID: 1190 RVA: 0x00017ED8 File Offset: 0x000160D8
		protected override void OnStart()
		{
			base.OnStart();
			this._Controller = base.GetComponent<global::VRGIN.Controls.Controller>();
			this._Rumble = new global::VRGIN.Helpers.VelocityRumble(global::SteamVR_Controller.Input((int)this._Controller.Tracking.index), 30, 10f, 3f, 1500, 10f);
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x00017F2F File Offset: 0x0001612F
		protected override void OnLevel(int level)
		{
			base.OnLevel(level);
			this.OnStop();
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00017F41 File Offset: 0x00016141
		protected void OnDisable()
		{
			this.OnStop();
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00017F4B File Offset: 0x0001614B
		protected override void OnUpdate()
		{
			base.OnUpdate();
			this._Rumble.Device = global::SteamVR_Controller.Input((int)this._Controller.Tracking.index);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00017F78 File Offset: 0x00016178
		protected void OnTriggerEnter(global::UnityEngine.Collider collider)
		{
			bool flag = global::VRGIN.Core.VR.Interpreter.IsBody(collider);
			if (flag)
			{
				this._TouchCounter++;
				this._Controller.StartRumble(this._Rumble);
				bool flag2 = this._TouchCounter == 1;
				if (flag2)
				{
					this._Controller.StartRumble(new global::VRGIN.Helpers.RumbleImpulse(1000));
				}
			}
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00017FDC File Offset: 0x000161DC
		protected void OnTriggerExit(global::UnityEngine.Collider collider)
		{
			bool flag = global::VRGIN.Core.VR.Interpreter.IsBody(collider);
			if (flag)
			{
				this._TouchCounter--;
				bool flag2 = this._TouchCounter == 0;
				if (flag2)
				{
					this._Controller.StopRumble(this._Rumble);
				}
			}
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0001802C File Offset: 0x0001622C
		protected void OnStop()
		{
			this._TouchCounter = 0;
			bool flag = this._Controller;
			if (flag)
			{
				this._Controller.StopRumble(this._Rumble);
			}
		}

		// Token: 0x0400063F RID: 1599
		private global::VRGIN.Controls.Controller _Controller;

		// Token: 0x04000640 RID: 1600
		private int _TouchCounter = 0;

		// Token: 0x04000641 RID: 1601
		private global::VRGIN.Helpers.VelocityRumble _Rumble;
	}
}
