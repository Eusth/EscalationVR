using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using VRGIN.Controls;
using VRGIN.Core;
using VRGIN.Helpers;
using VRGIN.Modes;

namespace EscalationVR
{
	// Token: 0x020000EF RID: 239
	public class MasoStandingMode : global::VRGIN.Modes.StandingMode
	{
		// Token: 0x0600061C RID: 1564 RVA: 0x0001D786 File Offset: 0x0001B986
		protected override void OnStart()
		{
			base.OnStart();
			global::UnityEngine.SceneManagement.SceneManager.activeSceneChanged += new global::UnityEngine.Events.UnityAction<global::UnityEngine.SceneManagement.Scene, global::UnityEngine.SceneManagement.Scene>(this.OnSceneChanged);
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0001D7A4 File Offset: 0x0001B9A4
		protected override global::System.Collections.Generic.IEnumerable<global::VRGIN.Controls.IShortcut> CreateShortcuts()
		{
			global::System.Collections.Generic.IEnumerable<global::VRGIN.Controls.IShortcut> enumerable = base.CreateShortcuts();
			global::VRGIN.Controls.IShortcut[] array = new global::VRGIN.Controls.IShortcut[1];
			array[0] = new global::VRGIN.Controls.KeyboardShortcut(new global::VRGIN.Helpers.KeyStroke("Tab"), delegate()
			{
				global::VRGIN.Core.VR.Manager.SetMode<global::EscalationVR.MasoMode>();
			}, global::VRGIN.Helpers.KeyMode.PressUp);
			return global::System.Linq.Enumerable.Concat<global::VRGIN.Controls.IShortcut>(enumerable, array);
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0001D7F9 File Offset: 0x0001B9F9
		public override void OnDestroy()
		{
			global::UnityEngine.SceneManagement.SceneManager.activeSceneChanged -= new global::UnityEngine.Events.UnityAction<global::UnityEngine.SceneManagement.Scene, global::UnityEngine.SceneManagement.Scene>(this.OnSceneChanged);
			base.OnDestroy();
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0001D815 File Offset: 0x0001BA15
		protected override void SyncCameras()
		{
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0001D818 File Offset: 0x0001BA18
		[global::System.Diagnostics.DebuggerStepThrough]
		private void OnSceneChanged(global::UnityEngine.SceneManagement.Scene arg0, global::UnityEngine.SceneManagement.Scene arg1)
		{
			global::EscalationVR.MasoStandingMode.<OnSceneChanged>d__4 <OnSceneChanged>d__ = new global::EscalationVR.MasoStandingMode.<OnSceneChanged>d__4();
			<OnSceneChanged>d__.<>4__this = this;
			<OnSceneChanged>d__.arg0 = arg0;
			<OnSceneChanged>d__.arg1 = arg1;
			<OnSceneChanged>d__.<>t__builder = global::System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Create();
			<OnSceneChanged>d__.<>1__state = -1;
			<OnSceneChanged>d__.<>t__builder.Start<global::EscalationVR.MasoStandingMode.<OnSceneChanged>d__4>(ref <OnSceneChanged>d__);
		}
	}
}
