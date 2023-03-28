using Microsoft.VisualStudio.TestTools.UnitTesting;
using SF2022User_NN_Lib;
using System;
using System.CodeDom;

namespace SF2022User_NN_LibTests
{
    [TestClass]
    public class CalculationsTests
    {
        [TestMethod]//1
        public void AvailablePeriods_Checking_At_The_End_Of_The_Working_Day_Before_The_Start() //Проверка, если время конца рабочего дня, меньше чем его начало.
        {
            TimeSpan startWorkDay = new TimeSpan(7, 30, 0);
            Assert.AreEqual(null, Calculations.AvailablePeriods(new TimeSpan[0], new int[0], new TimeSpan(8, 30, 0), startWorkDay, 30));
        }


        [TestMethod]//2
        public void AvailablePeriods_Check_On_The_ConsultationTime_More_Workin_Day() //Проверка, если время консультации больше рабочего дня.
        {
            int consultationTime = 90;
            Assert.AreEqual("Ошибка - Укажите корректные данные", Calculations.AvailablePeriods(new TimeSpan[0], new int[0], new TimeSpan(8, 30, 0), new TimeSpan(9, 30, 0), consultationTime));
        }

        [TestMethod]//3
        public void AvailablePeriods_Check_On_The_Lack_Of_Free_Time() //Проверка, если нет свободного места для консультации.
        {
            int consultationTime = 30;
            Assert.AreEqual("Свободного места нет", Calculations.AvailablePeriods(new TimeSpan[] { new TimeSpan(8, 30, 0), new TimeSpan(9, 0, 0)}, new int[] { 30, 10}, new TimeSpan(8, 30, 0), new TimeSpan(9, 30, 0), consultationTime));
        }

        [TestMethod]//4
        public void AvailablePeriods_Check_On_The_There_Is_Free_Time() //Проверка, если есть свободное место для консультаций.
        {
            int consultationTime = 20;
            Assert.AreEqual($"{new TimeSpan(9, 10, 0)} - {new TimeSpan(9, 30, 0)}", Calculations.AvailablePeriods(new TimeSpan[] { new TimeSpan(8, 30, 0), new TimeSpan(9, 0, 0) }, new int[] { 30, 10 }, new TimeSpan(8, 30, 0), new TimeSpan(9, 30, 0), consultationTime));
        }

        [TestMethod]//5
        public void AvailablePeriods_Check_On_The_Free_Day() //Проверка, если у работника свободный день
        {
            int consultationTime = 20;
            Assert.AreEqual("День свободен", Calculations.AvailablePeriods(null , null, new TimeSpan(8, 30, 0), new TimeSpan(9, 30, 0), consultationTime));
        }

        [TestMethod]//6
        public void AvailablePeriods_Check_On_The_ConsultationTime_Equal_Null() //Проверка, если не указать время консультации
        {
            int? consultationTime = null;
            Assert.AreEqual("Укажите время консультаций", Calculations.AvailablePeriods(new TimeSpan[] { new TimeSpan(8, 30, 0), new TimeSpan(9, 0, 0) }, new int[] { 30, 10 }, new TimeSpan(8, 30, 0), new TimeSpan(9, 30, 0), consultationTime));
        }

        [TestMethod]//7
        public void AvailablePeriods_Check_On_The_All_Null() //Проверка, если не указать список и длительность консультаций и время планируемой консультации
        {
            int? consultationTime = null;
            Assert.AreEqual("Передайте больше данных", Calculations.AvailablePeriods(null, null, new TimeSpan(8, 30, 0), new TimeSpan(9, 30, 0), consultationTime));
        }
    }
}
