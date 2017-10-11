using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Template10.Controls.Validation;
using Template10.Interfaces.Validation;
using Windows.Foundation.Collections;

namespace Template10.Validation
{
    public abstract class ValidatableModelBase : IValidatableModel, INotifyPropertyChanged
    {
        public ValidatableModelBase()
        {
            Properties.MapChanged += (s, e) =>
            {
                if (e.CollectionChange.Equals(CollectionChange.ItemInserted))
                    Properties[e.Key].ValueChanged += (sender, args) =>
                    {
                        RaisePropertyChanged(e.Key);
                        RaisePropertyChanged(nameof(IsDirty));
                        RaisePropertyChanged(nameof(IsValid));
                    };
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected T Read<T>([CallerMemberName]string propertyName = null)
        {
            if (!Properties.ContainsKey(propertyName))
                Properties.Add(propertyName, new Property<T>());
            return (Properties[propertyName] as IProperty<T>).Value;
        }

        protected void Write<T>(T value, [CallerMemberName]string propertyName = null, bool validateAfter = true)
        {
            if (!Properties.ContainsKey(propertyName))
                Properties.Add(propertyName, new Property<T>());
            var property = (Properties[propertyName] as IProperty<T>);
            var previous = property.Value;
            if (!property.IsOriginalSet || !Equals(value, previous))
            {
                property.Value = value;
                Validate(validateAfter);
            }
        }

        public bool Validate(bool validateAfter = true)
        {
            if (validateAfter)
            {
                foreach (var property in Properties)
                {
                    property.Value.Errors.Clear();
                }
                Validator?.Invoke(this);
                Errors.Clear();
                foreach (var error in Properties.Values.SelectMany(x => x.Errors))
                {
                    Errors.Add(error);
                }
                RaisePropertyChanged(nameof(IsValid));
            }
            return IsValid;
        }

        public void Revert()
        {
            foreach (var property in Properties)
            {
                property.Value.Revert();
            }
            Validate();
        }

        public void MarkAsClean()
        {
            foreach (var property in Properties)
            {
                property.Value.MarkAsClean();
            }
            Validate();
        }

        public ObservableDictionary<string, IProperty> Properties { get; }
            = new ObservableDictionary<string, IProperty>();

        public ObservableCollection<string> Errors { get; }
            = new ObservableCollection<string>();

        public Action<IValidatableModel> Validator { set; get; }

        public bool IsValid => !Errors.Any();

        public bool IsDirty => Properties.Any(x => x.Value.IsDirty);

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
