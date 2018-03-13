using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopSQL
{
    class Cars
    {
        private string _make;
        private string _model;
        private string _colour;
        private double _price;
        private double _comm;
        private double _netValue;

        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public string Colour
        {
            get { return _colour; }
            set { _colour = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public double Comm
        {
            get { return _comm; }
            set { _comm = value; }
        }
        public double netValue
        {
            get { return _netValue; }
            set { _netValue = value; }
        }


        public Cars()
        {

        }
    }
}
