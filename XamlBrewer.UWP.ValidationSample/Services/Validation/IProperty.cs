﻿using System;
using System.Collections.ObjectModel;
using Template10.Mvvm.Validation;

namespace Template10.Interfaces.Validation
{
    public interface IProperty : IBindable
    {
        event EventHandler ValueChanged;

        void Revert();

        void MarkAsClean();

        ObservableCollection<string> Errors { get; }

        bool IsValid { get; }

        bool IsDirty { get; }

        bool IsOriginalSet { get; }
    }
}
