using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bitsplash.DatePicker.Tutorials
{
    public class SelectionTutorial : MonoBehaviour
    {
        public DatePickerSettings DatePicker;
        public Text InfoText;

        public DateTime FirstDate;
        public DateTime LastDate;

        public TMP_InputField FirstDateInputField; 
        public TMP_InputField LastDateInputField;  


        public void UpdateInputField()
        {
            FirstDateInputField.text = FirstDate.ToShortDateString();
            LastDateInputField.text = LastDate.ToShortDateString();
        }

        void Start()
        {
            if(DatePicker != null)
            {
                // handle selection change using a unity event
                DatePicker.Content.OnSelectionChanged.AddListener(OnSelectionChanged);
                DatePicker.Content.OnDisplayChanged.AddListener(OnDisplayChanged);

                UpdateInputField();

                ShowAllSelectedDates();// show all the selected days in the begining
                DatePicker.Content.SetMarkerColor(DateTime.Now, Color.red);   
               
                
            }
            
        }
        public void OnDisplayChanged()
        {
            var cell = DatePicker.Content.GetCellObjectByDate(DateTime.Now);
            if (cell != null)
            {
                cell.CellEnabled = false;
            }
        }
        public void SelectSingleDate()
        {
            if(DatePicker != null)
            {
                // this method clears the selection and selects the specified date
                DatePicker.Content.Selection.SelectOne(DateTime.Today);
            }
        }
        public void SelectWeek()
        {
            if (DatePicker != null)
            {
                DateTime today = DateTime.Today;
                DateTime weekAgo = today.AddDays(-7);
                DatePicker.Content.Selection.SelectRange(weekAgo, today);
            }
        }
        public void Select15Days()
        {
            if (DatePicker != null)
            {
                DateTime today = DateTime.Today;
                DateTime daysAgo15 = today.AddDays(-15);
                DatePicker.Content.Selection.SelectRange(daysAgo15, today);
            }
        }
        public void SelectMonth()
        {
            if (DatePicker != null)
            {
                DateTime today = DateTime.Today;
                DateTime monthAgo = today.AddMonths(-1);
                DatePicker.Content.Selection.SelectRange(monthAgo, today);
            }
        }

        public void Select3Months()
        {
            if (DatePicker != null)
            {
                DateTime today = DateTime.Today;
                DateTime monthsAgo3 = today.AddMonths(-3);
                DatePicker.Content.Selection.SelectRange(monthsAgo3, today);
            }
        }
        public void SetAllTimeRangeForCurrentProductLine()
        {
            SetDateRange(GameManager.Instance.CurrentProductionLine.GetParameterData(GameManager.Instance.GetDropDownOptios()));
            DatePicker.Content.Selection.SelectRange(FirstDate, LastDate);
            UpdateInputField();
        }

        public void SetDateRange(Dictionary<DateTime, float> data)
        {
            if (data.Count > 0)
            {
                FirstDate = data.Keys.Min();
                LastDate = data.Keys.Max();
            }
            else
            {
                // Обработка случая, когда словарь пуст
                FirstDate = DateTime.MinValue;
                LastDate = DateTime.MinValue;
            }
        }


        void ShowAllSelectedDates()
        {
            if(InfoText != null)
            {
                string text = "";
                var selection = DatePicker.Content.Selection;
                for (int i=0; i< selection.Count; i++)
                {
                    var date = selection.GetItem(i);
                    text += "\r\n" + date.ToShortDateString();
                }
                InfoText.text = text;

                ShowFirstAndLastSelectedDates();
                UpdateInputField();
            }
        }

        void ShowFirstAndLastSelectedDates()
        {
            if (InfoText != null && DatePicker != null)
            {
                var selection = DatePicker.Content.Selection;
                if (selection.Count > 0)
                {
                    // Сортируем выбранные даты
                    List<DateTime> sortedDates = new List<DateTime>(selection.GetItems());
                    sortedDates.Sort();

                    // Получаем первую и последнюю даты
                    FirstDate = sortedDates[0];
                    LastDate = sortedDates[sortedDates.Count - 1];

                    // Форматируем даты для отображения
                    string text = "Первая дата: " + FirstDate.ToShortDateString() +
                                  "\r\nПоследняя дата: " + LastDate.ToShortDateString();

                    InfoText.text = text;
                }
            }
        }

        void OnSelectionChanged()
        {
            ShowAllSelectedDates();
        }
        
    }
}
