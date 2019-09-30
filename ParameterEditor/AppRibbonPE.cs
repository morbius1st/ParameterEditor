using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.DB.Events;
using Application = Autodesk.Revit.ApplicationServices.Application;
using UtilityLibrary;
using static UtilityLibrary.MessageUtilities;

namespace ParameterEditor
{
	class AppRibbonPE : IExternalApplication, IDisposable
	{
		// application: launch with revit - setup interface elements
		// display information

		private const string NAMESPACE_PREFIX = "ParameterEditor.Assets";

		private const string PANEL_NAME = "Pram Edit";
		private const string TAB_NAME = "AO Tools";

		private static string AddInPath = typeof(AppRibbonPE).Assembly.Location;
		private const string CLASSPATH = "ParameterEditor.";

		private const string SMALLICON = "information16.png";
		private const string LARGEICON = "information32.png";

		private UIApplication uiApp;
		//		internal UIControlledApplication uiCtrlApp;

		//		public static PulldownButton pb;
		//		public static SplitButton sb;


		public Result OnStartup(UIControlledApplication app)
		{
			try
			{
				// uiCtrlApp = app;

				app.ControlledApplication.ApplicationInitialized += OnAppInitalized;

				// create the ribbon tab first - this is the top level
				// ui item.  below this will be the panel that is "on" the tab
				// and below this will be a pull down or split button that is "on" the panel;

				// give the tab a name;
				string tabName = TAB_NAME;
				// give the panel a name
				string panelName = PANEL_NAME;

				// first try to create the tab
				try
				{
					app.CreateRibbonTab(tabName);
				}
				catch (Exception)
				{
					// might already exist - do nothing
				}

				// tab created or exists

				// create the ribbon panel if needed
				RibbonPanel ribbonPanel = null;

				// check to see if the panel already exists
				// get the Panel within the tab name
				List<RibbonPanel> rp = new List<RibbonPanel>();

				rp = app.GetRibbonPanels(tabName);

				foreach (RibbonPanel rpx in rp)
				{
					if (rpx.Name.ToUpper().Equals(panelName.ToUpper()))
					{
						ribbonPanel = rpx;
						break;
					}
				}

				// if panel not found
				// add the panel if it does not exist
				if (ribbonPanel == null)
				{
					// create the ribbon panel on the tab given the tab's name
					// FYI - leave off the ribbon panel's name to put onto the "add-in" tab
					ribbonPanel = app.CreateRibbonPanel(tabName, panelName);
				}

				ribbonPanel.AddItem(
					createButton("PramEdit", "Param\nEdit", "ParameterEdit",
						"Edit the Parameters of a Family", SMALLICON, LARGEICON));


				//				// example 1
				//				//add a pull down button to the panel
				//				if (!AddPullDownButton(ribbonPanel))
				//				{
				//					// create the split button failed
				//					MessageBox.Show("Failed to Add the Pull Down Button!", "Information",
				//						MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				//					return Result.Failed;
				//				}
				//
				//				// example 2
				//				//add a stacked pair of push buttons to the panel
				//				if (!AddStackedPushButtons(ribbonPanel))
				//				{
				//					// create the split button failed
				//					MessageBox.Show("Failed to Add the Stacked Push Buttons!", "Information",
				//						MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				//					return Result.Failed;
				//				}
				//
				//				// example 3
				//				//add a stacked pair of push buttons and a text box to the panel
				//				if (!AddStackedPushButtonsAndTextBox(ribbonPanel))
				//				{
				//					// create the split button failed
				//					MessageBox.Show("Failed to Add the Stacked Push Buttons and TextBox!", "Information",
				//						MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				//					return Result.Failed;
				//				}

			}
			catch (Exception e)
			{
				Debug.WriteLine("exception " + e.Message);
				return Result.Failed;
			}

			return Result.Succeeded;
		}

		private void OnAppInitalized(object sender, ApplicationInitializedEventArgs e)
		{
			Application app = sender as Application;

			uiApp = new UIApplication(app);
		}

		private PushButtonData createButton(string ButtonName, string ButtonText,
			string className, string ToolTip, string smallIcon, string largeIcon)
		{
			PushButtonData pbd;

			try
			{
				pbd = new PushButtonData(ButtonName, ButtonText, AddInPath, string.Concat(CLASSPATH, className))
				{
					Image = CsUtilitiesMedia.GetBitmapImage(smallIcon, NAMESPACE_PREFIX),
					LargeImage = CsUtilitiesMedia.GetBitmapImage(largeIcon, NAMESPACE_PREFIX),
					ToolTip = ToolTip
				};
			}
			catch
			{
				return null;
			}

			return pbd;
		}

		// process when shutting down
		public Result OnShutdown(UIControlledApplication a)
		{
			try
			{
				return Result.Succeeded;
			}
			catch
			{
				return Result.Failed;
			}
		}

		public void Dispose()
		{
			uiApp?.Dispose();
		}
	}


}

