# Introduction #
simple-wince-gui-automation is a library to drive wince application in c#

# Samples #
You can interact with buttons :

```
WinceApplication application = WinceApplicationFactory.StartFromTypeInApplication<Form1>();
var button = application.MainWindow.Buttons.WithText("OtherButton");
Assert.AreEqual("OtherButton", button.Text);
button.Click();
Assert.AreEqual("Clicked", button.Text);
```

You can interact with checkboxes :

```
WinceApplication application = WinceApplicationFactory.StartFromTypeInApplication<Form1>();
var checkBox = application.MainWindow.CheckBoxes.WithText("My checkbox");
Assert.AreEqual("My checkbox", checkBox.Text);
Assert.IsFalse(checkBox.Checked);
checkBox.Checked = true;
Assert.IsTrue(checkBox.Checked);
```

And with other components !!!