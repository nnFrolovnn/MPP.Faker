using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FakerTest
{
    class TestFoo
    {
        public TestBar bar { get; set; }
        public int fooint { get; set; }
        public float privatesetfoofloat { get; private set; }
        public bool privatefoobool { get; set; }
        public DateTime datetime { get; set; }


        public TestFoo()
        {

        }
        public TestFoo(int i, DateTime dateTime)
        {

        }
    }

    class TestBar
    {
        public TestBar privatesettestBar { get; private set; }
        public TestBar testBar { get; set; }
        public TestFoo testFoo { get; set; }
        private string privatestring { get; set; }
        public string str { get; set; }

        private TestBar (int y, long l, string s, TestFoo foo)
        {

        }

        public TestBar(int y)
        {

        }

        public TestBar()
        {

        }
    }

    class TestTop
    {
        public TestTop testTop { get; set; }
        public List<int> list { get; set; }
        public TestBar testBar { get; set; }
        public TestFoo privatesetfoo { get; private set; }
        public char ch { get; set; }
        public bool boolean { get; set; }
        public double doub { get; set; }
    }
}
