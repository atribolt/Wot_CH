using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoT_CH {
	public enum Res {
		SimpleCircle,
		Cross,
		GameCircle,
		RU,
		EN,
		RES_DIR
	}
	public static class Resource {
		public static string Get(Res r) {
			switch (r) {
				case Res.Cross:			return "./Resource/Cross.png";
				case Res.GameCircle:	return "./Resource/GameCircle.png";
				case Res.SimpleCircle:	return "./Resource/SimpleCircle.png";
				case Res.RU:			return "./Resource/Lang/RU.cfg";
				case Res.EN:			return "./Resource/Lang/EN.cfg";
				default:				return "./Resource/";
			}
		}
	}
}
