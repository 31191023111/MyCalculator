using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;

namespace MyCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        List<string> numbers = new List<string>();
        List<string> signs = new List<string>();
        bool newestInputIsSign = false;
        bool currentNumHasDot = false;

        TextView textView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            SetViews();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected void SetViews()
        {
            textView = FindViewById<TextView>(Resource.Id.numbers);

            Button button0 = FindViewById<Button>(Resource.Id.Button0);
            button0.Click += (sender, e) =>
            {
                NumberButtonClicked(0);
            };

            Button button1 = FindViewById<Button>(Resource.Id.Button1);
            button1.Click += (sender, e) =>
            {
                NumberButtonClicked(1);
            };

            Button button2 = FindViewById<Button>(Resource.Id.Button2);
            button2.Click += (sender, e) =>
            {
                NumberButtonClicked(2);
            };

            Button button3 = FindViewById<Button>(Resource.Id.Button3);
            button3.Click += (sender, e) =>
            {
                NumberButtonClicked(3);
            };

            Button button4 = FindViewById<Button>(Resource.Id.Button4);
            button4.Click += (sender, e) =>
            {
                NumberButtonClicked(4);
            };

            Button button5 = FindViewById<Button>(Resource.Id.Button5);
            button5.Click += (sender, e) =>
            {
                NumberButtonClicked(5);
            };

            Button button6 = FindViewById<Button>(Resource.Id.Button6);
            button6.Click += (sender, e) =>
            {
                NumberButtonClicked(6);
            };

            Button button7 = FindViewById<Button>(Resource.Id.Button7);
            button7.Click += (sender, e) =>
            {
                NumberButtonClicked(7);
            };

            Button button8 = FindViewById<Button>(Resource.Id.Button8);
            button8.Click += (sender, e) =>
            {
                NumberButtonClicked(8);
            };

            Button button9 = FindViewById<Button>(Resource.Id.Button9);
            button9.Click += (sender, e) =>
            {
                NumberButtonClicked(9);
            };

            Button buttonPlus = FindViewById<Button>(Resource.Id.ButtonPlus);
            buttonPlus.Click += (sender, e) =>
            {
                SignButtonClicked("+");
            };

            Button buttonMinus = FindViewById<Button>(Resource.Id.ButtonMinus);
            buttonMinus.Click += (sender, e) =>
            {
                SignButtonClicked("-");
            };

            Button buttonMultiply = FindViewById<Button>(Resource.Id.ButtonMultiply);
            buttonMultiply.Click += (sender, e) =>
            {
                SignButtonClicked("*");
            };

            Button buttonDivide = FindViewById<Button>(Resource.Id.ButtonDivide);
            buttonDivide.Click += (sender, e) =>
            {
                SignButtonClicked("/");
            };

            Button buttonDot = FindViewById<Button>(Resource.Id.ButtonDot);
            buttonDot.Click += (sender, e) =>
            {
                DotButtonClicked();
            };

            Button buttonEnter = FindViewById<Button>(Resource.Id.ButtonEnter);
            buttonEnter.Click += (sender, e) =>
            {
                Calculate();
            };

            Button buttonClear = FindViewById<Button>(Resource.Id.ButtonC);
            buttonClear.Click += (sender, e) =>
            {
                ClearAll();
                textView.Text = "";
            };
        }

        protected void NumberButtonClicked(int num)
        {
            string numbersStr = textView.Text.ToString();
            numbersStr = numbersStr + num.ToString();
            textView.Text = numbersStr;
            if (!newestInputIsSign && numbers.Count != 0)
            {
                if(numbers.Count != 0)
                {
                    string currentNumStr = numbers[numbers.Count - 1];
                    currentNumStr += num.ToString();
                    numbers[numbers.Count - 1] = currentNumStr;
                }
                else
                {
                    numbers.Add(num.ToString());
                }
            }
            else
            {
                numbers.Add(num.ToString());
            }
            newestInputIsSign = false;
        }

        protected void SignButtonClicked(string sign)
        {
            if (!newestInputIsSign && numbers.Count != 0)
            {
                string numbersStr = textView.Text.ToString();
                numbersStr = numbersStr + sign;
                textView.Text = numbersStr;

                signs.Add(sign);
                newestInputIsSign = true;
            }
        }

        protected void DotButtonClicked()
        {
            if (!newestInputIsSign && !currentNumHasDot && numbers.Count != 0)
            {
                string numbersStr = textView.Text.ToString();
                numbersStr = numbersStr + ".";
                textView.Text = numbersStr;

                string currentNumStr = numbers[numbers.Count - 1];
                currentNumStr += ".";
                numbers[numbers.Count - 1] = currentNumStr;

                currentNumHasDot = true;
            }
        }

        protected void Calculate()
        {
            if(!newestInputIsSign && numbers.Count > 1)
            {
                Calculator calculator = new Calculator();
                for(int i = 1; i < numbers.Count; i++)
                {
                    numbers[i] = calculator.Calculate(
                        Double.Parse(numbers[i - 1]), Double.Parse(numbers[i]), signs[i - 1]).ToString();
                }
                textView.Text = numbers[numbers.Count - 1];
                ClearAll();
                numbers.Add(textView.Text);
            }
        }

        protected void ClearAll()
        {
            numbers.Clear();
            signs.Clear();
            newestInputIsSign = false;
            currentNumHasDot = false;
        }
    }
}