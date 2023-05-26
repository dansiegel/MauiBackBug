namespace MauiBackBug;

public class MyNavigationPage : NavigationPage
{
    public MyNavigationPage()
    {
        Navigation.PushAsync(new MainPage());
        Navigation.PushAsync(new ViewA());
    }

    protected override bool OnBackButtonPressed()
    {
        Console.WriteLine("NavigationPage.OnBackButtonPressed");
        System.Diagnostics.Debugger.Break();
        return base.OnBackButtonPressed();
    }
}

