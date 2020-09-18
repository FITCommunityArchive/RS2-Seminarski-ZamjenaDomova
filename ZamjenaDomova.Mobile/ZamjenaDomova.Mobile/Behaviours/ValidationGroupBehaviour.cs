using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ZamjenaDomova.Mobile.Behaviours
{
    public class ValidationGroupBehaviour : Behavior<View>
    {
        IList<ValidationBehaviour> _validationBehaviours;
        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create("IsValid",
                                    typeof(bool),
                                    typeof(ValidationGroupBehaviour),
                                    false);

        public ValidationGroupBehaviour()
        {
            _validationBehaviours = new List<ValidationBehaviour>();
        }

        public void Add(ValidationBehaviour validationBehaviour)
        {
            _validationBehaviours.Add(validationBehaviour);
        }

        public void Remove(ValidationBehaviour validationBehaviour)
        {
            _validationBehaviours.Remove(validationBehaviour);
        }

        public void Update()
        {
            bool isValid = true;

            foreach (ValidationBehaviour validationItem in _validationBehaviours)
            {
                isValid = isValid && validationItem.Validate();
            }

            IsValid = isValid;
        }

        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            set
            {
                SetValue(IsValidProperty, value);
            }
        }
    }
}
