using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WoT_CH {
	public enum Lang {
		ru, en
	}
	public enum Key {
		Menu,						//= "Меню",
		Save,						//= "Сохранить",
		Exit,						//= "Выход без сохранения",
		Info,						//= "Инфо",
		About,						//= "Об авторе",
		Error,						//= "Ошибка",
		Cross,						//= "Крест",
		Shift,						//= "Смещение",
		SaveAs,						//= "Сохранить как",
		OpenTXT,					//= "Открыть txt",
		Sentence,					//= "Предложение",
		TextFile,					//= "Текстовый файл",
		TextAbout,					//= "Юрий Волков. Обитатель 4pda под ником atribolt.\nПо всем вопросам работоспособности программы в QMS.\nЕсли есть предложения - педлагайте",
		Exception,					//= "Предупреждение",
		Background,					//= "Фон",
		GameCircle,					//= "Круг сведения",
		ImageFound,					//= "Найдено изображений",
		ErrorParse,					//= "Программа не может распарсить файл",
		SimpleCircle,				//= "Окружность",
		ErrorFileShort,				//= "В файле мало строк",
		ErrorIndexTexFile,			//= "Не могу прочитать имя tex файла в выбранном слое",
		SaveFileBeforeExit,			//= "Сохранить файл перед выходом?",
		ErrorLayerNotFound,			//= "Не могу найти выбанный слой",
		ErrorFewParamsInLayer,		//= "В слое недостаточно параметров",
		ProgramDontWEBPformat,		//= "Данная программа не умеет работать с webp изображениями."
		FileNotExists,				// = "Файл не найден",
		AtlasNotExists,				//= "Изображение выбранного слоя не найдено"
		Refresh,					//= "Сбросить"
		Edit,						//= "Редактирование"
		TileOverImage,				//= "Тайл за границами атласа, проверьте правильность файла"
		TileSetZeroPosition,		//= "Положение тайла установлено в ноль на это слое"
		TileScaleValueBeetwinError, //= "Диапазон неверный"
		TileScaleNoNumber,			//= "Значение не число"
		Settings,					//= "Настройки"
		RenderMode,					//= "Отображение"
		SmoothMode,					//= "Сглаживание тайла"
		Language,					//= "Язык"
		SaveDVPL,					//= "Сохранить в dvpl"
		OpenDVPL					//= "Открыть dvpl"
	}
	
	public static class Words {
		public static event Action ChangeLang = delegate { };

		private static string currentLang = "";
		
		static SortedList<string, string> word = new SortedList<string, string>();
		
		public static string Get(Key key) {
			try {
				string d = Enum.GetName(typeof(Key), key);
				return word[d];
			}
			catch (Exception) {
				return "Error word";
			}
		}

		private static void Read() {
			if (File.Exists(currentLang)) {
				string[] all = File.ReadAllLines(currentLang);
				word.Clear();

				for(int i = 0; i < all.Length; ++i) {
					string[] pair = all[i].Split('=');
					pair[0] = pair[0].Trim(new char[] { ' ', '"' });
					pair[1] = pair[1].Trim(new char[] { ' ', '"' });

					word.Add(pair[0], pair[1]);
				}
				
				Console.Write(' ');
			}
			else {
				Err.Show("Отсутствует файл языка\n", "Предупреждение");
			}
		}
		public static void ReadLanguageCFG(Lang l) {
			switch (l) {
				case Lang.ru:
					currentLang = Resource.Get(Res.RU);
					break;
				case Lang.en:
					currentLang = Resource.Get(Res.EN);
					break;
			}
			Read();
			ChangeLang();
		}
	}
}
