using System;
using System.Windows.Controls;
using System.Windows.Input;


namespace MotorController
{
    class doubleinput
    {
       // public TextBoxDoubleEx()
       // {
       //     this.KeyDown += TextBoxEx_KeyDown;
       //     this.TextChanged += TextBoxEx_TextChanged;
       // }
        void TextBoxEx_TextChanged(object sender, TextChangedEventArgs e)
        {
            //屏蔽中文输入和非法字符粘贴输入
            var textBox = sender as TextBox;
            var change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(change, 0);


            int offset = change[0].Offset;
            if (change[0].AddedLength > 0)
            {
                double num;
                if (textBox != null && !Double.TryParse(textBox.Text, out num))
                {
                    textBox.Text = textBox.Text.Remove(offset, change[0].AddedLength);
                    textBox.Select(offset, 0);
                }
            }
        }


        void TextBoxEx_KeyDown(object sender, KeyEventArgs e)
        {
            var txt = sender as TextBox;
            //屏蔽非法按键
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Decimal)
            {
                if (txt != null && (txt.Text.Contains(".") && e.Key == Key.Decimal))
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.OemPeriod) && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            {
                if (txt != null && (txt.Text.Contains(".") && e.Key == Key.OemPeriod))
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
