using System;
using System.Collections.Generic;
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
        public void SelectDateRange()
        {
            if (DatePicker != null)
            {
                // this method clears the selection ans selects a spcified range
                DatePicker.Content.Selection.SelectRange(DateTime.Today, DateTime.Today + TimeSpan.FromDays(-30));
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
