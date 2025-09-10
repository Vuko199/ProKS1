
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace ProKS1.Views
{
    public partial class PasswordPromptWindow : Window
    {
        public PasswordPromptWindow()
        {
            InitializeComponent();
            var ok = this.FindControl<Button>("OkBtn");
            var cancel = this.FindControl<Button>("CancelBtn");
            if (ok != null) ok.Click += OnOk;
            if (cancel != null) cancel.Click += (_, __) => Close(false);
        }

        private void OnOk(object? sender, RoutedEventArgs e)
        {
            var ctrl = this.FindControl<Control>("Pwd");
            var prop = ctrl?.GetType().GetProperty("Text");
            var pwd = prop?.GetValue(ctrl) as string ?? string.Empty;
            Close(string.Equals(pwd, "adnim", StringComparison.Ordinal));
        }

        private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
    }
}
