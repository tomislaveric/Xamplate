# Getting started (Windows)
Thank you [chris lynch](https://github.com/chris-lynch) for generating a Template! Here are the steps to start under Windows!

Original Comment from chris:
> I created the template files necessary to use the project in Visual Studio 2017 as a template.
> Simply zip up the repository and place it in "Documents\Visual Studio 2017\Templates\ProjectTemplates".
> Make sure the zip file doesn't contain a top level folder. if you opened the zip you should see Xamplate.vstemplate and the Xemplate.sln at the top level.
> Restart visual studio and create a new Project under Visual C# and "Xamplate" should be at the bottom of the list. If you cant see it then use the search bar.
It also updates the namespace and assembly names of each project.

# Xamplate by Tomislav Erić
A .NETStandard 2.0 Xamarin.Forms MVVM boilerplate code with Constructor Injection, ViewModel First Navigation, View-ViewModel autowireing and automatic PropertyChanged behvaiour.

With this Xamarin.Forms Template you can start an enterprise application with a lot of pre-built in features. To write this boilerplate code i was inspired by David Britchs book [Enterprise Application Patterns using Xamarin.Forms](https://developer.xamarin.com/guides/xamarin-forms/enterprise-application-patterns/) and big thanks you goes to the youtube channel [cars and code](https://www.youtube.com/channel/UC2E5d8XZyIdA8OG7ownZ21Q) which explained how to use Autofac. Down below is a list with all pre-built in functionalities for now on.

* [Xamarin.Forms 3.0 and .NETStandard 2.0 (Stable Channel)](#netstandard)
* [MVVM Structure (No third party library)](#mvvm)
* [Constructor Injection (Autofac)](#ci)
* [Autowireing for Pages and ViewModels](#autowireing)
* [ViewModel First Navigationservice](#navigationservice)
* [Automatically trigger SetPropertyChanged (Fody.PropertyChanged)](#propertychanged)

### <a name=netstandard>Xamarin.Forms .NETStandard 2.0</a>
With the new version of Xamarin.Forms we are now able to use the [.NETStandard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard). This means, we can use a ton of well maintained nuget packages developed by the huge c# community like the EntityFramework for example.

### <a name=mvvm>MVVM Structure</a>
This repository was made to go along with the [MVVM Pattern](https://developer.xamarin.com/guides/xamarin-forms/enterprise-application-patterns/mvvm/). You don't have to use a third party library (you could if want). The MVVM pattern helps you to cleanly spereate your business and presentation logic of your application.

#### MVVM Best Practices
* If you're sure that your binded property will never change, so use the x:Static flag instead of Binding. (Binding is expensive).
* Use ICommand to trigger actions instead of triggering th events from code-behind.
* If you use a DataTemplate in your ListView for example, [declare the DataType of that class in XAML.](https://blog.xamarin.com/databinding-power-moves-you-may-not-be-using-yet/)
* Try to avoid nested XAML elements as far as possible

**All of your ViewModels need to inherit from the `BaseViewModel` to get things work!**

**Tip!** Prevent to write logic in your code behind. Use your XAML or code behind just for view stuff and you're on a good way to stick to the MVVM pattern. You may ask yourself; "and how can i navigate?" -- good question! With the **ViewModel First Navigation** approach down below!

### <a name=ci>Constructor Injection</a>
Dependency Injection is a great pattern to provide dependencies to your classes. To inject dependencies via the constructor this example will help you! Let's say you will inject a DataService to a ViewModel. First of all your ViewModel has to inherit from the `BaseViewModel` class as mentiond above. Next, create a `IDataService` interface and a `DataService` class. Now open `DependencyRegistrationModule.cs` and register your new service as follows
```C#
builder.RegisterType<DataService>().As<IDataService>().SingleInstance();
```
With the SingleInstance() method, Autofac creates a Singleton for you. [Here you can find further informations about Registration Concepts.](http://docs.autofac.org/en/latest/register/registration.html).

With this in place you are now able to inject the service in your ViewModel.
```C#
private readonly IDataService _dataService;
public YourViewModel(IDataService dataService)
{
    _dataService = dataService;
}
```
Thats' it!

### <a name=autowireing>Autowireing for Pages and ViewModels</a>
With MVVM you have to wire your ViewModel with the View. There are different approaches out there like declaring the ViewModel in XAML or in the CodeBehind file. With Autofacs dependency injection we are now able to glue the View and the ViewModel by a service, so neither the ViewModel or View has to take care of the wireing. This example shows you how you glue them together. Create a `SettingsPage` and a `SettingsViewModel`. Now open `ViewModelViewRegistrationModule.cs` and register both in the overrided `Load` method as follows.
```C#
builder.RegisterType<SettingsPage>();
builder.RegisterType<SettingsViewModel>();
```
Next, open `Bootstrapper.cs` and glue them together in the `RegisterViews` method.
```C#
viewFactory.Register<SettingsViewModel, SettingsPage>();
```
And that's it!

### <a name=navigationservice>ViewModel First Navigationservice</a>
To navigate from a ViewModel to another ViewModel you just have to inject the `INavigator` service to your constructor and then call a method like `PushAsync<ViewModelToNavigateTo>`. You could bind to a command for example. The service will take care of the rest.

```C#
public YourViewModel(INavigator navigator)
{
    _navigator = navigator;
}

public ICommand NextPageCommand => new Command(() =>
{
    _navigator.PushAsync<ViewModelToNavigateTo>();
});
```

### <a name=propertychanged>Automatically trigger SetPropertyChanged</a>
While developing applications with the MVVM pattern, i was tired of implementing the `PropertyChanged` event to properties setters. The code started to become a wild and heavy to reproduce which properties are getting triggered by which properties. So i installed [Fody.PropertChanged](https://github.com/Fody/PropertyChanged). With this nuget package all of your properties will automatically be filled with the `PropertyChanged` event in the setters while compiling. And the best thing is, you can annotate properties which depend on other properties. This will result in much much less code. Here's a example.
```C#
public int ValueToChange { get; set; }
        
[DependsOn(nameof(ValueToChange))]
public string ValueToChangeIndirectly => 
    $"I depend on the value #{ValueToChange} above";
```
So if the value of `ValueToChange` changes, the `ValueToChangeIndirectly` will be triggered automatically! No need to take care about handling that manually. If you don't want to trigger it automatically you can also annotate the property with the `[DoNotNotify]` attribute. [You can also check out other attributes here.](https://github.com/Fody/PropertyChanged/wiki/Attributes).
