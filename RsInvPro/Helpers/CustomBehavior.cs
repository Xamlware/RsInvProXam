using System;
using System.Windows.Input;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RsInvPro.Helpers
{
    public class CustomBehavior : Xamarin.Forms.Behavior<SfDataGrid>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(CustomBehavior), null);
        public static readonly BindableProperty InputConverterProperty = BindableProperty.Create("Converter", typeof(IValueConverter), typeof(CustomBehavior), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(InputConverterProperty); }
            set { SetValue(InputConverterProperty, value); }
        }

        public SfDataGrid AssociatedObject { get; private set; }


        protected override void OnAttachedTo(SfDataGrid bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.SelectionChanged += bindable_SelectionChanged;
        }

        void bindable_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            if (Command == null)
            {
                return;
            }

            object parameter = Converter.Convert(e, typeof(object), null, null);
            var temp = (parameter as GridSelectionChangedEventArgs).AddedItems;

            if (Command.CanExecute(parameter))
            {
                Command.Execute(parameter);
            }
        }


        protected override void OnDetachingFrom(SfDataGrid bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable.SelectionChanged -= bindable_SelectionChanged;
            AssociatedObject = null;
        }
        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}