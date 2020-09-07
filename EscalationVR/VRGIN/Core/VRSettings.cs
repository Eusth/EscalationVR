using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using UnityEngine;
using VRGIN.Visuals;

namespace VRGIN.Core
{
	// Token: 0x020000B4 RID: 180
	[global::System.Xml.Serialization.XmlRoot("Settings")]
	public class VRSettings
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060003CB RID: 971 RVA: 0x00013973 File Offset: 0x00011B73
		// (set) Token: 0x060003CC RID: 972 RVA: 0x0001397B File Offset: 0x00011B7B
		[global::System.Xml.Serialization.XmlIgnore]
		public string Path { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060003CD RID: 973 RVA: 0x00013984 File Offset: 0x00011B84
		// (set) Token: 0x060003CE RID: 974 RVA: 0x0001399C File Offset: 0x00011B9C
		[global::VRGIN.Core.XmlComment("The distance between the camera and the GUI at [0,0,0] [seated]")]
		public float Distance
		{
			get
			{
				return this._Distance;
			}
			set
			{
				this._Distance = global::UnityEngine.Mathf.Clamp(value, 0.1f, 10f);
				this.TriggerPropertyChanged("Distance");
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060003CF RID: 975 RVA: 0x000139C4 File Offset: 0x00011BC4
		// (set) Token: 0x060003D0 RID: 976 RVA: 0x000139DC File Offset: 0x00011BDC
		[global::VRGIN.Core.XmlComment("The width of the arc the GUI takes up. [seated]")]
		public float Angle
		{
			get
			{
				return this._Angle;
			}
			set
			{
				this._Angle = global::UnityEngine.Mathf.Clamp(value, 50f, 360f);
				this.TriggerPropertyChanged("Angle");
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x00013A04 File Offset: 0x00011C04
		// (set) Token: 0x060003D2 RID: 978 RVA: 0x00013A1C File Offset: 0x00011C1C
		[global::VRGIN.Core.XmlComment("Scale of the camera. The higher, the more gigantic the player is.")]
		public float IPDScale
		{
			get
			{
				return this._IPDScale;
			}
			set
			{
				this._IPDScale = global::UnityEngine.Mathf.Clamp(value, 0.01f, 50f);
				this.TriggerPropertyChanged("IPDScale");
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x00013A44 File Offset: 0x00011C44
		// (set) Token: 0x060003D4 RID: 980 RVA: 0x00013A5C File Offset: 0x00011C5C
		[global::VRGIN.Core.XmlComment("The vertical offset of the GUI in meters. [seated]")]
		public float OffsetY
		{
			get
			{
				return this._OffsetY;
			}
			set
			{
				this._OffsetY = value;
				this.TriggerPropertyChanged("OffsetY");
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00013A74 File Offset: 0x00011C74
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x00013A8C File Offset: 0x00011C8C
		[global::VRGIN.Core.XmlComment("Degrees the GUI is rotated around the y axis [seated]")]
		public float Rotation
		{
			get
			{
				return this._Rotation;
			}
			set
			{
				this._Rotation = value;
				this.TriggerPropertyChanged("Rotation");
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00013AA4 File Offset: 0x00011CA4
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x00013ABC File Offset: 0x00011CBC
		[global::VRGIN.Core.XmlComment("Whether or not rumble is activated.")]
		public bool Rumble
		{
			get
			{
				return this._Rumble;
			}
			set
			{
				this._Rumble = value;
				this.TriggerPropertyChanged("Rumble");
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x00013AD4 File Offset: 0x00011CD4
		// (set) Token: 0x060003DA RID: 986 RVA: 0x00013AEC File Offset: 0x00011CEC
		[global::VRGIN.Core.XmlComment("The render scale of the renderer. Increase for better quality but less performance, decrease for more performance but poor quality. ]0..2]")]
		public float RenderScale
		{
			get
			{
				return this._RenderScale;
			}
			set
			{
				this._RenderScale = global::UnityEngine.Mathf.Clamp(value, 0.1f, 4f);
				this.TriggerPropertyChanged("RenderScale");
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060003DB RID: 987 RVA: 0x00013B14 File Offset: 0x00011D14
		// (set) Token: 0x060003DC RID: 988 RVA: 0x00013B2C File Offset: 0x00011D2C
		[global::VRGIN.Core.XmlComment("Whether or not to display anything on the mirror screen. (Broken)")]
		public bool MirrorScreen
		{
			get
			{
				return this._MirrorScreen;
			}
			set
			{
				this._MirrorScreen = value;
				this.TriggerPropertyChanged("MirrorScreen");
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060003DD RID: 989 RVA: 0x00013B44 File Offset: 0x00011D44
		// (set) Token: 0x060003DE RID: 990 RVA: 0x00013B5C File Offset: 0x00011D5C
		[global::VRGIN.Core.XmlComment("Whether or not rotating around the horizontal axis is allowed.")]
		public bool PitchLock
		{
			get
			{
				return this._PitchLock;
			}
			set
			{
				this._PitchLock = value;
				this.TriggerPropertyChanged("PitchLock");
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060003DF RID: 991 RVA: 0x00013B74 File Offset: 0x00011D74
		// (set) Token: 0x060003E0 RID: 992 RVA: 0x00013B8C File Offset: 0x00011D8C
		[global::VRGIN.Core.XmlComment("The curviness of the monitor in seated mode.")]
		public global::VRGIN.Visuals.GUIMonitor.CurvinessState Projection
		{
			get
			{
				return this._Projection;
			}
			set
			{
				this._Projection = value;
				this.TriggerPropertyChanged("Projection");
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x00013BA4 File Offset: 0x00011DA4
		// (set) Token: 0x060003E2 RID: 994 RVA: 0x00013BBC File Offset: 0x00011DBC
		[global::VRGIN.Core.XmlComment("Whether or not speech recognition is enabled. Refer to the manual for details.")]
		public bool SpeechRecognition
		{
			get
			{
				return this._SpeechRecognition;
			}
			set
			{
				this._SpeechRecognition = value;
				this.TriggerPropertyChanged("SpeechRecognition");
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x00013BD4 File Offset: 0x00011DD4
		// (set) Token: 0x060003E4 RID: 996 RVA: 0x00013BEC File Offset: 0x00011DEC
		[global::VRGIN.Core.XmlComment("Locale to use for speech recognition. Make sure that you have installed the corresponding language pack. A dictionary file will automatically be generated at `UserData/dictionaries`.")]
		public string Locale
		{
			get
			{
				return this._Locale;
			}
			set
			{
				this._Locale = value;
				this.TriggerPropertyChanged("Locale");
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x00013C04 File Offset: 0x00011E04
		// (set) Token: 0x060003E6 RID: 998 RVA: 0x00013C1C File Offset: 0x00011E1C
		[global::VRGIN.Core.XmlComment("Whether or not Leap Motion support is activated.")]
		public bool Leap
		{
			get
			{
				return this._Leap;
			}
			set
			{
				this._Leap = value;
				this.TriggerPropertyChanged("Leap");
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x00013C34 File Offset: 0x00011E34
		// (set) Token: 0x060003E8 RID: 1000 RVA: 0x00013C4C File Offset: 0x00011E4C
		[global::VRGIN.Core.XmlComment("Determines the rotation mode. If enabled, pulling the trigger while grabbing will immediately rotate you. When disabled, doing the same thing will let you 'drag' the view.")]
		public bool GrabRotationImmediateMode
		{
			get
			{
				return this._GrabRotationImmediateMode;
			}
			set
			{
				this._GrabRotationImmediateMode = value;
				this.TriggerPropertyChanged("GrabRotationImmediateMode");
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x00013C64 File Offset: 0x00011E64
		// (set) Token: 0x060003EA RID: 1002 RVA: 0x00013C7C File Offset: 0x00011E7C
		[global::VRGIN.Core.XmlComment("How quickly the the view should rotate when doing so with the controllers.")]
		public float RotationMultiplier
		{
			get
			{
				return this._RotationMultiplier;
			}
			set
			{
				this._RotationMultiplier = value;
				this.TriggerPropertyChanged("RotationMultiplier");
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x00013C94 File Offset: 0x00011E94
		// (set) Token: 0x060003EC RID: 1004 RVA: 0x00013CAC File Offset: 0x00011EAC
		[global::VRGIN.Core.XmlComment("Shortcuts used by VRGIN. Refer to https://docs.unity3d.com/ScriptReference/KeyCode.html for a list of available keys.")]
		public virtual global::VRGIN.Core.Shortcuts Shortcuts
		{
			get
			{
				return this._Shortcuts;
			}
			protected set
			{
				this._Shortcuts = value;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x00013CB8 File Offset: 0x00011EB8
		// (set) Token: 0x060003EE RID: 1006 RVA: 0x00013CD0 File Offset: 0x00011ED0
		public global::VRGIN.Core.CaptureConfig Capture
		{
			get
			{
				return this._CaptureConfig;
			}
			protected set
			{
				this._CaptureConfig = value;
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060003EF RID: 1007 RVA: 0x00013CDC File Offset: 0x00011EDC
		// (remove) Token: 0x060003F0 RID: 1008 RVA: 0x00013D14 File Offset: 0x00011F14
		[global::System.Diagnostics.DebuggerBrowsable(0)]
		public event global::System.EventHandler<global::System.ComponentModel.PropertyChangedEventArgs> PropertyChanged = delegate(object <p0>, global::System.ComponentModel.PropertyChangedEventArgs <p1>)
		{
		};

		// Token: 0x060003F1 RID: 1009 RVA: 0x00013D4C File Offset: 0x00011F4C
		public VRSettings()
		{
			this.PropertyChanged += new global::System.EventHandler<global::System.ComponentModel.PropertyChangedEventArgs>(this.Distribute);
			this._OldSettings = (base.MemberwiseClone() as global::VRGIN.Core.VRSettings);
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00013E54 File Offset: 0x00012054
		protected void TriggerPropertyChanged(string name)
		{
			this.PropertyChanged.Invoke(this, new global::System.ComponentModel.PropertyChangedEventArgs(name));
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00013E6A File Offset: 0x0001206A
		public virtual void Save()
		{
			this.Save(this.Path);
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00013E7C File Offset: 0x0001207C
		public virtual void Save(string path)
		{
			bool flag = path != null;
			if (flag)
			{
				global::System.Xml.Serialization.XmlSerializer xmlSerializer = new global::System.Xml.Serialization.XmlSerializer(base.GetType());
				using (global::System.IO.FileStream fileStream = global::System.IO.File.OpenWrite(path))
				{
					fileStream.SetLength(0L);
					xmlSerializer.Serialize(fileStream, this);
				}
				this.PostProcess(path);
				this.Path = path;
			}
			this._OldSettings = (base.MemberwiseClone() as global::VRGIN.Core.VRSettings);
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00013EFC File Offset: 0x000120FC
		protected virtual void PostProcess(string path)
		{
			global::System.Xml.Linq.XDocument xdocument = global::System.Xml.Linq.XDocument.Load(path);
			foreach (global::System.Xml.Linq.XElement xelement in xdocument.Root.Elements())
			{
				global::System.Reflection.PropertyInfo propertyInfo = this.FindProperty(xelement.Name.LocalName);
				bool flag = propertyInfo != null;
				if (flag)
				{
					global::VRGIN.Core.XmlCommentAttribute xmlCommentAttribute = global::System.Linq.Enumerable.FirstOrDefault<object>(propertyInfo.GetCustomAttributes(typeof(global::VRGIN.Core.XmlCommentAttribute), true)) as global::VRGIN.Core.XmlCommentAttribute;
					bool flag2 = xmlCommentAttribute != null;
					if (flag2)
					{
						xelement.AddBeforeSelf(new global::System.Xml.Linq.XComment(" " + xmlCommentAttribute.Value + " "));
					}
				}
			}
			xdocument.Save(path);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00013FC8 File Offset: 0x000121C8
		private global::System.Reflection.PropertyInfo FindProperty(string name)
		{
			return global::System.Linq.Enumerable.FirstOrDefault<global::System.Reflection.MemberInfo>(base.GetType().FindMembers(16, 20, global::System.Type.FilterName, name)) as global::System.Reflection.PropertyInfo;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00013FFC File Offset: 0x000121FC
		public static T Load<T>(string path) where T : global::VRGIN.Core.VRSettings
		{
			T result;
			try
			{
				bool flag = !global::System.IO.File.Exists(path);
				if (flag)
				{
					T t = global::System.Activator.CreateInstance<T>();
					t.Save(path);
					result = t;
				}
				else
				{
					global::System.Xml.Serialization.XmlSerializer xmlSerializer = new global::System.Xml.Serialization.XmlSerializer(typeof(T));
					using (global::System.IO.FileStream fileStream = new global::System.IO.FileStream(path, 3))
					{
						T t2 = xmlSerializer.Deserialize(fileStream) as T;
						t2.Path = path;
						result = t2;
					}
				}
			}
			catch (global::System.Exception ex)
			{
				global::VRGIN.Core.VRLog.Error("Fatal exception occured while loading XML! (Make sure System.Xml exists!) {0}", new object[]
				{
					ex
				});
				throw ex;
			}
			return result;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x000140B8 File Offset: 0x000122B8
		public void AddListener(string property, global::System.EventHandler<global::System.ComponentModel.PropertyChangedEventArgs> handler)
		{
			bool flag = !this._Listeners.ContainsKey(property);
			if (flag)
			{
				this._Listeners[property] = new global::System.Collections.Generic.List<global::System.EventHandler<global::System.ComponentModel.PropertyChangedEventArgs>>();
			}
			this._Listeners[property].Add(handler);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00014100 File Offset: 0x00012300
		public void RemoveListener(string property, global::System.EventHandler<global::System.ComponentModel.PropertyChangedEventArgs> handler)
		{
			bool flag = this._Listeners.ContainsKey(property);
			if (flag)
			{
				this._Listeners[property].Remove(handler);
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00014134 File Offset: 0x00012334
		private void Distribute(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
		{
			bool flag = !this._Listeners.ContainsKey(e.PropertyName);
			if (flag)
			{
				this._Listeners[e.PropertyName] = new global::System.Collections.Generic.List<global::System.EventHandler<global::System.ComponentModel.PropertyChangedEventArgs>>();
			}
			foreach (global::System.EventHandler<global::System.ComponentModel.PropertyChangedEventArgs> eventHandler in this._Listeners[e.PropertyName])
			{
				eventHandler.Invoke(sender, e);
			}
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x000141C4 File Offset: 0x000123C4
		public void Reset()
		{
			global::VRGIN.Core.VRSettings settings = global::System.Activator.CreateInstance(base.GetType()) as global::VRGIN.Core.VRSettings;
			this.CopyFrom(settings);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x000141EB File Offset: 0x000123EB
		public void Reload()
		{
			this.CopyFrom(this._OldSettings);
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x000141FC File Offset: 0x000123FC
		public void CopyFrom(global::VRGIN.Core.VRSettings settings)
		{
			foreach (string text in this._Listeners.Keys)
			{
				global::System.Reflection.PropertyInfo property = settings.GetType().GetProperty(text, 20);
				bool flag = property != null;
				if (flag)
				{
					try
					{
						property.SetValue(this, property.GetValue(settings, null), null);
					}
					catch (global::System.Exception obj)
					{
						global::VRGIN.Core.VRLog.Warn(obj);
					}
				}
			}
		}

		// Token: 0x040005AA RID: 1450
		private global::VRGIN.Core.VRSettings _OldSettings;

		// Token: 0x040005AB RID: 1451
		private global::System.Collections.Generic.IDictionary<string, global::System.Collections.Generic.IList<global::System.EventHandler<global::System.ComponentModel.PropertyChangedEventArgs>>> _Listeners = new global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IList<global::System.EventHandler<global::System.ComponentModel.PropertyChangedEventArgs>>>();

		// Token: 0x040005AD RID: 1453
		private float _Distance = 0.3f;

		// Token: 0x040005AE RID: 1454
		private float _Angle = 170f;

		// Token: 0x040005AF RID: 1455
		private float _IPDScale = 1f;

		// Token: 0x040005B0 RID: 1456
		private float _OffsetY = 0f;

		// Token: 0x040005B1 RID: 1457
		private float _Rotation = 0f;

		// Token: 0x040005B2 RID: 1458
		private bool _Rumble = true;

		// Token: 0x040005B3 RID: 1459
		private float _RenderScale = 1f;

		// Token: 0x040005B4 RID: 1460
		private bool _MirrorScreen = false;

		// Token: 0x040005B5 RID: 1461
		private bool _PitchLock = true;

		// Token: 0x040005B6 RID: 1462
		private global::VRGIN.Visuals.GUIMonitor.CurvinessState _Projection = global::VRGIN.Visuals.GUIMonitor.CurvinessState.Curved;

		// Token: 0x040005B7 RID: 1463
		private bool _SpeechRecognition = false;

		// Token: 0x040005B8 RID: 1464
		private string _Locale = "en-US";

		// Token: 0x040005B9 RID: 1465
		private bool _Leap = false;

		// Token: 0x040005BA RID: 1466
		private bool _GrabRotationImmediateMode = true;

		// Token: 0x040005BB RID: 1467
		private float _RotationMultiplier = 1f;

		// Token: 0x040005BC RID: 1468
		private global::VRGIN.Core.Shortcuts _Shortcuts = new global::VRGIN.Core.Shortcuts();

		// Token: 0x040005BD RID: 1469
		private global::VRGIN.Core.CaptureConfig _CaptureConfig = new global::VRGIN.Core.CaptureConfig();
	}
}
