﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TestApp;

namespace AsyncTestApp.Service
{
    public class Window : ModelBase, IEquatable<Window>, IComparable<Window>
    {
        /// <summary>
        /// Gets or Sets the id of the window used as identification
        /// </summary>
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private int _id;

        /// <summary>
        /// Gets or Sets the window handle used to manipulate window information through the WinApi
        /// </summary>
        public IntPtr WindowHandle
        {
            get => _windowHandle;
            set => SetProperty(ref _windowHandle, value);
        }

        private IntPtr _windowHandle;

        /// <summary>
        /// Gets or Sets the description of the application that owns the window
        /// <remarks>Defaults to an empty string</remarks>
        /// </summary>
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private string _description = string.Empty;



        /// <summary>
        /// Gets or Sets the dimensions of the window
        /// </summary>
        public Rect Dimensions
        {
            get => _dimensions;
            set
            {
                SetProperty(ref _dimensions, value);
               // RaisePropertyChanged(nameof(Resolution));
            }
        }

        private Rect _dimensions;

        /// <summary>
        /// Gets the resolution of the application
        /// </summary>
        [DependsOnProperty(nameof(Dimensions))]
        public string Resolution => $"{Dimensions.Right - Dimensions.Left} x {Dimensions.Bottom - Dimensions.Top}";

        /// <summary>
        /// Comapares the current <see cref="Window"/> to a given <see cref="Window"/>
        /// </summary>
        /// <param name="other"><see cref="Window"/> to compare to the current instance</param>
        /// <returns>Returns <see langword="true"/> if the current istance is equal to the given <see cref="Window"/>, otherwise returns <see langword="false"/></returns>
        public bool Equals([AllowNull] Window other)
            => other?.Id == Id
            && other?.WindowHandle == WindowHandle
            && other?.Description == Description
            && other?.Dimensions == Dimensions;

        /// <summary>
        /// Compare if the current <see cref="Window"/> represents the same item as a given <see cref="Window"/>
        /// </summary>
        /// <param name="other"><see cref="Window"/> to compare against</param>
        /// <returns>Returns <see langword="true"/> if the <see cref="Window"/> represent the same <see cref="Window"/>, otherwise returns <see langword="false"/></returns>
        public int CompareTo([AllowNull] Window other)
        {
            if(other?.Id == Id)
            {
                return 0;
            }
            return -1;
        }

        /// <summary>
        /// Comapares the current <see cref="Window"/> to a given <see cref="object"/>
        /// </summary>
        /// <param name="obj"><see cref="object"/> to compare to the current instance</param>
        /// <returns>Returns <see langword="true"/> if the current istance is equal to the given <see cref="object"/>, otherwise returns <see langword="false"/></returns>
        public override bool Equals(object? obj)
            => obj is Window window
            && Equals(window);

        /// <summary>
        /// Gets the hashCode of the <see cref="Window"/>
        /// </summary>
        /// <returns>Returns <see cref="int"/> containing a unique hashcode that represents the instance of the current <see cref="Window"/></returns>
        public override int GetHashCode()
            => (Id, WindowHandle, Description, Dimensions).GetHashCode();
    }
}
