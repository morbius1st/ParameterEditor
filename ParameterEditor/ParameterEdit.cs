using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using ParameterEditor.DebugWin;
using ParameterEditor.DebugWin.DebugWinSupport;
using ParameterEditor.MainWin;
using ParameterEditor.Managers.ParameterSupport;
using static UtilityLibrary.MessageUtilities;

namespace ParameterEditor
{
	[Transaction(TransactionMode.Manual)]
	public class ParameterEdit : IExternalCommand
	{
		private static UIDocument uiDoc;
		public static Document Doc { get; private set; }

		public Result Execute(
			ExternalCommandData commandData,
			ref string message,
			ElementSet elements
			)
		{
			UIApplication uiApp = commandData.Application;
			uiDoc = uiApp.ActiveUIDocument;
			Doc = uiDoc.Document;

			using (Transaction tg = new Transaction(Doc, "Edit Family Parameters"))
			{
				tg.Start();
				Process();
				tg.Commit();
			}

			return Result.Succeeded;
		}

		private void Process()
		{
			logMsgDbLn2("ParameterEdit", "Process");
			MainWindow mw = new MainWindow();

			mw.ShowDialog();


		}
	}
}
