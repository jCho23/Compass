using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace Compass
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void LoginTest()
		{
			app.Tap(x => x.Marked("TourActivity_LoginButton"));
			app.Screenshot("Let's start by Tapping on the 'Login' Button");

			app.Tap(x => x.Marked("loginPage_UsernameField"));
			app.Screenshot("We Tapped on the 'Username' TextField");
			app.EnterText("philip.martinez@compassphs.com");
			app.Screenshot("Then we Entered our email, 'philip.martinez@compassphs.com'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Marked("loginPage_PasswordField"));
			app.Screenshot("Next, we Tapped on the 'Password' TextField");
			app.EnterText("Compass1");
			app.Screenshot("We Entered our password, 'Compass1'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Marked("loginPage_ContinueButton"));
			app.Screenshot("Then we Tapped the 'Continue' Button");

			Thread.Sleep(15000);
			app.EnterText("1,1,1,1");
			app.Screenshot("We Entered our Pin, '1111'");
			Thread.Sleep(8000);
			app.EnterText("1,1,1,1");
			Thread.Sleep(15000);
			app.Screenshot("We confirmed our pin");
		}

		[Test]
		public void AlertActionBarTest()
		{
			app.Tap(x => x.Marked("TourActivity_LoginButton"));
			app.Screenshot("Let's start by Tapping on the 'Login' Button");

			app.Tap(x => x.Marked("loginPage_UsernameField"));
			app.Screenshot("We Tapped on the 'Username' TextField");
			app.EnterText("philip.martinez@compassphs.com");
			app.Screenshot("Then we Entered our email, 'philip.martinez@compassphs.com'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Marked("loginPage_PasswordField"));
			app.Screenshot("Next, we Tapped on the 'Password' TextField");
			app.EnterText("Compass1");
			app.Screenshot("We Entered our password, 'Compass1'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Marked("loginPage_ContinueButton"));
			app.Screenshot("Then we Tapped the 'Continue' Button");

			Thread.Sleep(15000);
			app.EnterText("1,1,1,1");
			app.Screenshot("We had to enter our Pin again ");
			Thread.Sleep(8000);
			app.EnterText("1,1,1,1");
			Thread.Sleep(15000);
			app.Screenshot("We confirmed our pin");

			app.Tap(x => x.Marked("AlertActionBarMainLayout"));
			app.Screenshot("Then we Tapped on the 'Alert' Icon");

			app.Tap(x => x.Marked("actionRow_InformationLayout"));
			app.Screenshot("Next we Tapped on 'Biometric Screening'");
			app.Tap("Biometric Screening Instructions");
			app.Screenshot("Then we Tapped on 'Biometric Screening Instructions'");
			app.Back();
			app.Screenshot("We Tapped the 'Back' Button");
			app.Back();
			app.Screenshot("We Tapped the 'Back' Button again");

			app.Tap(x => x.Marked("actionRow_Description").Index(1));
			app.Screenshot("Then, we Tapped on 'Biometric Results with 2 or Fewer Risk Factos'");
			app.ScrollDownTo(x => x.Marked("incentive_action_button").Index(0));
			app.Tap(x => x.Marked("incentive_action_button").Index(0));
			app.Screenshot("Next we Tapped 'TrestleTree Coaching Information'");
		}

	}
}
