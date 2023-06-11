﻿using LibDevicesManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibroMath;

namespace ManagerDS360
{
    public static class PmData
    {
        public static Dictionary<PhysicalQuantity, string> PhysicalQuantity = new Dictionary<PhysicalQuantity, string>()
        {
            { ManagerDS360.PhysicalQuantity.U,"мВ"},
            { ManagerDS360.PhysicalQuantity.м_с2,@"м/c²"},
            { ManagerDS360.PhysicalQuantity.мм_с,@"мм/с" },
            { ManagerDS360.PhysicalQuantity.мкм,@"мкм" },
        };
        public static InputEnum GetEnumFromString<InputEnum>(Dictionary<InputEnum, string> dictionary, string str) 
        {
            return dictionary.FirstOrDefault(x => x.Value == str).Key;
        }
    }
    public static class Menu<InputEnum> where InputEnum : Enum
    {
        public static Enum GetEnumFromString(Dictionary<InputEnum, string> dictionary, string str)
        {

            return dictionary.FirstOrDefault(x => x.Value == str).Key as System.Enum;
            //return Enum.GetValues(typeof(InputEnum)).GetValue(SelectedPosition) as System.Enum; // так вытягиевает из Enum, но Enum может не соответствовать по порядку Dictionary
        }
    }
}
