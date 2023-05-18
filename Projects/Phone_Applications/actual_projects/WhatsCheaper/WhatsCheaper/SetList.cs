using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatsCheaper
{
    class SetList: IComparable<SetList>
    {
        public double TextQty;
        public double TextWt;
        public double TextPrice;
        public string listunits;
        public double AbsoluteValue;
        public bool IsValid;
        public int mode;
        public int serialnumber;
        public double convertedunits;
        
        public  SetList()
        {
            IsValid = false;
           // wtorvol = true;

        }
        public int CompareTo(SetList setlist)
        {

            return this.AbsoluteValue.CompareTo(setlist.AbsoluteValue);

        }

    
        public void ConvertToAbsolute()
        {
            double convertor = 1;
            if (mode == 0)
            {
                if (listunits == "kg")
                    convertor = 1000;
                else if (listunits == "oz")
                {
                    convertor = 28.349;
                }
                else if (listunits == "lb")
                {
                    convertor = 453.59;
                }
            }
            else if (mode == 1)
            {
                if (listunits == "lt")
                {
                    convertor = 1000;
                }
                else if (listunits == "gal")
                {
                    convertor = 3785.411;
                }
                else if (listunits == "qt")
                {
                    convertor = 946.352;
                }
                else if (listunits == "pt")
                {
                    convertor = 473.176;
                }

            }
            convertedunits =convertor;

            double denominator = TextQty * TextWt * convertor;
            if (denominator != 0.0)
            {
                AbsoluteValue = TextPrice / denominator;
            }
            else
                IsValid = false;

        }
    }
}
