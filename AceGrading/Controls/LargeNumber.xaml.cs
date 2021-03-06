﻿using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace AceGrading
{
    public partial class LargeNumber : UserControl
    {
        public LargeNumber()
        {
            InitializeComponent();
        }

        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(LargeNumber), new PropertyMetadata("0"));

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(LargeNumber), new PropertyMetadata(string.Empty));

        public enum _LabelPosition { Top, Bottom, Left, Right };


        public _LabelPosition LabelPosition 
        {
            get { return (_LabelPosition)GetValue(LabelPositionProperty); }
            set { SetValue(LabelPositionProperty, value); }
        }

        public static readonly DependencyProperty LabelPositionProperty =
            DependencyProperty.Register("LabelPosition", typeof(_LabelPosition), typeof(LargeNumber), new PropertyMetadata(_LabelPosition.Right));

        public _Size Size  
        {
            get { return (_Size)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(_Size), typeof(LargeNumber), new PropertyMetadata(_Size.Large));



        public double LabelWidth
        {
            get { return (double)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(double), typeof(LargeNumber), new PropertyMetadata(double.MaxValue));



        public bool IsEditable
        {
            get { return (bool)GetValue(IsEditableProperty); }
            set { SetValue(IsEditableProperty, value); }
        }

        public static readonly DependencyProperty IsEditableProperty =
            DependencyProperty.Register("IsEditable", typeof(bool), typeof(LargeNumber), new PropertyMetadata(false));

        public bool IsNumber
        {
            get { return (bool)GetValue(IsNumberProperty); }
            set { SetValue(IsNumberProperty, value); }
        }

        public static readonly DependencyProperty IsNumberProperty =
            DependencyProperty.Register("IsNumber", typeof(bool), typeof(LargeNumber), new PropertyMetadata(true));





        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = !Regex.IsMatch(textBox.Text + e.Text, @"^[\d]{1,9}(\.)?([\d]{1,9})?$");
        }
    }

    public enum _Size { Small, Medium, Large }
}
